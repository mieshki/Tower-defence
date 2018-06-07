using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PublicGameobjects : MonoBehaviour {

    public GameObject circle;

    private GameObject circleRange;


    public static Vector3 circleRangePos;
    public static Vector3 circleRangeScale;

    public GameObject DollarsIncomeGO;
    public TextMesh DollarsIncomeText;


    public static GameObject DollarsIncomeGOStatic;
    public static TextMesh DollarsIncomeTextStatic;


    public static bool showRange = false;
    public static bool showRangeNewTurret = false;


    public GameObject TowerSellCheckSlotGO;
    public static GameObject TowerSellCheckSlotGOStatic;


    public GameObject AoEDamageGO;
    public static GameObject AoEDamageGOStatic;

    public GameObject AoEFreezeGO;
    public static GameObject AoEFreezeGOStatic;

    public Material towerEmptyMaterial;
    public Material towerBusyMaterial;
    public static Material towerLastMaterial;

    public static Material towerEmptyMaterialStatic;
    public static Material towerBusyMaterialStatic;

    public Text endGameText;
    public static Text endGameTextStatic;


    // Use this for initialization
    void Start () {
        DollarsIncomeGOStatic = DollarsIncomeGO;
        DollarsIncomeTextStatic = DollarsIncomeText;
        TowerSellCheckSlotGOStatic = TowerSellCheckSlotGO;

        AoEDamageGOStatic = AoEDamageGO;
        AoEFreezeGOStatic = AoEFreezeGO;

        //towerEmptyMaterial = GetComponent<Renderer>().material;
        //towerBusyMaterial = GetComponent<Renderer>().material;

        towerEmptyMaterialStatic = towerEmptyMaterial;
        towerBusyMaterialStatic = towerBusyMaterial;

        endGameTextStatic = endGameText;


    }
	
	// Update is called once per frame
	void Update () {


        if (showRange || showRangeNewTurret)
        {
            if(circleRange == null)
            {
                circleRange = Instantiate(circle, circleRangePos, Quaternion.identity);
                circleRange.transform.localScale = new Vector3(circleRangeScale.x, circleRange.transform.lossyScale.y, circleRangeScale.z);
                MenuButtons.UIStatsTowerEnabled = true;
            }

        }

        else
        {
            if(circleRange != null)
            {
               Destroy(circleRange);
            }
            MenuButtons.UIStatsTowerEnabled = false;
           
        }
		
        
        if(circleRange != null)
        {
            circleRange.transform.position = circleRangePos;
            circleRange.transform.localScale = new Vector3(circleRangeScale.x, circleRange.transform.lossyScale.y, circleRangeScale.z);
        }
       
    }
}
