using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Movement : MonoBehaviour {


    public float enemySpeed;



    void Start()
    {
        enemySpeed = GameStats.Enemy4Speed;

    }

    void Update()
    {

        Vector3 dir = new Vector3(enemySpeed * Time.deltaTime, 0, 0);

        transform.Translate(dir, Space.World);

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AirEND")
        {
            Destroy(gameObject);
            Debug.Log("dolecial");
            GameStats.lifes--;
        }
    }







}
