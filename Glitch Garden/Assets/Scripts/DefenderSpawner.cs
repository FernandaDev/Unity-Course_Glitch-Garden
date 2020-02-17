using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public static DefenderSpawner instance { get; private set; }

    Defender currentDefender;
    
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
    

    private void OnMouseDown()
    {
        SpawnDefender(GetClickedSquarePosition());
    }

    public void SpawnDefender(Vector2 worldPos)
    {
        if (!currentDefender) return;

        if (GameManager.instance.HasEnoughStars(currentDefender.GetStarCost()))
        { 
            Defender defender = Instantiate(currentDefender, worldPos, Quaternion.identity) as Defender;
            defender.transform.parent = transform;
            GameManager.instance.RemoveStars(currentDefender.GetStarCost());
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


