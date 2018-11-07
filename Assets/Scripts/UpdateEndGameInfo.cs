using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateEndGameInfo : MonoBehaviour {

    public Text reachedWave;


    public Button restartGameButton;


    void Awake()
    {
        reachedWave.text = "You reached " + WaveSpawning.waveIndex + " wave.";
    }

    // Use this for initialization
    void Start () {
        Button restartGame = restartGameButton.GetComponent<Button>();
        restartGame.onClick.AddListener(RestartGame);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void RestartGame()
    {
        //Debug.Log("dzialam");
        //reachedWave.text = "asdasdasd";

        
        GameStats.lifes = 15f;
        GameStats.maxLifes = GameStats.lifes;
        GameStats.money = 30f;

        WaveSpawning.waveIndex = 0;
        WaveSpawning.monstersType = 0;

        SceneManager.LoadScene("TowerDefenseType01", LoadSceneMode.Single);
    }

}
