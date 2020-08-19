using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{

    public enum RewardsType {
        NONE,
        COINS,
        POWERUPS,
        ADREWARDS

    }
    public Button freeCoinsBtn;
    public Text totalCoinsText;
    int totalcoins;
    Timer timerObj;

    // Start is called before the first frame update
    private void Awake()
    {
        //PlayerPrefs.SetInt("CollectedFreeCoinsFirstTime", 0);
    }
    void Start()
    {
        timerObj = GetComponent<Timer>();
        //if (PlayerPrefs.GetInt("CollectedFreeCoinsFirstTime") == 0)
        //{
        //    timerObj.timeText.gameObject.SetActive(true);
        //}
        //else {
            timerObj.timeText.gameObject.SetActive(false);
        //}
        
    }

    public void colectFreeCoins(int amount)
    {
       totalcoins  += PlayerPrefs.GetInt("Totalcoins") +amount;
        PlayerPrefs.SetInt("Totalcoins", totalcoins);
        timerObj.timeText.gameObject.SetActive(true);
        timerObj.timerIsRunning = true;
    }
    


    // Update is called once per frame
    void Update()
    {
        totalCoinsText.text = PlayerPrefs.GetInt("Totalcoins").ToString();
    }
}
