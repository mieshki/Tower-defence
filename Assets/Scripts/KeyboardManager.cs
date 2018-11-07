using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardManager : MonoBehaviour {

    void CheckForHideStats()
    {
        if (Input.GetMouseButtonDown(0))
        {          
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.collider.tag != "BusySlot" && !EventSystem.current.IsPointerOverGameObject())
                {
                    MenuButtons.UIStatsEnabled = false;
                    MenuButtons.UIStatsEnemyEnabled = false;
                    MenuButtons.UIStatsTowerEnabled = false;
                    MenuButtons.UIUpgradeAndSellButtonToggle = false;
                    MenuButtons.towerToDo = null;
                    PublicGameobjects.showRange = false;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            MenuButtons.UIStatsEnabled = false;
            MenuButtons.UIStatsEnemyEnabled = false;
            MenuButtons.UIStatsTowerEnabled = false;
            MenuButtons.UIUpgradeAndSellButtonToggle = false;
            MenuButtons.towerToDo = null;
            PublicGameobjects.showRange = false;
        }
    }
	
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            Nodes.turret1 = false;
            Nodes.turret2 = false;
            Nodes.turret3 = false;
            Nodes.turret4 = false;
        }

        if (Input.GetKeyDown("1"))
        {
            SetOthersToFalse();
            MenuButtons.chooseTower1();
        }
        if (Input.GetKeyDown("2"))
        {
            SetOthersToFalse();
            MenuButtons.chooseTower2();
        }
        if (Input.GetKeyDown("3"))
        {
            SetOthersToFalse();
            MenuButtons.chooseTower3();
        }
        if (Input.GetKeyDown("4"))
        {
            SetOthersToFalse();
            MenuButtons.chooseTower4();
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!MenuButtons.UIStatsEnabled && !MenuButtons.UIStatsEnemyEnabled)
            { 
                if (Time.timeScale == 1)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            }


            if (MenuButtons.UIStatsEnabled)
            {
                MenuButtons.UIStatsEnabled = false;
                MenuButtons.UIStatsEnemyEnabled = false;
                MenuButtons.UIStatsTowerEnabled = false;
                MenuButtons.UIUpgradeAndSellButtonToggle = false;
                MenuButtons.towerToDo = null;
                Nodes.turret1 = false;
                Nodes.turret2 = false;
                Nodes.turret3 = false;
                Nodes.turret4 = false;

            }
            if (PublicGameobjects.showRange)
                PublicGameobjects.showRange = false;  
        }

        CheckForHideStats();
    }

    public static void SetOthersToFalse()
    {
        Nodes.turret1 = false;
        Nodes.turret2 = false;
        Nodes.turret3 = false;
        Nodes.turret4 = false;
    } 
}
