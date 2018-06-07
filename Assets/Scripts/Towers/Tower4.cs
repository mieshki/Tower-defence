using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower4 : MonoBehaviour {

    private Transform target;

    [Header("Attributes")]
    public static int Tower4Level = GameStats.Tower4Level;
    public static float Tower4Cost = GameStats.Tower4Cost;
    private static float range = GameStats.Tower4Range;
    private static float fireRate = GameStats.Tower4FireRate;
    public static float Tower4Damage = GameStats.Tower4Damage;

    //public float idleRotationSpeed = 80f;

    public string upgradeLevel = "";
    public string upgradeCost = "";
    public string upgradeDamage = "";
    public string upgradeFireRate = "";
    public string upgradeRange = "";


    public static int Tower4LevelStatic = GameStats.Tower4Level;
    public static float Tower4CostStatic = GameStats.Tower4Cost;
    public static float Tower4DamageStatic = GameStats.Tower4Damage;
    public static float Tower4RangeStatic = GameStats.Tower4Range;
    public static float Tower4FireRateStatic = GameStats.Tower4FireRate;

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



    [Header("Tower4 Stats Informations")]
    public Sprite Tower4Avatar;
    public static string Tower4Name = "Tower4";
    public static string Tower4LevelStat = "Level: " + Tower4LevelStatic;
    public static string Tower4LevelStatUpgrade = upgradeLevelStatic;
    public static string Tower4Optionally = "";
    public static string Tower4Stats1 = "Price: " + Tower4CostStatic;
    public static string Tower4Stats1Upgrade = upgradeCostStatic;
    public static string Tower4Stats2 = "Damage: " + Tower4DamageStatic;
    public static string Tower4Stats2Upgrade = upgradeDamageStatic;
    public static string Tower4Stats3 = "FireRatio: " + Tower4FireRateStatic / 1 + " /s";
    public static string Tower4Stats3Upgrade = "";
    public static string Tower4Stats4 = "Range: " + Tower4RangeStatic;
    public static string Tower4Stats4Upgrade = upgradeRangeStatic;
    public static string Tower4Stats5 = "";
    public static string Tower4Stats5Upgrade = "";



    public Vector3 Tower4circleRangePos;
    public Vector3 Tower4circleRangeScale;


    void Awake()
    {
        Tower4Level = GameStats.Tower4Level;
        Tower4Cost = GameStats.Tower4Cost;
        Tower4Damage = GameStats.Tower4Damage;
        range = GameStats.Tower4Range;
        fireRate = GameStats.Tower4FireRate;

        UpdateInfo();
    }


    // Use this for initialization
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
                else
                {

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
    void Update () {
        Tower4circleRangePos = new Vector3(transform.position.x, -0.5f, transform.position.z);
        Tower4circleRangeScale.x = range * 2;
        Tower4circleRangeScale.z = range * 2;





        if (fireCountdown >= 0f)
        {
            fireCountdown -= Time.deltaTime;
        }    
        else
        {

        }




        if (gameObject.tag == "turretAbleToShoot")
        {

		    if (target == null)
            {
                //transform.eulerAngles += new Vector3(0, idleRotationSpeed * Time.deltaTime, 0);
                return;
            }

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
        bullet.name = Tower4Damage.ToString();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
        
        
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "checkingGO")
        {
            UpdateUIStats();
        }
        else
        {
        }

    }


    public void UpdateUIStats()
    {


        UpdateInfo();

        MenuButtons.UpdateUIStatsInfo(Tower4Avatar, Tower4Name, Tower4LevelStat, Tower4LevelStatUpgrade, Tower4Optionally, Tower4Stats1, Tower4Stats1Upgrade, Tower4Stats2, Tower4Stats2Upgrade, Tower4Stats3, Tower4Stats3Upgrade, Tower4Stats4, Tower4Stats4Upgrade, Tower4Stats5, Tower4Stats5Upgrade);
        MenuButtons.UIStatsEnemyEnabled = false;
        MenuButtons.UIStatsEnabled = true;
        MenuButtons.UIUpgradeAndSellButtonToggle = true;

        MenuButtons.towerToDo = gameObject;

        PublicGameobjects.showRange = true;
        PublicGameobjects.circleRangePos = Tower4circleRangePos;
        PublicGameobjects.circleRangeScale = Tower4circleRangeScale;
    }

    public void UpdateInfo()
    {
        Tower4Level = GameStats.Tower4Level;
        Tower4Cost = GameStats.Tower4Cost;
        Tower4Damage = GameStats.Tower4Damage;
        range = GameStats.Tower4Range;
        fireRate = GameStats.Tower4FireRate;

        /*
        if (Tower1Level == 1)
        {
            upgradeLevel = "+1";
            upgradeCost = "+14$";
            upgradeDamage = "+6";
            upgradeFireRate = "";
            upgradeRange = "+1.5";
        }
        else if (Tower1Level == 2)
        {
            upgradeLevel = "+1";
            upgradeCost = "+50$";
            upgradeDamage = "+22";
            upgradeFireRate = "";
            upgradeRange = "+1.5";
        }
        else if (Tower1Level == 3)
        {
            upgradeLevel = "+1";
            upgradeCost = "+90$";
            upgradeDamage = "+40";
            upgradeFireRate = "";
            upgradeRange = "+4";
        }
        else if (Tower1Level == 4)
        {
            upgradeLevel = "+1";
            upgradeCost = "+180$";
            upgradeDamage = "+80";
            upgradeFireRate = "";
            upgradeRange = "+7";
        }
        else if (Tower1Level == 5)
        {
            upgradeLevel = "";
            upgradeCost = "";
            upgradeDamage = "";
            upgradeFireRate = "";
            upgradeRange = "";
        }
        */

        upgradeLevelStatic = upgradeLevel;
        upgradeCostStatic = upgradeCost;
        upgradeDamageStatic = upgradeDamage;
        upgradeFireRateStatic = upgradeFireRate;
        upgradeRangeStatic = upgradeRange;

        Tower4Name = "Tower4";
        Tower4LevelStat = "Level: " + Tower4LevelStatic;
        Tower4LevelStatUpgrade = upgradeLevelStatic;
        Tower4Optionally = "";
        Tower4Stats1 = "Price: " + Tower4CostStatic;
        Tower4Stats1Upgrade = upgradeCostStatic;
        Tower4Stats2 = "Damage: " + Tower4DamageStatic;
        Tower4Stats2Upgrade = upgradeDamageStatic;
        Tower4Stats3 = "FireRatio: " + Tower4FireRateStatic / 1 + " /s";
        Tower4Stats3Upgrade = "";
        Tower4Stats4 = "Range: " + Tower4RangeStatic;
        Tower4Stats4Upgrade = upgradeRangeStatic;
        Tower4Stats5 = "";
        Tower4Stats5Upgrade = "";

        Tower4circleRangeScale.x = range * 2;
        Tower4circleRangeScale.z = range * 2;
    }



}
