using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetFloat("Volume") == 0)
        {
            AudioListener.volume = 0.5f;
            PlayerPrefs.SetFloat("Volume", 0.5f);
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        }
    }

    public void LoadGameScene(int scene)
    {
        if (scene == 0)
        {
            SceneManager.LoadScene("The_Game");
            gameObject.SetActive(true);
        }
        else if (scene == 1)
        {
            SceneManager.LoadScene("ControlsScreen");
            gameObject.SetActive(true);
        }
        else if (scene == 2)
        {
            SceneManager.LoadScene("CreditsScreen"); //Just replace with the credits scene name
            gameObject.SetActive(true);
        }
        else if (scene == 3)
        {
            SceneManager.LoadScene("MainMenu");
            gameObject.SetActive(true);
        }
        else if (scene == 4)
        {
            SceneManager.LoadScene("SettingsScreen");
            gameObject.SetActive(true);
        }
        else
        {
            Application.Quit();
            Debug.Log("Game Closed");
        }
    }
}
