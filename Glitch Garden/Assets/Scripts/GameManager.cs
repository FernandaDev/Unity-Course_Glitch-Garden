using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] int startStarPoints = 300;
    int currentStarPoints;
    int CurrentStarPoints{
        get { return currentStarPoints; }
        set {
            currentStarPoints = value;
            OnStarPointsUpdate?.Invoke(currentStarPoints);
        }
    }

    [SerializeField] int startLifePoints = 100;
    int currentLifePoints;
    int CurrentLifePoints{
        get { return currentLifePoints; }
        set
        {
            currentLifePoints = value;
            OnLifePointsUpdate?.Invoke(currentLifePoints);
        }
    }

    [Tooltip("Our level timer in SECONDS.")]
    public int levelTime = 10;
    bool levelTimerFinished = false;
    [SerializeField] AudioClip winSFX;
    int numberOfAttackers = 0;

    public float delayTimeToNextLevel = 2f;

    public UnityEventInt OnStarPointsUpdate = new UnityEventInt();
    public UnityEventInt OnLifePointsUpdate = new UnityEventInt();
    [HideInInspector]public UnityEvent OnLevelComplete = new UnityEvent();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        CurrentStarPoints = startStarPoints;
        CurrentLifePoints = startLifePoints;
    }

    public bool HasEnoughStars(int cost)
    {
        if (CurrentStarPoints >= cost)
        {
            return true;
        }
        return false;
    }

    public void AddStars(int amount){CurrentStarPoints += amount;}

    public void RemoveStars(int amount){CurrentStarPoints -= amount;}

    public void RemoveLifePoints(int amount)
    {
        CurrentLifePoints -= amount;
        if (CurrentLifePoints <= 0)
            FindObjectOfType<LevelLoader>().LoadMenuScene();
    }

    public void AddAttackerCount(){numberOfAttackers++;}

    public void RemoveAttackerCount()
    {
        numberOfAttackers--;

        if(numberOfAttackers <= 0 && levelTimerFinished)
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
        OnLevelComplete?.Invoke();
        if(winSFX!=null) AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position,0.2f);
        yield return new WaitForSeconds(delayToLoadNextScene);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }
}


public class UnityEventInt : UnityEvent<int> { }