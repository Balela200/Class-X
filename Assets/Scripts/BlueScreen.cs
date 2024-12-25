using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Name of the scene to load
    public string sceneName = "NextScene";

    void Start()
    {
        // Invoke the scene change after 5 seconds
        Invoke("SwitchScene", 5f);
    }

    void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
