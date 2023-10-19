using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{

    string spawnName;

    SceneFade fade;


    void Start()
    {
        spawnName = "playerSpawn";
        fade = FindObjectOfType<SceneFade>();
    }


    void swapGameScene()
    {
        string currScene = SceneManager.GetActiveScene().name;

        string nextScene = grabScene(currScene);

        GameObject grabPlayerTag = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(sceneFade(nextScene));


        if (grabPlayerTag != null)
        {
            Destroy(grabPlayerTag);
        }

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


    public IEnumerator sceneFade(string loadScene)
    {
        fade.FadeIn();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(loadScene);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("CHANGE!");
            swapGameScene();

        }
    }

}
