using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickPositionManager : MonoBehaviour {

    public GameObject turret1Prefab;
    public GameObject turret2Prefab;
    public GameObject turret3Prefab;
    public GameObject turret4Prefab;

    public static GameObject turret1GO;
    public static GameObject turret2GO;
    public static GameObject turret3GO;
    public static GameObject turret4GO;

    public LayerMask emptySlotMask;

    Vector3 clickPosition;
    private string colliderName;

    private GameObject turretRespawn;

    void Start()
    {
        turret1GO = turret1Prefab;
        turret2GO = turret2Prefab;
        turret3GO = turret3Prefab;
        turret4GO = turret4Prefab;
    }

    void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, emptySlotMask))
            {
                if (hit.collider.tag == "EmptySlot" && !EventSystem.current.IsPointerOverGameObject())
                {
                    clickPosition = hit.collider.GetComponent<Renderer>().bounds.center;
                    clickPosition.y = -0.45f;

                        if (Nodes.turret1 && GameStats.money >= GameStats.Tower1Cost)
                        {
                            turretRespawn = Instantiate(turret1GO, clickPosition, transform.rotation);
                            Destroy(Nodes.tower1Slot);
                            Nodes.turret1 = false;
                            hit.collider.tag = "BusySlot";
                            unlockTurret();
                            GameStats.money -= GameStats.Tower1Cost;
                        }
                        else if (Nodes.turret2 && GameStats.money >= GameStats.Tower2Cost)
                        {
                            turretRespawn = Instantiate(turret2GO, clickPosition, transform.rotation);
                            Destroy(Nodes.tower2Slot);
                            Nodes.turret2 = false;
                            hit.collider.tag = "BusySlot";
                            unlockTurret();
                            GameStats.money -= GameStats.Tower2Cost;
                        }
                        else if (Nodes.turret3 && GameStats.money >= GameStats.Tower3Cost)
                        {
                            turretRespawn = Instantiate(turret3GO, clickPosition, transform.rotation);
                            Destroy(Nodes.tower3Slot);
                            Nodes.turret3 = false;
                            hit.collider.tag = "BusySlot";
                            unlockTurret();
                            GameStats.money -= GameStats.Tower3Cost;
                        }
                        else if (Nodes.turret4 && GameStats.money >= GameStats.Tower4Cost)
                        {
                            turretRespawn = Instantiate(turret4GO, clickPosition, transform.rotation);
                            Destroy(Nodes.tower4Slot);
                            Nodes.turret4 = false;
                            hit.collider.tag = "BusySlot";
                            unlockTurret();
                            GameStats.money -= GameStats.Tower4Cost;
                        }
                        else
                                turretRespawn = null;
                }


                else if (hit.collider.tag == "BusySlot" && !EventSystem.current.IsPointerOverGameObject())
                {
                    //
                }
                else
                {
                    Nodes.turret1 = false;
                    Nodes.turret2 = false;
                    Nodes.turret3 = false;
                    Nodes.turret4 = false;
                }
            }
        }  
    }
    
    void unlockTurret()
    {
        turretRespawn.tag = "turretAbleToShoot";       
        Nodes.alreadyRespawned = true;
        MenuButtons.UIStatsTowerEnabled = false;
        MenuButtons.UIStatsEnabled = false;
        PublicGameobjects.showRangeNewTurret = false;
    }
}

