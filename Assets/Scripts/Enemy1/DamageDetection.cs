using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDetection : MonoBehaviour {

    public float life;
    private float maxLife;
    public float multiplier;

    public Image healthBar;

    public float worth = GameStats.moneyForKill;

    public static float damage = 0f;


    public bool sendInfo = false;


    public bool isChecked = false;
    private bool isAlive = true;


    public Sprite avatar;
    public string name;
    public string level;
    public string optionally;
    public string stats1;
    public string stats2;
    public string stats3;
    public string stats4;
    public string stats5;




    // Use this for initialization
    void Start () {
        worth = GameStats.moneyForKill;

        //life = GameStats.Enemy1Life;

        //life = GameStats.allEnemyStartLife;

        //multiplier = GameStats.Enemy1LifeMultiplier;


        life = Mathf.Round(GameStats.allEnemyLastLife * GameStats.allEnemyLifeMultiplier);

        maxLife = life;

        GameStats.actualLife = life;
	}




    public float dmg;

    // Update is called once per frame
    void Update () {

        



        if (sendInfo && MenuButtons.UIStatsEnemyEnabled)
        {
            MenuButtons.UIStatsEnabled = true;
            MenuButtons.UpdateUIStatsInfo(GameStats.Enemy1AvatarStatic, GameStats.Enemy1Name, "", "", "", "Life: " + life + "/" + maxLife, "", "Speed: " + gameObject.GetComponent<EnemyMovement>().enemySpeed.ToString(), "", "Worth: " + worth + "$", "", "", "", "", "");
        }
        else
        {
            sendInfo = false;
        }

        if (!MenuButtons.UIStatsEnemyEnabled)
        {
            isChecked = false;
        }
        

    }

    private bool spawnedAOE = false;
    private bool spawnedAOEFreeze = false;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "AOEBOOM")
        {
            spawnedAOE = false;
        }

        if (other.tag == "AOEFREEZE")
        {
            spawnedAOEFreeze = false;
        }

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "checkingGO")
        {
            Destroy(other.gameObject);

            sendInfo = true;
            MenuButtons.UIStatsEnemyEnabled = true;


            //PublicGameobjects.showRange = true;
            //PublicGameobjects.circleRangePos = Tower1circleRangePos;
            //PublicGameobjects.circleRangeScale = Tower1circleRangeScale;

            isChecked = true;
        }
        else
        {
            
        }




        if (other.tag == "AOEBOOM")
        {
            if (!spawnedAOE)
            {
                float damageAOE = int.Parse(other.name);


                Vector3 AOEBOOMCenter = other.GetComponent<Renderer>().bounds.center;

                Vector3 distanceToBOOMCenter = transform.position - AOEBOOMCenter;

                float damageScaleX = Mathf.Abs(distanceToBOOMCenter.x / GameStats.Tower2AOEScaleSize);
                float damageScaleZ = Mathf.Abs(distanceToBOOMCenter.z / GameStats.Tower2AOEScaleSize);

                float damageScale = Mathf.Pow(damageScaleX, 2) + Mathf.Pow(damageScaleZ, 2);
                damageScale = Mathf.Sqrt(damageScale);

                damageScale = 1 - damageScale;

                //Debug.Log("vektor: " + distanceToBOOMCenter);
                //Debug.Log("damageScaleX: " + damageScaleX);
                //Debug.Log("damageScaleZ: " + damageScaleZ);

                //Debug.Log("mnoznik: " + damageScale);

                life -= Mathf.Round(damageAOE * damageScale);
                //Debug.Log("odjeto: " + Mathf.Round(damageAOE * damageScale));
                spawnedAOE = true;
            }
            else
            {
                
            }

        }


        if (other.tag == "AOEFREEZE")
        {
            if (!spawnedAOEFreeze)
            {
                //Debug.Log("freezing");
                StartCoroutine(SlowSpeed());

                float damageAOEFreeze = int.Parse(other.name);


                Vector3 AOEFreezeCenter = other.GetComponent<Renderer>().bounds.center;

                Vector3 distanceToFreezeCenter = transform.position - AOEFreezeCenter;

                float damageScaleX = Mathf.Abs(distanceToFreezeCenter.x / GameStats.Tower3AOEFreezeScaleSize);
                float damageScaleZ = Mathf.Abs(distanceToFreezeCenter.z / GameStats.Tower3AOEFreezeScaleSize);

                float damageScale = Mathf.Pow(damageScaleX, 2) + Mathf.Pow(damageScaleZ, 2);
                damageScale = Mathf.Sqrt(damageScale);

                damageScale = 1 - damageScale;

                //Debug.Log("vektor: " + distanceToBOOMCenter);
                //Debug.Log("damageScaleX: " + damageScaleX);
                //Debug.Log("damageScaleZ: " + damageScaleZ);

                //Debug.Log("mnoznik: " + damageScale);

                life -= Mathf.Round(damageAOEFreeze * damageScale);
                //Debug.Log("odjeto: " + Mathf.Round(damageAOE * damageScale));
                spawnedAOEFreeze = true;
            }
            else
            {

            }
        }





        if (other.tag == "Tower1Missile")
        {
            //damage = Tower1.Tower1DamageStatic;
            damage = int.Parse(other.name);

            life -= damage;
            Destroy(other.gameObject);          
        }
        else if (other.tag == "Tower2Missile")
        {
            damage = int.Parse(other.name);
            life -= damage;
            Destroy(other.gameObject);

            GameObject AoEMissile = Instantiate(PublicGameobjects.AoEDamageGOStatic, transform.position, transform.rotation);
            AoEMissile.name = Mathf.Round((GameStats.Tower2AOEDamageMultiplier * damage)).ToString();
            AoEMissile.transform.localScale = GameStats.Tower2AOEScale;
            spawnedAOE = true;
            Destroy(AoEMissile, 0.1f);                
        }
        else if (other.tag == "Tower3Missile")
        {
            damage = int.Parse(other.name);
            StartCoroutine(SlowSpeed());

            GameObject AoEFreeze = Instantiate(PublicGameobjects.AoEFreezeGOStatic, transform.position, transform.rotation);
            AoEFreeze.name = Mathf.Round((GameStats.Tower3AOEFreezeDamageMultiplier * damage)).ToString();
            AoEFreeze.transform.localScale = GameStats.Tower3AOESFreezecale;
            spawnedAOEFreeze = true;
            Destroy(AoEFreeze, 0.1f);


            life -= damage;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Tower4Missile")
        {
            damage = int.Parse(other.name);
            life -= damage;
            Destroy(other.gameObject);
        }

        healthBar.fillAmount = life / maxLife;
        CheckIfAlive();


        

    }

    IEnumerator SlowSpeed()
    {
        float lastSpeed = gameObject.GetComponent<EnemyMovement>().enemySpeed;
        if (gameObject.GetComponent<EnemyMovement>().enemySpeed == GameStats.Enemy1Speed)
        {
            float newSpeed = gameObject.GetComponent<EnemyMovement>().enemySpeed *= GameStats.Tower3AOEFreezeSpeedScale;
            Mathf.Round(newSpeed);
            gameObject.GetComponent<EnemyMovement>().enemySpeed = newSpeed;
            
        }
        else
        {
            //Debug.Log("juz spowolniony");
        }

        yield return new WaitForSeconds(GameStats.Tower3AOEFreezeTime);

        gameObject.GetComponent<EnemyMovement>().enemySpeed = lastSpeed;

    }





    void CheckIfAlive()
    {
        if (life <= 0)
        {
            sendInfo = false;

            /*
            if (MenuButtons.UIStatsEnemyEnabled)
            {
                MenuButtons.UIStatsEnabled = false;
                
            }
            MenuButtons.UIStatsEnemyEnabled = false;
            */

            if (!MenuButtons.UIStatsTowerEnabled && isChecked)
            {
                MenuButtons.UpdateUIStatsInfo(GameStats.emptyAvatarStatic, "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                MenuButtons.UIStatsEnabled = false;
            }
           

            Destroy(transform.gameObject);

            if (isAlive)
            {
                GameStats.money += worth;
                isAlive = false;
            }
            
            


            //TODO show animated text + x $$
            AddDollarsAnimation();

        }
        else
        {

        }
    }
    
    private GameObject Dollars;
    private TextMesh DollarsText;

    public void AddDollarsAnimation()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
        DollarsText = PublicGameobjects.DollarsIncomeGOStatic.transform.GetChild(0).GetComponent<TextMesh>();
        DollarsText.text = "+" + worth + "$";
        Dollars = Instantiate(PublicGameobjects.DollarsIncomeGOStatic, pos, Quaternion.identity);
        


        Destroy(Dollars, GameStats.dollarsShowTime);

    }


   



    public static void CheckDamage(float dmg)
    {
        damage = dmg;
    }








}
