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

    public UnityEventInt OnStarPointsUpdate = new UnityEventInt();
    public UnityEventInt OnLifePointsUpdate = new UnityEventInt();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        CurrentStarPoints = startStarPoints / PlayerPrefsController.GetDifficulty();
        CurrentLifePoints = startLifePoints / PlayerPrefsController.GetDifficulty();
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
            LevelController.instance.OnLevelLose();
    }

}


public class UnityEventInt : UnityEvent<int> { }