using UnityEngine;
using UnityEngine.Events;

public class DefenderSpawner : MonoBehaviour
{
    public static DefenderSpawner instance { get; private set; }

    public UnityEventInt OnStarPointsUpdate = new UnityEventInt();
    Defender currentDefender;

    [SerializeField] int startStarPointsAmount = 300;
    int currentStarPoints;
    public int CurrentStarPoints { get => currentStarPoints; 
        set 
        { 
            currentStarPoints = value;
            OnStarPointsUpdate?.Invoke(currentStarPoints);
        } 
    }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        CurrentStarPoints = startStarPointsAmount;
    }

    private void OnMouseDown()
    {
        SpawnDefender(GetClickedSquarePosition());
    }

    public void SpawnDefender(Vector2 worldPos)
    {
        if (!currentDefender) return;

        if (CurrentStarPoints >= currentDefender.GetStarCost())
        { 
            Defender defender = Instantiate(currentDefender, worldPos, Quaternion.identity) as Defender;
            defender.transform.parent = transform;
            CurrentStarPoints -= currentDefender.GetStarCost();
        }
    }

    Vector2 GetClickedSquarePosition()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x = Mathf.Round(mousePos.x);
        mousePos.y = Mathf.Round(mousePos.y);

        return mousePos;
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        currentDefender = selectedDefender;
    }

}


public class UnityEventInt : UnityEvent<int> { }