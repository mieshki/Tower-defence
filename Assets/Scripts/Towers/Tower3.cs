using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower3 : MonoBehaviour {

    private Transform target;

    [Header("Attributes")]
    public int Tower3Level = GameStats.Tower3Level;
    public float Tower3Cost = GameStats.Tower3Cost;
    public float range = GameStats.Tower3Range;
    public float fireRate = GameStats.Tower3FireRate;   
    public float Tower3Damage = GameStats.Tower3Damage;

    public string upgradeLevel = "";
    public string upgradeCost = "";
    public string upgradeDamage = "";
    public string upgradeFireRate = "";
    public string upgradeRange = "";

    public static int Tower3LevelStatic = GameStats.Tower3Level;
    public static float Tower3CostStatic = GameStats.Tower3Cost;
    public static float Tower3DamageStatic = GameStats.Tower3Damage;
    public static float Tower3RangeStatic = GameStats.Tower3Range;
    public static float Tower3FireRateStatic = GameStats.Tower3FireRate;

    public static string upgradeLevelStatic = "";
    public static string upgradeCostStatic = "";
    public static string upgradeDamageStatic = "";
    public static string upgradeFireRateStatic = "";
    public static string upgradeRangeStatic = "";

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    private float fireCountdown = 0f;
    public float idleRotationSpeed = 80f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Tower3 Stats Informations")]
    public Sprite Tower3Avatar;
    public static string Tower3Name = "Tower3/freeze";
    public static string Tower3LevelStat = "Level: " + Tower3LevelStatic;
    public static string Tower3LevelStatUpgrade = upgradeLevelStatic;
    public static string Tower3Optionally = "";
    public static string Tower3Stats1 = "Price: " + Tower3CostStatic;
    public static string Tower3Stats1Upgrade = upgradeCostStatic;
    public static string Tower3Stats2 = "Damage: " + Tower3DamageStatic;
    public static string Tower3Stats2Upgrade = upgradeDamageStatic;
    public static string Tower3Stats3 = "FireRatio: " + Tower3FireRateStatic / 1 + " /s";
    public static string Tower3Stats3Upgrade = "";
    public static string Tower3Stats4 = "Range: " + Tower3RangeStatic;
    public static string Tower3Stats4Upgrade = upgradeRangeStatic;
    public static string Tower3Stats5 = "Type: Ground & Air";
    public static string Tower3Stats5Upgrade = "";

    public Vector3 Tower3circleRangePos;
    public Vector3 Tower3circleRangeScale;

    void Awake()
    {
        Tower3Level = GameStats.Tower3Level;
        Tower3Cost = GameStats.Tower3Cost;
        Tower3Damage = GameStats.Tower3Damage;
        range = GameStats.Tower3Range;
        fireRate = GameStats.Tower3FireRate;
        UpdateInfo();
    }

    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
        UpdateInfo();
    }

    public GameObject nearestEnemy;
    public float shortestDistance;
    public bool haveTarget = false;

    void UpdateTarget()
    {
        if (!haveTarget)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            shortestDistance = Mathf.Infinity;
            nearestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            haveTarget = true;
        }
        else
        {
            target = null;
            haveTarget = false;
        }
    }

    public float distanceToEnemyUpdated = Mathf.Infinity;
    void Update ()
    {
        Tower3circleRangePos = new Vector3(transform.position.x, -0.5f, transform.position.z);
        Tower3circleRangeScale.x = range * 2;
        Tower3circleRangeScale.z = range * 2;

        if (fireCountdown >= 0f)
            fireCountdown -= Time.deltaTime;

        if (gameObject.tag == "turretAbleToShoot")
        {
		    if (target == null)
                return;

            // obliczanie odleglosci = cel - twojaPozycja
            Vector3 dir = target.position - transform.position;
            shortestDistance = Vector3.Distance(transform.position, target.transform.position);
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            if(fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        }
    }

    void Shoot ()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.name = Tower3Damage.ToString();

        if (bullet != null)
            bullet.Seek(target);    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "checkingGO")
            UpdateUIStats();
    }

    public void UpdateUIStats()
    {
        UpdateInfo();
        MenuButtons.UpdateUIStatsInfo(Tower3Avatar, Tower3Name, Tower3LevelStat, Tower3LevelStatUpgrade, Tower3Optionally, Tower3Stats1, Tower3Stats1Upgrade, Tower3Stats2, Tower3Stats2Upgrade, Tower3Stats3, Tower3Stats3Upgrade, Tower3Stats4, Tower3Stats4Upgrade, Tower3Stats5, Tower3Stats5Upgrade);
        MenuButtons.UIStatsEnemyEnabled = false;
        MenuButtons.UIStatsEnabled = true;
        MenuButtons.UIUpgradeAndSellButtonToggle = true;
        MenuButtons.towerToDo = gameObject;
        PublicGameobjects.showRange = true;
        PublicGameobjects.circleRangePos = Tower3circleRangePos;
        PublicGameobjects.circleRangeScale = Tower3circleRangeScale;
    }

    public void UpdateInfo()
    {
        Tower3Level = GameStats.Tower3Level;
        Tower3Cost = GameStats.Tower3Cost;
        Tower3Damage = GameStats.Tower3Damage;
        range = GameStats.Tower3Range;
        fireRate = GameStats.Tower3FireRate;

        upgradeLevelStatic = upgradeLevel;
        upgradeCostStatic = upgradeCost;
        upgradeDamageStatic = upgradeDamage;
        upgradeFireRateStatic = upgradeFireRate;
        upgradeRangeStatic = upgradeRange;

        Tower3Name = "Tower3/freeze";
        Tower3LevelStat = "Level: " + Tower3LevelStatic;
        Tower3LevelStatUpgrade = upgradeLevelStatic;
        Tower3Optionally = "";
        Tower3Stats1 = "Price: " + Tower3CostStatic;
        Tower3Stats1Upgrade = upgradeCostStatic;
        Tower3Stats2 = "Damage: " + Tower3DamageStatic;
        Tower3Stats2Upgrade = upgradeDamageStatic;
        Tower3Stats3 = "FireRatio: " + Tower3FireRateStatic / 1 + " /s";
        Tower3Stats3Upgrade = "";
        Tower3Stats4 = "Range: " + Tower3RangeStatic;
        Tower3Stats4Upgrade = upgradeRangeStatic;
        Tower3Stats5 = "Type: Ground & Air";
        Tower3Stats5Upgrade = "";

        Tower3circleRangeScale.x = range * 2;
        Tower3circleRangeScale.z = range * 2;
    }
}
