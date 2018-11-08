using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStats : MonoBehaviour {

    public static float lifes = 15f;
    public static float maxLifes = lifes;

    public static float money = 30f;

    public Sprite emptyAvatar;
    public static Sprite emptyAvatarStatic;

    public Sprite Enemy1Avatar;
    public Sprite Enemy2Avatar;
    public Sprite Enemy3Avatar;
    public Sprite Enemy4Avatar;
    public Sprite Enemy5Avatar;
    public Sprite Enemy6Avatar;

    public static Sprite Enemy1AvatarStatic;
    public static Sprite Enemy2AvatarStatic;
    public static Sprite Enemy3AvatarStatic;
    public static Sprite Enemy4AvatarStatic;
    public static Sprite Enemy5AvatarStatic;
    public static Sprite Enemy6AvatarStatic;

    public static float dollarsShowTime = .3f;
    public static float sellMultiplier = .7f;
    
    // TOWER1   
    public static int Tower1Level = 1;
    public static float Tower1Cost = 5f;
    public static float Tower1Damage = 2f;
    public static float Tower1Range = 15f;
    public static float Tower1FireRate = 2.5f;

    // TOWER2 
    public static int Tower2Level = 1;
    public static float Tower2Cost = 25f;
    public static float Tower2Damage = 30f;
    public static float Tower2Range = 11f;
    public static float Tower2FireRate = 0.33f;

    public static float Tower2AOEDamageMultiplier = 0.6f;
    public static float Tower2AOEScaleSize = 11f;
    public static Vector3 Tower2AOEScale = new Vector3(Tower2AOEScaleSize, Tower2AOEScaleSize, Tower2AOEScaleSize);

    // TOWER3 
    public static int Tower3Level = 1;
    public static float Tower3Cost = 15f;
    public static float Tower3Damage = 1f;
    public static float Tower3Range = 17f;
    public static float Tower3FireRate = 2.5f;
    public static float Tower3AOEFreezeDamageMultiplier = 0.6f;
    public static float Tower3AOEFreezeSpeedScale = 0.66f;
    public static float Tower3AOEFreezeTime = 1f;
    public static float Tower3AOEFreezeScaleSize = 10f;
    public static Vector3 Tower3AOESFreezecale = new Vector3(Tower3AOEFreezeScaleSize, Tower3AOEFreezeScaleSize, Tower3AOEFreezeScaleSize);

    // TOWER4   TODO - AOE
    public static int Tower4Level = 1;
    public static float Tower4Cost = 35f;
    public static float Tower4Damage = 50f;
    public static float Tower4Range = 10f;
    public static float Tower4FireRate = 0.33f;
    public static float allEnemyStartLife = 10f;
    public static float allEnemyLifeMultiplier = 1;

    public static float actualLife = 10f;
    public static float allEnemyLastLife = 10f;

    // ENEMY1 normalne
    public static string Enemy1Name = "Normal";
    public static float Enemy1Speed = 5f;

    // ENEMY2 szybkie
    public static string Enemy2Name = "Fast";
    public static float Enemy2Speed = 6.5f;

    // ENEMY3 wolne
    public static string Enemy3Name = "Slow";
    public static float Enemy3Speed = 3.5f;

    // ENEMY4 latajace
    public static string Enemy4Name = "Air";
    public static float Enemy4Speed = 1.5f;
    public static float Enemy4LifeMultiplier = 1f;

    // ENEMY5 dla pieniedzy
    public static string Enemy5Name = "Normal-weak";
    public static float Enemy5Speed = 3.5f;

    // ENEMY6 bosssss
    public static string Enemy6Name = "BOSS";
    public static float Enemy6Speed = 3f;

    public static float moneyForKill = 1f;
    public static float moneyForBoss = 0f;

    void Start () {
        emptyAvatarStatic = emptyAvatar;
        Enemy1AvatarStatic = Enemy1Avatar;
        Enemy2AvatarStatic = Enemy2Avatar;
        Enemy3AvatarStatic = Enemy3Avatar;
        Enemy4AvatarStatic = Enemy4Avatar;
        Enemy5AvatarStatic = Enemy5Avatar;
        Enemy6AvatarStatic = Enemy6Avatar;
    }

    public static void UpdateMultiplier()
    {
        if (WaveSpawning.waveIndex == 1)
            allEnemyLifeMultiplier = 1f;
        else if (WaveSpawning.waveIndex == 2)
            allEnemyLifeMultiplier = 1.5f;
        else if (WaveSpawning.waveIndex == 3)
            allEnemyLifeMultiplier = 1.46f;
        else if (WaveSpawning.waveIndex == 4)
            allEnemyLifeMultiplier = 1.45f;
        else if (WaveSpawning.waveIndex == 5)
            allEnemyLifeMultiplier = 1.34f;
        else if (WaveSpawning.waveIndex == 6)
            allEnemyLifeMultiplier = 1.32f;
        else if (WaveSpawning.waveIndex == 7)
            allEnemyLifeMultiplier = 1.298f;
        else if (WaveSpawning.waveIndex == 8)
            allEnemyLifeMultiplier = 1.27f;
        else if (WaveSpawning.waveIndex == 9)
            allEnemyLifeMultiplier = 1.22f;
        else if (WaveSpawning.waveIndex == 10)
            allEnemyLifeMultiplier = 1.217f;
        else if (WaveSpawning.waveIndex == 11)
            allEnemyLifeMultiplier = 1.19f;
        else if (WaveSpawning.waveIndex == 12)
            allEnemyLifeMultiplier = 1.185f;
        else if (WaveSpawning.waveIndex == 13)
            allEnemyLifeMultiplier = 1.166f;
        else if (WaveSpawning.waveIndex == 14)
            allEnemyLifeMultiplier = 1.160f;
        else if (WaveSpawning.waveIndex == 15)
            allEnemyLifeMultiplier = 1.149f;
        else if (WaveSpawning.waveIndex == 16)
            allEnemyLifeMultiplier = 1.136f;
        else if (WaveSpawning.waveIndex == 17)
            allEnemyLifeMultiplier = 1.131f;
        else if (WaveSpawning.waveIndex == 18)
            allEnemyLifeMultiplier = 1.143f;
        else if (WaveSpawning.waveIndex == 19)
            allEnemyLifeMultiplier = 1.135f;
        else if (WaveSpawning.waveIndex == 20)
            allEnemyLifeMultiplier = 1.128f;
        else if (WaveSpawning.waveIndex == 21)
            allEnemyLifeMultiplier = 1.121f;
        else if (WaveSpawning.waveIndex == 22)
            allEnemyLifeMultiplier = 1.115f;
        else if (WaveSpawning.waveIndex == 23)
            allEnemyLifeMultiplier = 1.094f;
        else if (WaveSpawning.waveIndex == 24)
            allEnemyLifeMultiplier = 1.09f;
        else if (WaveSpawning.waveIndex == 25)
            allEnemyLifeMultiplier = 1.089f;
        else if (WaveSpawning.waveIndex == 26)
            allEnemyLifeMultiplier = 1.084f;
        else if (WaveSpawning.waveIndex == 27)
            allEnemyLifeMultiplier = 1.08f;
        else if (WaveSpawning.waveIndex == 28)
            allEnemyLifeMultiplier = 1.07f;
        else if (WaveSpawning.waveIndex == 28)
            allEnemyLifeMultiplier = 1.07f;
        else if (WaveSpawning.waveIndex == 29)
            allEnemyLifeMultiplier = 1.07f;
        else if (WaveSpawning.waveIndex == 30)
            allEnemyLifeMultiplier = 1.07f;
        else if (WaveSpawning.waveIndex == 31)
            allEnemyLifeMultiplier = 1.07f;
        else if (WaveSpawning.waveIndex == 32)
            allEnemyLifeMultiplier = 1.069f;
        else if (WaveSpawning.waveIndex == 33)
            allEnemyLifeMultiplier = 1.069f;
        else if (WaveSpawning.waveIndex == 34)
            allEnemyLifeMultiplier = 1.065f;
        else if (WaveSpawning.waveIndex == 35)
            allEnemyLifeMultiplier = 1.06f;
        else if (WaveSpawning.waveIndex == 36)
            allEnemyLifeMultiplier = 1.06f;
        else if (WaveSpawning.waveIndex == 37)
            allEnemyLifeMultiplier = 1.059f;
        else if (WaveSpawning.waveIndex == 38)
            allEnemyLifeMultiplier = 1.057f;
        else if (WaveSpawning.waveIndex == 39)
            allEnemyLifeMultiplier = 1.055f;
        else if (WaveSpawning.waveIndex == 40)
            allEnemyLifeMultiplier = 1.05f;
        else
        {
            if (allEnemyLifeMultiplier > 1f)
                allEnemyLifeMultiplier -= 0.004f;
            else if(allEnemyLifeMultiplier <= 1f)
                allEnemyLifeMultiplier = 1.003f;  
        }
    }

    void Update ()
    {
        CheckIfDidNotLose();
    }

    void CheckIfDidNotLose()
    {
        if(lifes <= 0)
            SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
    }
}
