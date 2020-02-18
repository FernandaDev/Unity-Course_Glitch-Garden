using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    public static LevelController instance { get; private set; }

    [SerializeField] Transform winCanvas;
    [SerializeField] Transform loseCanvas;

    [Tooltip("Our level timer in SECONDS.")]
    public int levelTime = 10;
    bool levelTimerFinished = false;
    [SerializeField] AudioClip winSFX;
    int numberOfAttackers = 0;

    public float delayTimeToNextLevel = 2f;

    [HideInInspector] public UnityEvent OnLevelComplete = new UnityEvent();

    private void Awake()
    {
        if (!instance) instance = this;

        winCanvas.gameObject.SetActive(false);
        loseCanvas.gameObject.SetActive(false);
    }

    public void AddAttackerCount() { numberOfAttackers++; }

    public void RemoveAttackerCount()
    {
        numberOfAttackers--;

        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(OnLevelCompleted(delayTimeToNextLevel));
        }
    }

    public void LevelTimerHasFinished()
    {
        levelTimerFinished = true;
        AttackerSpawner.instance.StopSpawner();
    }

    IEnumerator OnLevelCompleted(float delayToLoadNextScene)
    {
        winCanvas.gameObject.SetActive(true);
        if (winSFX != null) AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position, 0.2f);
        yield return new WaitForSeconds(delayToLoadNextScene);
        GetComponent<LevelLoader>().LoadNextScene();
    }

    public void OnLevelLose()
    {
        loseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
