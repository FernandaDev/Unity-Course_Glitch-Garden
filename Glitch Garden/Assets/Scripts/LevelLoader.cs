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
        if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings -1)
            SceneManager.LoadScene(currentSceneIndex + 1);
        else
            LoadMenuScene();
    }

    public void LoadMenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start");
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options Scene");
    }
}
