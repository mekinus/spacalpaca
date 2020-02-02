using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public enum GameStates
    {
       paused,resumed,over,clear
    }

    public GameObject menuButton;

    public GameObject[] potions;

    public GameObject[] meteors;
    public GameObject[] aliens;

    private bool pauseMenuIsShowed = false;
    public GameObject crystalShard;
    public GameStates states;
    public Text timeText;
    public Text crystalText;

    private int crystals = 0;
    private int displayedInt;
    private float levelTime;

    public Transform[] monsterSpawnPoints;
    public Transform[] meteorSpawnPoints;
    public Transform effectPoint;
    public Transform potionSpawnPoint;

    public Player thePlayer;


    public GameObject gameOverEffect;
    public GameObject clearEffect;

    private float crystalSpawnCoolDown = 60f;

    private float meteorSpawnCoolDown = 6f;
    private float alienSpawnCoolDown = 15f;
    private float potionSpawnCoolDown = 18f;


    


    // Start is called before the first frame update
    void Start()
    {
        SetLevelTime(300);
        SetGameState(GameStates.resumed);
    }

    // Update is called once per frame
    void Update()
    {
        PauseHandler();
        UpdateTimeUI();
        UpdateCrystalUI();
        levelTime -= Time.deltaTime;
        displayedInt = (int)levelTime;

        meteorSpawnCoolDown -= Time.deltaTime;
        alienSpawnCoolDown -= Time.deltaTime;
        potionSpawnCoolDown -= Time.deltaTime;

        crystalSpawnCoolDown -= Time.deltaTime;
        if(crystalSpawnCoolDown < 0f & states != GameStates.over)
        {
            SpawnCrystal();
            crystalSpawnCoolDown = 60f;
        }

        if(states == GameStates.resumed & meteorSpawnCoolDown < 0f)
        {
            SpawnRandomMeteor();
            meteorSpawnCoolDown = 6f;
        }


        if (states == GameStates.resumed & alienSpawnCoolDown < 0f)
        {
            SpawnRandomAlien();
            alienSpawnCoolDown = 15f;
        }


        if (states == GameStates.resumed & potionSpawnCoolDown < 0f)
        {
            SpawnRandomPotion();
            potionSpawnCoolDown = 18f;
        }



    }


    void SetLevelTime(int timeToSet)
    {

        levelTime = timeToSet;

        if(levelTime > -1)
        timeText.text = displayedInt.ToString();
    }


    void UpdateTimeUI()
    {
        timeText.text = displayedInt.ToString();
    }


    public void GetCrystal()
    {
        crystals++;
        crystalText.text = crystals.ToString();
        CheckIfGameIsClear();
    }


    void UpdateCrystalUI()
    {
        crystalText.text = crystals.ToString();
    }

 

    public void CheckIfGameIsOver()
    {
        if (thePlayer.hp < 0)
        {
            SetGameState(GameStates.over);
            Instantiate(gameOverEffect, effectPoint.position, Quaternion.identity);
            Invoke("BackToTitleScene", 10f);
        }
        
    }

    public void CheckIfGameIsClear()
    {
        if (crystals > 4 & states == GameStates.resumed)
        {
            SetGameState(GameStates.clear);
            Instantiate(clearEffect, effectPoint.position, Quaternion.identity);
            Invoke("ChangeToClearScene", 10f);
        }

    }


    void ChangeToClearScene()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene(3);

    }

    public void BackToTitleScene()
    {

        Time.timeScale = 1f;

        SceneManager.LoadScene(0);

    }



    void PauseHandler()
    {
        if(Input.GetKeyUp(KeyCode.Escape))

        {

            if (pauseMenuIsShowed == false)
            {

                pauseMenuIsShowed = true;
                menuButton.SetActive(true);
                Time.timeScale = 0f;

            }

            else

            {
                Time.timeScale = 1f;
                pauseMenuIsShowed = false;
                menuButton.SetActive(false);

            }

        }

      




    }




    void SetGameState(GameStates stateOfGame)
    {
        states = stateOfGame;
    }


    void SpawnCrystal()
    {
        if(crystals < 5)
        Instantiate(crystalShard, effectPoint.position, Quaternion.identity);
    }


    void SpawnRandomMeteor()
    {
        int index = Random.Range(0, 7);
        
        switch (index)
        {
            case 0: Instantiate(meteors[0], meteorSpawnPoints[2].position, Quaternion.identity); break;
            case 1: Instantiate(meteors[1], meteorSpawnPoints[2].position, Quaternion.identity); break;
            case 2: Instantiate(meteors[2], meteorSpawnPoints[2].position, Quaternion.identity); break;
            case 3: Instantiate(meteors[3], meteorSpawnPoints[3].position, Quaternion.identity); break;
            case 4: Instantiate(meteors[4], meteorSpawnPoints[1].position, Quaternion.identity); break;
            case 5: Instantiate(meteors[5], meteorSpawnPoints[0].position, Quaternion.identity); break;
            default: Instantiate(meteors[0], meteorSpawnPoints[2].position, Quaternion.identity); break;
        }
    }


    void SpawnRandomAlien()
    {
        int index = Random.Range(0, 5);
        int pIndex = Random.Range(0, 4);
       
        Instantiate(aliens[index], monsterSpawnPoints[pIndex].position, Quaternion.identity);
           
    }



    void SpawnRandomPotion()
    {
        int index = Random.Range(0, 2);
        Instantiate(potions[index], potionSpawnPoint.position, Quaternion.identity);

    }






}
