using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{

    string spawnName;

    void Start()
    {
        spawnName = "playerSpawn";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            swapGameScene();
        }
    }

    void swapGameScene()
    {
        string currScene = SceneManager.GetActiveScene().name;

        string nextScene = grabScene(currScene);

        GameObject grabPlayerTag = GameObject.FindGameObjectWithTag("Player");

        if(grabPlayerTag != null)
        {
            Destroy(grabPlayerTag);
        }

        SceneManager.LoadScene(nextScene);

        Transform sceneSpawn = GameObject.Find(spawnName).transform;

        if(sceneSpawn != null)
        {
            Instantiate(Resources.Load("Prefab/Temp_Player"));
        }
        else
        {
            Debug.Log("SpawnPoint missing!");
        }

    }

    string grabScene(string nextSceneName)
    {
        switch(nextSceneName)
        {
            case "TestingScene":
                return "BedroomScene";
            case "BedroomScene":
                return "WaitingRoomScene";
            case "WaitingRoomScene":
                return "ExamRoomScene";
            default:
                return "TestingScene";
        }
    }

}
