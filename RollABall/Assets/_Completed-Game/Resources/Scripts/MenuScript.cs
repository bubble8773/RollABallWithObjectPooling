using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    private void Start()
    {
        if (GameData._instance)
        {
            GameData._instance.pausePopUp.transform.Find("Continue").GetComponent<Button>().onClick.AddListener(ContinueGame);
            GameData._instance.pausePopUp.transform.Find("Levels Page").GetComponent<Button>().onClick.AddListener(NextButtonClickEvent);
            GameData._instance.gameWinPopUP.transform.Find("Next").GetComponent<Button>().onClick.AddListener(NextButtonClickEvent);
            GameObject gameOverPopUp = GameData._instance.gameOverPopUp;
            if (gameOverPopUp)
            {
                gameOverPopUp.transform.Find("Restart Level").GetComponent<Button>().onClick.AddListener(RestartLevel);
            }
        }

    }
    public void PauseGame()
    {
        GameData._instance.pausePopUp.SetActive(true);
        
    }
    public void ContinueGame()
    {
        GameData._instance.pausePopUp.SetActive(false);
       
    }

    public void RestartLevel()
    {
       SceneManager.LoadScene(PlayerPrefs.GetInt("SelectedLevel"));        
    }

    public void NextButtonClickEvent()
    {
        SceneManager.LoadScene("LevelsPage");

    }

    public void ChangeToScene(string sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }

    public void exitGame()
    {
        Application.Quit();
    }

   
}
