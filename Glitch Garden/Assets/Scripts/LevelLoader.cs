using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float splashScreenTime = 3f;

    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadingStartScene());
        }
    }

    IEnumerator LoadingStartScene()
    {
        yield return new WaitForSeconds(splashScreenTime);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex +1);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Start");
    }
}
