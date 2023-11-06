using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{


    SceneFade fade;


    void Start()
    {
        fade = FindObjectOfType<SceneFade>();
    }


    void swapGameScene()
    {
        string currScene = SceneManager.GetActiveScene().name;

        string nextScene = grabScene(currScene);

        GameObject grabPlayerTag = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPosition = Vector3.zero;

        if (grabPlayerTag != null)
        {
            playerPosition = grabPlayerTag.transform.position;
            Destroy(grabPlayerTag);
        }

        StartCoroutine(sceneFade(nextScene, playerPosition));
    }


    public IEnumerator sceneFade(string loadScene, Vector3 playerPosition)
    {
        fade.FadeIn();

        yield return new WaitForSeconds(fade.fadeTime); // Wait for the fade-in to complete

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadScene);
        asyncLoad.allowSceneActivation = false; // Prevent the scene from activating immediately

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true; // Allow the scene to activate
            }
            yield return null;
        }

        yield return new WaitForSeconds(0.1f); // Add a slight delay to ensure the scene is fully loaded

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = playerPosition;
        }
        fade.FadeOut();
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
            case "ExamRoomScene":
                return "SchoolScene";
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
