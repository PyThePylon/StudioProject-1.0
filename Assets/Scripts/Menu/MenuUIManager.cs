using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("BedroomScene", LoadSceneMode.Single);
    }
    public void settings()
    {
        SceneManager.LoadScene("SettingsScreen", LoadSceneMode.Single);
    }
    public void controls()
    {
        SceneManager.LoadScene("ControlsScreen", LoadSceneMode.Single);
    }
    public void sceneSelect()
    {
        SceneManager.LoadScene("SceneSelectScreen", LoadSceneMode.Single);
    }
    public void credits()
    {
        SceneManager.LoadScene("CreditsScreen", LoadSceneMode.Single);
    }
    public void quit()
    {
        Application.Quit();
    }
}
