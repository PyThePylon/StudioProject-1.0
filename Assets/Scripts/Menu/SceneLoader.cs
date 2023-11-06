using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    private const string TestingScene = "TestingScene";
    private const string ControlsScreen = "ControlsScreen";
    private const string CreditsScreen = "CreditsScreen";
    private const string MainMenu = "MainMenu";
    private const string SettingsScreen = "SettingsScreen";

    private void Start()
    {
        InitializeVolume();
    }

    private void InitializeVolume()
    {
        float volume = PlayerPrefs.GetFloat("Volume", 0.5f);
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void LoadGameScene(int scene)
    {
        string sceneName = GetSceneName(scene);
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
            gameObject.SetActive(true);
        }
        else
        {
            Application.Quit();
            Debug.Log("Game Closed");
        }
    }

    private string GetSceneName(int scene)
    {
        switch (scene)
        {
            case 0:
                return TestingScene;
            case 1:
                return ControlsScreen;
            case 2:
                return CreditsScreen;
            case 3:
                return MainMenu;
            case 4:
                return SettingsScreen;
            default:
                return null;
        }
    }
}
