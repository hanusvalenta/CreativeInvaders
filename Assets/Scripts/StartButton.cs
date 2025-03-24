using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad = "Game";

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
