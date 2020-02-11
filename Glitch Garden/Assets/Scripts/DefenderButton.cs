using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    public Defender defender;
    public Button button { get; private set; }
    public Image image { get; private set; }

    TextMeshProUGUI starCostText;

    private void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();

        starCostText = GetComponentInChildren<TextMeshProUGUI>();

        starCostText.text = defender?.GetStarCost().ToString();
    }
}
