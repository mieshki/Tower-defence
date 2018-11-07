using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower2 : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]
    public int Tower2Level = GameStats.Tower2Level;
    public float Tower2Cost = GameStats.Tower2Cost;
    public float Tower2Damage = GameStats.Tower2Damage;
    public float range = GameStats.Tower2Range;
    public float fireRate = GameStats.Tower2FireRate;

    public string upgradeLevel = "";
    public string upgradeCost = "";
    public string upgradeDamage = "";
    public string upgradeFireRate = "";
    public string upgradeRange = "";

    public static int Tower2LevelStatic = GameStats.Tower2Level;
    public static float Tower2CostStatic = GameStats.Tower2Cost;
    public static float Tower2DamageStatic = GameStats.Tower2Damage;
    public static float Tower2RangeStatic = GameStats.Tower2Range;
    public static float Tower2FireRateStatic = GameStats.Tower2FireRate;

    public static string upgradeLevelStatic = "+1";
    public static string upgradeCostStatic = "+50$";
    public static string upgradeDamageStatic = "+65";
    public static string upgradeFireRateStatic = "";
    public static string upgradeRangeStatic = "+1";

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    private float fireCountdown = 0f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Tower2 Stats Informations")]
    public Sprite Tower2Avatar;
    public static string Tower2Name = "Tower2";
    public static string Tower2LevelStat = "Level: " + Tower2LevelStatic;
    public static string Tower2LevelStatUpgrade = upgradeLevelStatic;
    public static string Tower2Optionally = "Sell for: " + Mathf.RoundToInt(Tower2CostStatic * GameStats.sellMultiplier) + "$";
    public static string Tower2Stats1 = "Price: " + Tower2CostStatic + "$";
    public static string Tower2Stats1Upgrade = upgradeCostStatic;
    public static string Tower2Stats2 = "Damage: " + Tower2DamageStatic;
    public static string Tower2Stats2Upgrade = upgradeDamageStatic;
    public static string Tower2Stats3 = "FireRatio: " + Tower2FireRateStatic / 1 + " /s";
    public static string Tower2Stats3Upgrade = "";
    public static string Tower2Stats4 = "Range: " + Tower2RangeStatic;
    public static string Tower2Stats4Upgrade = upgradeRangeStatic;
    public static string Tower2Stats5 = "Type: Ground & Air";
    public static string Tower2Stats5Upgrade = "";

    public Vector3 Tower2circleRangePos;
    public Vector3 Tower2circleRangeScale;

    void Awake()
    {
        Tower2Level = GameStats.Tower2Level;
        Tower2Cost = GameStats.Tower2Cost;
        Tower2Damage = GameStats.Tower2Damage;
        range = GameStats.Tower2Range;
        fireRate = GameStats.Tower2FireRate;
        UpdateInfo();
        MenuButtons.chooseTower2();
    }

    void Start()
    {
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
    void Update()
    {
        Tower2circleRangePos = new Vector3(transform.position.x, -0.5f, transform.position.z);
        Tower2circleRangeScale.x = range * 2;
        Tower2circleRangeScale.z = range * 2;

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

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        }
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.name = Tower2Damage.ToString();

        if (bullet != null)
            bullet.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public bool showRange = false;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "checkingGO")
            UpdateUIStats();
    }

    public void UpdateUIStats()
    {
        UpdateInfo();
        MenuButtons.UpdateUIStatsInfo(Tower2Avatar, Tower2Name, Tower2LevelStat, Tower2LevelStatUpgrade, Tower2Optionally, Tower2Stats1, Tower2Stats1Upgrade, Tower2Stats2, Tower2Stats2Upgrade, Tower2Stats3, Tower2Stats3Upgrade, Tower2Stats4, Tower2Stats4Upgrade, Tower2Stats5, Tower2Stats5Upgrade);
        MenuButtons.UIStatsEnemyEnabled = false;
        MenuButtons.UIStatsEnabled = true;
        MenuButtons.UIUpgradeAndSellButtonToggle = true;
        MenuButtons.towerToDo = gameObject;
        PublicGameobjects.showRange = true;
        PublicGameobjects.circleRangePos = Tower2circleRangePos;
        PublicGameobjects.circleRangeScale = Tower2circleRangeScale;
    }

    public void UpdateInfo()
    {
        Tower2LevelStatic = Tower2Level;
        Tower2CostStatic = Tower2Cost;
        Tower2DamageStatic = Tower2Damage;
        Tower2RangeStatic = range;
        Tower2FireRateStatic = fireRate;
        
        if (Tower2Level == 1)
        {
            upgradeLevel = "+1";
            upgradeCost = "+50$";
            upgradeDamage = "+65";
            upgradeFireRate = "";
            upgradeRange = "+1";
            MenuButtons.UIUpgradeShowUpgradeButton = true;
        }
        else if (Tower2Level == 2)
        {
            upgradeLevel = "+1";
            upgradeCost = "+100$";
            upgradeDamage = "+145";
            upgradeFireRate = "";
            upgradeRange = "+1";
            MenuButtons.UIUpgradeShowUpgradeButton = true;
        }
        else if (Tower2Level == 3)
        {
            upgradeLevel = "+1";
            upgradeCost = "+90$";
            upgradeDamage = "+40";
            upgradeFireRate = "";
            upgradeRange = "+4";
            MenuButtons.UIUpgradeShowUpgradeButton = true;
        }
        else if (Tower2Level == 4)
        {
            upgradeLevel = "+1";
            upgradeCost = "+200$";
            upgradeDamage = "+220";
            upgradeFireRate = "";
            upgradeRange = "+1";
            MenuButtons.UIUpgradeShowUpgradeButton = true;
        }
        else if (Tower2Level == 5)
        {
            upgradeLevel = "max";
            upgradeCost = "max";
            upgradeDamage = "max";
            upgradeFireRate = "";
            upgradeRange = "max";
            MenuButtons.UIUpgradeShowUpgradeButton = false;
        }
        
        upgradeLevelStatic = upgradeLevel;
        upgradeCostStatic = upgradeCost;
        upgradeDamageStatic = upgradeDamage;
        upgradeFireRateStatic = upgradeFireRate;
        upgradeRangeStatic = upgradeRange;

        Tower2Name = "Tower2";
        Tower2LevelStat = "Level: " + Tower2LevelStatic;
        Tower2LevelStatUpgrade = upgradeLevelStatic;
        Tower2Optionally = "Sell for: " + Mathf.RoundToInt(Tower2CostStatic * GameStats.sellMultiplier) + "$";
        Tower2Stats1 = "Price: " + Tower2CostStatic + "$";
        Tower2Stats1Upgrade = upgradeCostStatic;
        Tower2Stats2 = "Damage: " + Tower2DamageStatic;
        Tower2Stats2Upgrade = upgradeDamageStatic;
        Tower2Stats3 = "FireRatio: " + Tower2FireRateStatic / 1 + " /s";
        Tower2Stats3Upgrade = "";
        Tower2Stats4 = "Range: " + Tower2RangeStatic;
        Tower2Stats4Upgrade = upgradeRangeStatic;
        Tower2Stats5 = "Type: Ground & Air";
        Tower2Stats5Upgrade = "";

        Tower2circleRangeScale.x = range * 2;
        Tower2circleRangeScale.z = range * 2;
    }
}
