using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float waitingTime = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    TimeSpan timeSpan;
    RewardManager rewardManager =  new RewardManager() ;
    
    public string timerFormatted;
    
    private void Start()
    {
        rewardManager = this.GetComponent<RewardManager>();
    }

    void Update()
    {

        if (timerIsRunning)
        {
            //disable the coins button
            rewardManager.freeCoinsBtn.interactable = false;
            rewardManager.freeCoinsBtn.image.color = Color.gray;
            if (waitingTime > 0)
            {
                //calculate time
                waitingTime -= Time.deltaTime;

                DisplayTime(waitingTime);

            }
            else
            {
                //reset time
                waitingTime = 0;
                timeText.gameObject.SetActive(false);
                
                timerIsRunning = false;
            }
        }
        else {
            rewardManager.freeCoinsBtn.interactable = true;
            rewardManager.freeCoinsBtn.image.color = Color.magenta;
        }
    }

    void DisplayTime(float timeToDisplay) {
        timeText.gameObject.SetActive(true);
        System.TimeSpan t = System.TimeSpan.FromSeconds(timeToDisplay);
        timerFormatted = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", 
            t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
        timeText.text = timerFormatted;
    }
}