using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour {
    
    public Text scoreText, killText;
    public float timer;
    public Text levelName;
    public GameObject gameWinPopUP, gameOverPopUp, pausePopUp;
    public Text coinText;

    public static GameData _instance;

    int coins, score;
    int level, unlockedLevelIndex;

    private void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start()
    {
        //Transform parent = GameObject.Find("Canvas").transform;
        //gameOverPopUp = Instantiate(Resources.Load("Prefabs/GameOverPopUp"), parent)  as GameObject;
        //gameWinPopUP = Instantiate(Resources.Load("Prefabs/GameWinPopUP"), parent) as GameObject;
        //pausePopUp = Instantiate(Resources.Load("Prefabs/PausePopUP"), parent) as GameObject;
        gameOverPopUp.SetActive(false);
        gameWinPopUP.SetActive(false);
        pausePopUp.SetActive(false);
        score = 0;
        timer = 0.0f;
        //Cursor.visible = false;
        coins = 0;
        level = PlayerPrefs.GetInt("SelectedLevel");
        levelName.text = "Level: " + level;
        PlayerPrefs.SetInt("LevelComplete", 0);
        
    }


    //Destory coins and update to the score board
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.GetComponent<Collider>().tag == "Pick Up")
        {
            Destroy(other.gameObject);
            coins++;

        }
        else if (other.GetComponent<Collider>().tag == "Enemy")
        {
            gameOverPopUp.SetActive(true);
            gameOverPopUp.transform.localScale = Vector3.one;
        }
        

        //levelcomplete condition
        if (coins == 10)
        {
            PlayerPrefs.SetInt("LevelComplete", 1);
            // unlock the next level
            if (PlayerPrefs.GetInt("LevelComplete") == 1)
            {
                unlockedLevelIndex = level + 1;
                PlayerPrefs.SetInt("UnlockedLevel", unlockedLevelIndex);
                Debug.Log(PlayerPrefs.GetInt("UnlockedLevel"));
            }
           
            gameWinPopUP.SetActive(true);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Rewards: " + (coins);

        if (pausePopUp.activeInHierarchy || gameWinPopUP.activeInHierarchy || gameOverPopUp.activeInHierarchy)
            Time.timeScale = 0.0f;
        else
        {
            Time.timeScale = 1.0f;
            timer = Time.deltaTime * 0.00001f;
            if (timer > 0)
            {
                score += 1 + coins;
                scoreText.text = "Score: " + score;
            }
        }


    }

}
