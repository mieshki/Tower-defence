using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour {


    public Color hoverColorEmpty;
    public Color hoverColorBusy;

    private Renderer rend;
    private Color startColor;
    private Material startMaterial;

    public static bool turret1 = false;
    public static bool turret2 = false;
    public static bool turret3 = false;
    public static bool turret4 = false;



    public static GameObject tower1Slot;
    public static GameObject tower2Slot;
    public static GameObject tower3Slot;
    public static GameObject tower4Slot;

    public static bool alreadyRespawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TowerSellCheckSlot")
        {
            Debug.Log("czyszcze");
            gameObject.tag = "EmptySlot";
        }
        else
        {
            //Debug.Log("lel");
        }


    }


    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();

        //startColor = rend.material.color;

        PublicGameobjects.towerLastMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        
    }

    

    private void OnMouseEnter()
    {
        CheckSlotTagAndColor();
    }

    private void OnMouseOver()
    {
        CheckIfTurretChanged();
        CheckSlotTagAndColor();
    }


    public Vector3 TowerCircleRangePos;
    public Vector3 TowerCircleRangeScale;

    public Vector3 TowerRespawnVector;

    void CheckSlotTagAndColor()
    {
        if (turret1 || turret2 || turret3 || turret4)
        {


            if (gameObject.tag == "EmptySlot")
            {
                //rend.material.color = hoverColorEmpty;

                TowerRespawnVector = GetComponent<Renderer>().bounds.center;
                TowerRespawnVector.y += 0.12f;


                if (turret1)
                {
                    if (tower1Slot == null && alreadyRespawned == false)
                    {
                        MenuButtons.UIUpgradeAndSellButtonToggle = false;
                        tower1Slot = Instantiate(ClickPositionManager.turret1GO, TowerRespawnVector, transform.rotation);

                        TowerCircleRangePos = new Vector3(transform.position.x, -0.5f, transform.position.z);
                        TowerCircleRangeScale.x = GameStats.Tower1Range * 2;
                        TowerCircleRangeScale.z = GameStats.Tower1Range * 2;
                        PublicGameobjects.showRangeNewTurret = true;
                        PublicGameobjects.circleRangePos = TowerCircleRangePos;
                        PublicGameobjects.circleRangeScale = TowerCircleRangeScale;



                        if (GameStats.money >= GameStats.Tower1Cost)
                        {
                            //rend.material.color = hoverColorEmpty;
                            rend.material = PublicGameobjects.towerEmptyMaterialStatic;
                        }
                        else
                        {
                            //rend.material.color = hoverColorBusy;
                            rend.material = PublicGameobjects.towerBusyMaterialStatic;
                        }                       
                    }
                }
                else if (turret2)
                {
                    if (tower2Slot == null && alreadyRespawned == false)
                    {
                        MenuButtons.UIUpgradeAndSellButtonToggle = false;
                        tower2Slot = Instantiate(ClickPositionManager.turret2GO, TowerRespawnVector, transform.rotation);

                        TowerCircleRangePos = new Vector3(transform.position.x, -0.5f, transform.position.z);
                        TowerCircleRangeScale.x = GameStats.Tower2Range * 2;
                        TowerCircleRangeScale.z = GameStats.Tower2Range * 2;
                        PublicGameobjects.showRangeNewTurret = true;
                        PublicGameobjects.circleRangePos = TowerCircleRangePos;
                        PublicGameobjects.circleRangeScale = TowerCircleRangeScale;


                        if (GameStats.money >= GameStats.Tower2Cost)
                        {
                            //rend.material.color = hoverColorEmpty;
                            rend.material = PublicGameobjects.towerEmptyMaterialStatic;

                        }
                        else
                        {
                            //rend.material.color = hoverColorBusy;
                            rend.material = PublicGameobjects.towerBusyMaterialStatic;
                        }
                    }
                }
                else if (turret3)
                {
                    if (tower3Slot == null && alreadyRespawned == false)
                    {
                        tower3Slot = Instantiate(ClickPositionManager.turret3GO, TowerRespawnVector, transform.rotation);

                        TowerCircleRangePos = new Vector3(transform.position.x, -0.5f, transform.position.z);
                        TowerCircleRangeScale.x = GameStats.Tower3Range * 2;
                        TowerCircleRangeScale.z = GameStats.Tower3Range * 2;
                        PublicGameobjects.showRangeNewTurret = true;
                        PublicGameobjects.circleRangePos = TowerCircleRangePos;
                        PublicGameobjects.circleRangeScale = TowerCircleRangeScale;



                        if (GameStats.money >= GameStats.Tower3Cost)
                        {
                            //rend.material.color = hoverColorEmpty;
                            rend.material = PublicGameobjects.towerEmptyMaterialStatic;
                        }
                        else
                        {
                            //rend.material.color = hoverColorBusy;
                            rend.material = PublicGameobjects.towerBusyMaterialStatic;
                        }
                    }
                }
                else if (turret4)
                {
                    if (tower4Slot == null && alreadyRespawned == false)
                    {
                        tower4Slot = Instantiate(ClickPositionManager.turret4GO, TowerRespawnVector, transform.rotation);

                        TowerCircleRangePos = new Vector3(transform.position.x, -0.5f, transform.position.z);
                        TowerCircleRangeScale.x = GameStats.Tower4Range * 2;
                        TowerCircleRangeScale.z = GameStats.Tower4Range * 2;
                        PublicGameobjects.showRangeNewTurret = true;
                        PublicGameobjects.circleRangePos = TowerCircleRangePos;
                        PublicGameobjects.circleRangeScale = TowerCircleRangeScale;


                        if (GameStats.money >= GameStats.Tower4Cost)
                        {
                            //rend.material.color = hoverColorEmpty;
                            rend.material = PublicGameobjects.towerEmptyMaterialStatic;
                        }
                        else
                        {
                            //rend.material.color = hoverColorBusy;
                            rend.material = PublicGameobjects.towerBusyMaterialStatic;
                        }
                    }
                }
                else
                {
                    //PublicGameobjects.showRangeNewTurret = false;
                }

            }
            else if (gameObject.tag == "BusySlot")
            {
                //rend.material.color = hoverColorBusy;
                rend.material = PublicGameobjects.towerBusyMaterialStatic;
            }

        }
        else
        {
            //rend.material.color = startColor;
            rend.material = PublicGameobjects.towerLastMaterial;
        }
        

    }

    


    private void OnMouseExit()
    {
        //rend.material.color = startColor;
        rend.material = PublicGameobjects.towerLastMaterial;

        PublicGameobjects.showRangeNewTurret = false;



        if (tower1Slot != null)
        {
            Destroy(tower1Slot);
        }
        if (tower2Slot != null)
        {
            Destroy(tower2Slot);
        }
        if (tower3Slot != null)
        {
            Destroy(tower3Slot);
        }
        if (tower4Slot != null)
        {
            Destroy(tower4Slot);
        }


        alreadyRespawned = false;

    }

    void CheckIfTurretChanged()
    {
        if (!turret1)
        {
            if (tower1Slot != null)
            {
                Destroy(tower1Slot);

                //rend.material.color = startColor;
                rend.material = PublicGameobjects.towerLastMaterial;

                PublicGameobjects.showRangeNewTurret = false;
            }
        }

        if (!turret2)
        {
            if (tower2Slot != null)
            {
                Destroy(tower2Slot);
                //rend.material.color = startColor;
                rend.material = PublicGameobjects.towerLastMaterial;
                PublicGameobjects.showRangeNewTurret = false;
            }
        }

        if (!turret3)
        {
            if (tower3Slot != null)
            {
                Destroy(tower3Slot);
                //rend.material.color = startColor;
                rend.material = PublicGameobjects.towerLastMaterial;
                PublicGameobjects.showRangeNewTurret = false;
            }
        }

        if (!turret4)
        {
            if (tower4Slot != null)
            {
                Destroy(tower4Slot);
                //rend.material.color = startColor;
                rend.material = PublicGameobjects.towerLastMaterial;
                PublicGameobjects.showRangeNewTurret = false;
            }
        }

    }

    



}
