using UnityEngine;
using TMPro;

public class UIDisplayController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI starPointsText;

    private void OnEnable()
    {
        DefenderSpawner.instance.OnStarPointsUpdate.AddListener(SetStarPointsText);
    }

    private void OnDisable()
    {
        DefenderSpawner.instance.OnStarPointsUpdate.RemoveListener(SetStarPointsText);
    }

    void SetStarPointsText(int starAmount)
    {
        starPointsText.text = starAmount.ToString();
    }

}
