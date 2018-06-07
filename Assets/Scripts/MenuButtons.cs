using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour
{

    public Sprite Tower1Avatar;
    public Sprite Tower2Avatar;
    public Sprite Tower3Avatar;
    public Sprite Tower4Avatar;

    public static Sprite Tower1AvatarStatic;
    public static Sprite Tower2AvatarStatic;
    public static Sprite Tower3AvatarStatic;
    public static Sprite Tower4AvatarStatic;


    // MENU UI SETUP
    [Header("Menu UI Setup")]
    public Text lifesText;
    public Text moneyText;
    public Text waveNumberText;
    public Text timeToNextWaveText;


    public Button tower1Button;
    public Text tower1Name;
    public Text tower1Cost;


    public Button tower2Button;
    public Text tower2Name;
    public Text tower2Cost;

    public Button tower3Button;
    public Text tower3Name;
    public Text tower3Cost;

    public Button tower4Button;
    public Text tower4Name;
    public Text tower4Cost;


    public Button nextWaveButton;
    public Text nextWaveText;

    public Button quitButton;

    //moja lopata
    public GameObject checkGO;
    public static GameObject checkGO_spawned;


    // STATS UI SETUP
    [Header("Stats UI Setup")]
    public GameObject StatsUI;
    public static bool UIStatsEnabled = false;
    public static bool UIStatsEnemyEnabled = false;
    public static bool UIStatsTowerEnabled = false;
    public static bool UIUpgradeAndSellButtonToggle = false;
    public static bool UIUpgradeShowUpgradeButton = false;


    public Image AvatarImage;
    public Text Label1Text;
    public Text Label2Text;
    public Text Label2TextUpgrade;
    public Text Label3Text;
    public Text Label4Text;
    public Text Label4TextUpgrade;
    public Text Label5Text;
    public Text Label5TextUpgrade;
    public Text Label6Text;
    public Text Label6TextUpgrade;
    public Text Label7Text;
    public Text Label7TextUpgrade;
    public Text Label8Text;
    public Text Label8TextUpgrade;

    public Button UpgradeButton;
    public Button SellButton;



    public static Sprite Avatar;
    public static Text Label1;
    public static Text Label2;
    public static Text Label2Upgrade;
    public static Text Label3;
    public static Text Label4;
    public static Text Label4Upgrade;
    public static Text Label5;
    public static Text Label5Upgrade;
    public static Text Label6;
    public static Text Label6Upgrade;
    public static Text Label7;
    public static Text Label7Upgrade;
    public static Text Label8;
    public static Text Label8Upgrade;

    public static Button UpgradeButtonStatic;
    public static Button SellButtonStatic;


    public static GameObject towerToDo;

    // Use this for initialization
    void Start()
    {
        Tower1AvatarStatic = Tower1Avatar;
        Tower2AvatarStatic = Tower2Avatar;
        Tower3AvatarStatic = Tower3Avatar;
        Tower4AvatarStatic = Tower4Avatar;

        UpgradeButtonStatic = UpgradeButton;
        SellButtonStatic = SellButton;



        Button tower1 = tower1Button.GetComponent<Button>();
        tower1.onClick.AddListener(chooseTower1);

        Button tower2 = tower2Button.GetComponent<Button>();
        tower2.onClick.AddListener(chooseTower2);

        Button tower3 = tower3Button.GetComponent<Button>();
        tower3.onClick.AddListener(chooseTower3);

        Button tower4 = tower4Button.GetComponent<Button>();
        tower4.onClick.AddListener(chooseTower4);




        Button nextWave = nextWaveButton.GetComponent<Button>();
        nextWave.onClick.AddListener(nextWaveToDo);

        Button quit = quitButton.GetComponent<Button>();
        quit.onClick.AddListener(QuitToMenu);


        Avatar = AvatarImage.sprite;
        Label1 = Label1Text;
        Label2 = Label2Text;
        Label2Upgrade = Label2TextUpgrade;
        Label3 = Label3Text;
        Label4 = Label4Text;
        Label4Upgrade = Label4TextUpgrade;
        Label5 = Label5Text;
        Label5Upgrade = Label5TextUpgrade;
        Label6 = Label6Text;
        Label6Upgrade = Label6TextUpgrade;
        Label7 = Label7Text;
        Label7Upgrade = Label7TextUpgrade;
        Label8 = Label8Text;
        Label8Upgrade = Label8TextUpgrade;


        Button upgradeButton = UpgradeButton.GetComponent<Button>();
        upgradeButton.onClick.AddListener(UpgradeTower);

        Button sellButton = SellButton.GetComponent<Button>();
        sellButton.onClick.AddListener(SellTower);

    }

    void UpgradeTower()
    {
        /////////////////// TOWER1 UPGRADES

        if (towerToDo != null && towerToDo.name == "Tower1(Clone)")
        {
            if (towerToDo.GetComponent<Tower1>().Tower1Level == 1 && GameStats.money >= 14f)
            {
                GameStats.money -= 14f;
                towerToDo.GetComponent<Tower1>().Tower1Cost += 14f;

                towerToDo.GetComponent<Tower1>().Tower1Damage += 6f;
                towerToDo.GetComponent<Tower1>().range += 1.5f;
                towerToDo.GetComponent<Tower1>().Tower1Level++;
                towerToDo.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);

                towerToDo.GetComponent<Tower1>().UpdateUIStats();
            }
            else if (towerToDo.GetComponent<Tower1>().Tower1Level == 2 && GameStats.money >= 50f)
            {
                GameStats.money -= 50f;
                towerToDo.GetComponent<Tower1>().Tower1Cost += 50f;

                towerToDo.GetComponent<Tower1>().Tower1Damage += 22f;
                towerToDo.GetComponent<Tower1>().range += 2f;
                towerToDo.GetComponent<Tower1>().Tower1Level++;
                towerToDo.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);


                towerToDo.GetComponent<Tower1>().UpdateUIStats();
            }
            else if (towerToDo.GetComponent<Tower1>().Tower1Level == 3 && GameStats.money >= 90f)
            {
                GameStats.money -= 90f;
                towerToDo.GetComponent<Tower1>().Tower1Cost += 90f;

                towerToDo.GetComponent<Tower1>().Tower1Damage += 40f;
                towerToDo.GetComponent<Tower1>().range += 2.5f;
                towerToDo.GetComponent<Tower1>().Tower1Level++;
                towerToDo.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);


                towerToDo.GetComponent<Tower1>().UpdateUIStats();
            }
            else if (towerToDo.GetComponent<Tower1>().Tower1Level == 4 && GameStats.money >= 180f)
            {
                GameStats.money -= 180f;
                towerToDo.GetComponent<Tower1>().Tower1Cost += 180f;

                towerToDo.GetComponent<Tower1>().Tower1Damage += 80f;
                towerToDo.GetComponent<Tower1>().range += 3f;
                towerToDo.GetComponent<Tower1>().Tower1Level++;
                towerToDo.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);


                towerToDo.GetComponent<Tower1>().UpdateUIStats();
            }
            else
            {
                //Debug.Log("upgraded max");
            }
        }

        /////////////////// TOWER2 UPGRADES

        if (towerToDo != null && towerToDo.name == "Tower2(Clone)")
        {
            if (towerToDo.GetComponent<Tower2>().Tower2Level == 1 && GameStats.money >= 50f)
            {
                GameStats.money -= 50f;
                towerToDo.GetComponent<Tower2>().Tower2Cost += 50f;

                towerToDo.GetComponent<Tower2>().Tower2Damage += 65f;
                towerToDo.GetComponent<Tower2>().range += 1f;
                towerToDo.GetComponent<Tower2>().Tower2Level++;
                towerToDo.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);

                towerToDo.GetComponent<Tower2>().UpdateUIStats();
            }
            else if (towerToDo.GetComponent<Tower2>().Tower2Level == 2 && GameStats.money >= 100f)
            {
                GameStats.money -= 100f;
                towerToDo.GetComponent<Tower2>().Tower2Cost += 100f;

                towerToDo.GetComponent<Tower2>().Tower2Damage += 145f;
                towerToDo.GetComponent<Tower2>().range += 1f;
                towerToDo.GetComponent<Tower2>().Tower2Level++;
                towerToDo.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);

                towerToDo.GetComponent<Tower2>().UpdateUIStats();
            }
            else if (towerToDo.GetComponent<Tower2>().Tower2Level == 3 && GameStats.money >= 200f)
            {
                GameStats.money -= 200f;
                towerToDo.GetComponent<Tower2>().Tower2Cost += 200f;

                towerToDo.GetComponent<Tower2>().Tower2Damage += 220f;
                towerToDo.GetComponent<Tower2>().range += 1f;
                towerToDo.GetComponent<Tower2>().Tower2Level++;
                towerToDo.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);

                towerToDo.GetComponent<Tower2>().UpdateUIStats();
            }
            else if (towerToDo.GetComponent<Tower2>().Tower2Level == 4 && GameStats.money >= 300f)
            {
                GameStats.money -= 300f;
                towerToDo.GetComponent<Tower2>().Tower2Cost += 300f;

                towerToDo.GetComponent<Tower2>().Tower2Damage += 340f;
                towerToDo.GetComponent<Tower2>().range += 1f;
                towerToDo.GetComponent<Tower2>().Tower2Level++;
                towerToDo.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);

                towerToDo.GetComponent<Tower2>().UpdateUIStats();
            }
            else
            {
                Debug.Log("upgraded max");
            }



        }



    }

    void SellTower()
    {
        if(towerToDo != null)
        {

            Vector3 pos = new Vector3(towerToDo.transform.position.x, towerToDo.transform.position.y, towerToDo.transform.position.z);
            GameObject TowerSellCheckGO = Instantiate(PublicGameobjects.TowerSellCheckSlotGOStatic, pos, towerToDo.transform.rotation);

            if(towerToDo.name == "Tower1(Clone)")
            {
                GameStats.money += Mathf.RoundToInt(GameStats.sellMultiplier * towerToDo.GetComponent<Tower1>().Tower1Cost);
            }
            else if(towerToDo.name == "Tower2(Clone)")
            {
                GameStats.money += Mathf.RoundToInt(GameStats.sellMultiplier * towerToDo.GetComponent<Tower2>().Tower2Cost);
            }
            

            MenuButtons.UIStatsEnabled = false;
            MenuButtons.UIStatsEnemyEnabled = false;
            MenuButtons.UIStatsTowerEnabled = false;
            MenuButtons.UIUpgradeAndSellButtonToggle = false;
            PublicGameobjects.showRange = false;

            Destroy(towerToDo);
            MenuButtons.towerToDo = null;
            Destroy(TowerSellCheckGO, 0.5f);

            

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (UIStatsTowerEnabled && UIUpgradeAndSellButtonToggle)
        {
            if (UIUpgradeShowUpgradeButton)
            {
                UpgradeButton.gameObject.SetActive(true);
            }
            else
            {
                UpgradeButton.gameObject.SetActive(false);
            }
            
            SellButton.gameObject.SetActive(true);
        }
        else
        {
            UpgradeButton.gameObject.SetActive(false);
            SellButton.gameObject.SetActive(false);
        }


        CheckForTurret();


        lifesText.text = "Lifes: " + GameStats.lifes;
        moneyText.text = "Money: " + GameStats.money + "$";
        waveNumberText.text = "Wave: " + WaveSpawning.waveIndex;
        timeToNextWaveText.text = "Countdown: " + WaveSpawning.breakBetweenFirstWave.ToString("0");



        tower1Name.text = Tower1.Tower1Name;
        tower1Cost.text = "Cost: " + GameStats.Tower1Cost + "$";

        tower2Name.text = Tower2.Tower2Name;
        tower2Cost.text = "Cost: " + GameStats.Tower2Cost + "$";

        tower3Name.text = Tower3.Tower3Name;
        tower3Cost.text = "Cost: " + GameStats.Tower3Cost + "$";

        tower4Name.text = Tower4.Tower4Name;
        tower4Cost.text = "Cost: " + GameStats.Tower4Cost + "$";





        if (Avatar != null)
        {
            AvatarImage.sprite = Avatar;
        }
        

        Label1Text.text = Label1.text;
        Label2Text.text = Label2.text;
        Label3Text.text = Label3.text;
        Label4Text.text = Label4.text;
        Label5Text.text = Label5.text;
        Label6Text.text = Label6.text;
        Label7Text.text = Label7.text;
        Label8Text.text = Label8.text;
        

        
            StatsUI.SetActive(UIStatsEnabled);
        
        


        CheckForTurretHoverOnMenu();
    }


    void CheckForTurretHoverOnMenu()
    {
         /* 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f))
        {
            //clickPosition = hit.point;
            //colliderName = hit.collider.tag;
            //clickPosition = hit.collider.gameObject.transform.position;


            if (hit.collider.tag == "Tower1Menu")
            {
               
            }
        }
        */

    }
    


    public static void UpdateUIStatsInfo(Sprite avatarImg, string label1, string label2, string label2Upgrade, string label3, string label4, string label4Upgrade, string label5, string label5Upgrade, string label6, string label6Upgrade, string label7, string label7Upgrade, string label8, string label8Upgrade)
    {
        Avatar = avatarImg;

        Label1.text = label1;
        Label2.text = label2;
        Label2Upgrade.text = label2Upgrade;
        Label3.text = label3;
        Label4.text = label4;
        Label4Upgrade.text = label4Upgrade;
        Label5.text = label5;
        Label5Upgrade.text = label5Upgrade;
        Label6.text = label6;
        Label6Upgrade.text = label6Upgrade;
        Label7.text = label7;
        Label7Upgrade.text = label7Upgrade;
        Label8.text = label8;
        Label8Upgrade.text = label8Upgrade;

        UIStatsEnabled = true;
    }



    public static void chooseTower1()
    {
        KeyboardManager.SetOthersToFalse();
        Nodes.turret1 = true;
        //Debug.Log("tower 1 pressed");

        MenuButtons.UpdateUIStatsInfo(Tower1AvatarStatic, Tower1.Tower1Name, Tower1.Tower1LevelStat, "", "", Tower1.Tower1Stats1, "", Tower1.Tower1Stats2, "", Tower1.Tower1Stats3, "", Tower1.Tower1Stats4, "", Tower1.Tower1Stats5, "");
        MenuButtons.UIStatsEnemyEnabled = false;
        MenuButtons.UIStatsEnabled = true;
        UIStatsTowerEnabled = true;

        PublicGameobjects.showRange = false;
    }

    public static void chooseTower2()
    {
        KeyboardManager.SetOthersToFalse();
        Nodes.turret2 = true;
        //Debug.Log("tower 2 pressed");

        MenuButtons.UpdateUIStatsInfo(Tower2AvatarStatic, Tower2.Tower2Name, Tower2.Tower2LevelStat, "", Tower2.Tower2Optionally, Tower2.Tower2Stats1, "", Tower2.Tower2Stats2, "", Tower2.Tower2Stats3, "", Tower2.Tower2Stats4, "", Tower2.Tower2Stats5, "");
        MenuButtons.UIStatsEnemyEnabled = false;
        MenuButtons.UIStatsEnabled = true;
        UIStatsTowerEnabled = true;

        PublicGameobjects.showRange = false;
    }

    public static void chooseTower3()
    {
        KeyboardManager.SetOthersToFalse();
        Nodes.turret3 = true;
        //Debug.Log("tower 3 pressed");

        MenuButtons.UpdateUIStatsInfo(Tower3AvatarStatic, Tower3.Tower3Name, Tower3.Tower3LevelStat, "", Tower3.Tower3Optionally, Tower3.Tower3Stats1, "", Tower3.Tower3Stats2, "", Tower3.Tower3Stats3, "", Tower3.Tower3Stats4, "", Tower3.Tower3Stats5, "");
        MenuButtons.UIStatsEnemyEnabled = false;

        MenuButtons.UIStatsEnabled = true;
        UIStatsTowerEnabled = true;
    }

    public static void chooseTower4()
    {
        KeyboardManager.SetOthersToFalse();
        Nodes.turret4 = true;
        //Debug.Log("tower 4 pressed");



        MenuButtons.UpdateUIStatsInfo(Tower4AvatarStatic, Tower4.Tower4Name, Tower4.Tower4LevelStat, "", Tower4.Tower4Optionally, Tower4.Tower4Stats1, "", Tower4.Tower4Stats2, "", Tower4.Tower4Stats3, "", Tower4.Tower4Stats4, "", Tower4.Tower4Stats5, "");
        MenuButtons.UIStatsEnemyEnabled = false;


        MenuButtons.UIStatsEnabled = true;
        UIStatsTowerEnabled = true;
    }



    void nextWaveToDo()
    {
        if(WaveSpawning.gameStarted == true && WaveSpawning.ableToNextWave)
        {
            WaveSpawning.breakBetweenFirstWave = 0f;
            WaveSpawning.ableToNextWave = false;
        }
        else
        {
            WaveSpawning.gameStarted = true;
            nextWaveText.text = "Next wave";
        }

    }




    // klikanie na turreta 
    void CheckForTurret()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //clickPosition = hit.point;
                //colliderName = hit.collider.tag;
                //clickPosition = hit.collider.gameObject.transform.position;


                if (hit.collider.tag == "BusySlot")
                {
                    Vector3 clickPosition = hit.collider.GetComponent<Renderer>().bounds.center;
                    checkGO_spawned = Instantiate(checkGO, clickPosition, transform.rotation);
                    Invoke("DestroyCheckingForTurret", 0.1f);
                    //Debug.Log("turret pressed");
                }
                else if(hit.collider.tag == "Enemy")
                {
                    Vector3 clickPosition = hit.collider.GetComponent<Renderer>().bounds.center;
                    checkGO_spawned = Instantiate(checkGO, clickPosition, transform.rotation);
                    Invoke("DestroyCheckingForTurret", 0.1f);
                    Debug.Log("enemy pressed");
                }

            }
        }
    }


    void DestroyCheckingForTurret()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("checkingGO");
        for(int i = 0; i < gos.Length; i++)
        {
            Destroy(gos[i]);
        }
        //Debug.Log(gos.Length);

        //Destroy(checkGO_spawned);
    }


    void QuitToMenu()
    {
        Application.Quit();
    }


    

    

}
