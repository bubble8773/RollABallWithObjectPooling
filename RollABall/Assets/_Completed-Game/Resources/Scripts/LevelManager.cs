using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject levelButtonGroup;
    
    private void Start()
    {
        //locking levels other than then first level or unlocked levels
        Debug.Log(PlayerPrefs.GetInt("UnlockedLevel"));
        if (levelButtonGroup != null)
        {
            for (int i = 0; i <= PlayerPrefs.GetInt("UnlockedLevel") - 1; i++)
            {
                if (PlayerPrefs.GetInt("UnlockedLevel") >= levelButtonGroup.transform.childCount - 1)
                    PlayerPrefs.SetInt("UnlockedLevel", 0);

                levelButtonGroup.transform.GetChild(i).GetComponent<Button>().interactable = true;
                
            }

        }

    }
       

    public void LoadLevels(int levelNum)
    {
        SceneManager.LoadScene("Level"+levelNum);
        PlayerPrefs.SetInt("SelectedLevel", levelNum);
        
    }

       
}
