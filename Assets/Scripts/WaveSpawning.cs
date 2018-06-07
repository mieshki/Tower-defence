using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawning : MonoBehaviour {
    
    public GameObject enemy; // normalne 
    public GameObject enemy2; // szybkie
    public GameObject enemy3; // wolne
    public GameObject enemy4; // latajace
    public GameObject enemy5; // hajsik
    public GameObject enemy6; // boss

    private GameObject enemyToSpawn;

    public Transform start;

    public Transform[] airSpawn = new Transform[] { null, null, null, null, null, null, null, null, null, null };
    public int numb = 0;

    public float spawnDelay = 0.5f;

    public string type = "ground";


    public static int waveIndex = 0;
    private int enemiesToSpawn = 10;

    public static float breakBetweenFirstWave = 0f;
    private float breakBetweenWaves = 30f;

    public static bool gameStarted = false;

    public static bool ableToNextWave = true;

    public static float monstersType = 0;





    void Start()
    {
    }

    void Update()
    {
        if (gameStarted)
        {
            if (breakBetweenFirstWave <= 0f)
            {
                StartCoroutine(WaveSpawner());
                // to give time on respawning, to avoid stacking enemies in the same place
                //breakBetweenFirstWave = 999f;
            }

            breakBetweenFirstWave -= Time.deltaTime;
        }
        
    }


    IEnumerator WaveSpawner()
    {
        waveIndex++;

        if (monstersType >= 10)
        {
            monstersType = 0;
        }

        monstersType++;

        Debug.Log(monstersType);
        if (monstersType == 7)
        {
            GameStats.moneyForKill += 1;
        }/*
        else if (monstersType == 5)
        {
            GameStats.moneyForKill += 1;
        }
        */
        else if (monstersType == 10)
        {
            GameStats.moneyForBoss = 10 * GameStats.moneyForKill;
        }

        Debug.Log("normal: " + GameStats.moneyForKill);
        Debug.Log("boss: " + GameStats.moneyForBoss);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            ableToNextWave = false;
            breakBetweenFirstWave = breakBetweenWaves;

            GameStats.UpdateMultiplier();

            SpawnEnemy();

            yield return new WaitForSeconds(spawnDelay);
        }



        if(monstersType == 10)
        {
            GameStats.allEnemyLastLife = GameStats.actualLife / 10;
            
        }
        else
        {
            GameStats.allEnemyLastLife = GameStats.actualLife;
        }
        

        //enemiesToSpawn += 1;
        breakBetweenFirstWave = breakBetweenWaves;
        ableToNextWave = true;

    }



    void SpawnEnemy()
    {
        if (monstersType == 1 || monstersType == 5)
        {
            enemyToSpawn = enemy;
            enemiesToSpawn = 10;
            type = "ground";
            spawnDelay = 0.5f;
        }
        else if (monstersType == 2 || monstersType == 6)
        {
            enemyToSpawn = enemy2;
            enemiesToSpawn = 10;
            type = "ground";
            spawnDelay = 0.3f;
        }
        else if (monstersType == 3 || monstersType == 7)
        {
            enemyToSpawn = enemy3;
            enemiesToSpawn = 10;
            type = "ground";
            spawnDelay = 1f;
        }
        else if(monstersType == 4 || monstersType == 8)
        {
            enemyToSpawn = enemy4;
            enemiesToSpawn = 10;
            type = "air";
            spawnDelay = 0f;
        }
        else if(monstersType == 9)
        {
            enemyToSpawn = enemy5;
            enemiesToSpawn = 10;
            type = "ground";
            spawnDelay = 0.7f;
        }
        else if(monstersType == 10)
        {
            enemyToSpawn = enemy6;
            enemiesToSpawn = 1;
            type = "ground";
            spawnDelay = 0.5f;
        }

        if(type == "ground")
        {
            enemyToSpawn.transform.position = start.position;

            Instantiate(enemyToSpawn, start.position, start.rotation);
        }
        else if(type == "air")
        {
            enemyToSpawn.transform.position = airSpawn[numb].position;
            Instantiate(enemyToSpawn, airSpawn[numb].position, airSpawn[numb].rotation);

            if (numb >= 9)
            {
                numb = 0;
            }
            else
            {
                numb++;
            }
                       
        }
        else
        {

        }

        
    }

}
