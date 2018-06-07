using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower1 : MonoBehaviour {

    private Transform target;

    [Header("Attributes")]
    public int Tower1Level = GameStats.Tower1Level;
    public float Tower1Cost = GameStats.Tower1Cost;
    public float Tower1Damage = GameStats.Tower1Damage;
    public float range = GameStats.Tower1Range;
    public float fireRate = GameStats.Tower1FireRate;


    //public float idleRotationSpeed = 80f;

    public string upgradeLevel = "+1";
    public string upgradeCost = "+14$";
    public string upgradeDamage = "+6";
    public string upgradeFireRate = "";
    public string upgradeRange = "+1.5";




    public static int Tower1LevelStatic = GameStats.Tower1Level;
    public static float Tower1CostStatic = GameStats.Tower1Cost;
    public static float Tower1DamageStatic = GameStats.Tower1Damage;
    public static float Tower1RangeStatic = GameStats.Tower1Range;
    public static float Tower1FireRateStatic = GameStats.Tower1FireRate;

    public static string upgradeLevelStatic = "+1";
    public static string upgradeCostStatic = "+14$";
    public static string upgradeDamageStatic = "+6";
    public static string upgradeFireRateStatic = "";
    public static string upgradeRangeStatic = "+1.5";



    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;


    private float fireCountdown = 0f;


    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Tower1 Stats Informations")]
    public Sprite Tower1Avatar;
    public static string Tower1Name = "Tower1";
    public static string Tower1LevelStat = "Level: " + Tower1LevelStatic;
    public static string Tower1LevelStatUpgrade = upgradeLevelStatic;
    public static string Tower1Optionally = "Sell for: " + Mathf.RoundToInt(Tower1CostStatic * GameStats.sellMultiplier) + "$";
    public static string Tower1Stats1 = "Price: " + Tower1CostStatic + "$";
    public static string Tower1Stats1Upgrade = upgradeCostStatic;
    public static string Tower1Stats2 = "Damage: " + Tower1DamageStatic;
    public static string Tower1Stats2Upgrade = upgradeDamageStatic;
    public static string Tower1Stats3 = "FireRatio: " + Tower1FireRateStatic / 1 + " /s";
    public static string Tower1Stats3Upgrade = "";
    public static string Tower1Stats4 = "Range: " + Tower1RangeStatic;
    public static string Tower1Stats4Upgrade = upgradeRangeStatic;
    public static string Tower1Stats5 = "Type: Ground & Air";
    public static string Tower1Stats5Upgrade = "";





    public Vector3 Tower1circleRangePos;
    public Vector3 Tower1circleRangeScale;


    void Awake()
    {
        
        Tower1Level = GameStats.Tower1Level;
        Tower1Cost = GameStats.Tower1Cost;
        Tower1Damage = GameStats.Tower1Damage;
        range = GameStats.Tower1Range;
        fireRate = GameStats.Tower1FireRate;
        UpdateInfo();
        MenuButtons.chooseTower1();
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
        

        if (nearestEnemy != null && shortestDistance <= range )
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
    // Update is called once per frame
    void Update () {

        Tower1circleRangePos = new Vector3(transform.position.x, -0.5f, transform.position.z);
        Tower1circleRangeScale.x = range * 2;
        Tower1circleRangeScale.z = range * 2;


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
        bullet.name = Tower1Damage.ToString();

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



    public bool showRange = false;


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "checkingGO")
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

        MenuButtons.UpdateUIStatsInfo(Tower1Avatar, Tower1Name, Tower1LevelStat, Tower1LevelStatUpgrade, Tower1Optionally, Tower1Stats1, Tower1Stats1Upgrade, Tower1Stats2, Tower1Stats2Upgrade, Tower1Stats3, Tower1Stats3Upgrade, Tower1Stats4, Tower1Stats4Upgrade, Tower1Stats5, Tower1Stats5Upgrade);
        MenuButtons.UIStatsEnemyEnabled = false;
        MenuButtons.UIStatsEnabled = true;
        MenuButtons.UIUpgradeAndSellButtonToggle = true;

        MenuButtons.towerToDo = gameObject;

        PublicGameobjects.showRange = true;
        PublicGameobjects.circleRangePos = Tower1circleRangePos;
        PublicGameobjects.circleRangeScale = Tower1circleRangeScale;
    }


    


    public void UpdateInfo()
    {
        Tower1LevelStatic = Tower1Level;
        Tower1CostStatic = Tower1Cost;
        Tower1DamageStatic = Tower1Damage;
        Tower1RangeStatic = range;
        Tower1FireRateStatic = fireRate;

        



        if(Tower1Level == 1)
        {
            upgradeLevel = "+1";
            upgradeCost = "+14$";
            upgradeDamage = "+6";
            upgradeFireRate = "";
            upgradeRange = "+1.5";
            MenuButtons.UIUpgradeShowUpgradeButton = true;
        }
        else if(Tower1Level == 2)
        {
            upgradeLevel = "+1";
            upgradeCost = "+50$";
            upgradeDamage = "+22";
            upgradeFireRate = "";
            upgradeRange = "+1.5";
            MenuButtons.UIUpgradeShowUpgradeButton = true;
        }
        else if (Tower1Level == 3)
        {
            upgradeLevel = "+1";
            upgradeCost = "+90$";
            upgradeDamage = "+40";
            upgradeFireRate = "";
            upgradeRange = "+4";
            MenuButtons.UIUpgradeShowUpgradeButton = true;
        }
        else if (Tower1Level == 4)
        {
            upgradeLevel = "+1";
            upgradeCost = "+180$";
            upgradeDamage = "+80";
            upgradeFireRate = "";
            upgradeRange = "+7";
            MenuButtons.UIUpgradeShowUpgradeButton = true;
        }
        else if(Tower1Level == 5)
        {
            upgradeLevel = "max";
            upgradeCost = "max";
            upgradeDamage = "max";
            upgradeFireRate = "max";
            upgradeRange = "max";
            MenuButtons.UIUpgradeShowUpgradeButton = false;
        }


        upgradeLevelStatic = upgradeLevel;
        upgradeCostStatic = upgradeCost;
        upgradeDamageStatic = upgradeDamage;
        upgradeFireRateStatic = upgradeFireRate;
        upgradeRangeStatic = upgradeRange;





        Tower1Name = "Tower1";
        Tower1LevelStat = "Level: " + Tower1LevelStatic;
        Tower1LevelStatUpgrade = upgradeLevelStatic;
        Tower1Optionally = "Sell for: " + Mathf.RoundToInt(Tower1CostStatic * GameStats.sellMultiplier) + "$";
        Tower1Stats1 = "Price: " + Tower1CostStatic + "$";
        Tower1Stats1Upgrade = upgradeCostStatic;
        Tower1Stats2 = "Damage: " + Tower1DamageStatic;
        Tower1Stats2Upgrade = upgradeDamageStatic;
        Tower1Stats3 = "FireRatio: " + Tower1FireRateStatic / 1 + " /s";
        Tower1Stats3Upgrade = "";
        Tower1Stats4 = "Range: " + Tower1RangeStatic;
        Tower1Stats4Upgrade = upgradeRangeStatic;
        Tower1Stats5 = "Type: Ground & Air";
        Tower1Stats5Upgrade = "";

        Tower1circleRangeScale.x = range * 2;
        Tower1circleRangeScale.z = range * 2;
    }


}
