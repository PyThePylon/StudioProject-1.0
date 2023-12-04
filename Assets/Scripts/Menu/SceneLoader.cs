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
        switch (scene)
        {
            case 0:
                SceneManager.LoadScene("TestingScene");
                gameObject.SetActive(true);
                break;
            case 1:
                SceneManager.LoadScene("ControlsScreen");
                gameObject.SetActive(true);
                break;
            case 2:
                SceneManager.LoadScene("CreditsScreen");
                gameObject.SetActive(true);
                break;
            case 3:
                SceneManager.LoadScene("MainMenu");
                gameObject.SetActive(true);
                break;
            case 4:
                SceneManager.LoadScene("SettingsScreen");
                gameObject.SetActive(true);
                break;
            case 5:
                SceneManager.LoadScene("Bedroom Scene");
                gameObject.SetActive(true);
                break;
            case 6:
                SceneManager.LoadScene("School Scene");
                gameObject.SetActive(true);
                break;
            case 7:
                SceneManager.LoadScene("Aquarium Scene");
                gameObject.SetActive(true);
                break;
            case 8:
                SceneManager.LoadScene("Apartment Scene");
                gameObject.SetActive(true);
                break;
            default:
                Application.Quit();
                Debug.Log("Game Closed");
                break;
        }
        /*if (scene == 0)
        {
            SceneManager.LoadScene("TestingScene");
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
        }*/
    }
}
