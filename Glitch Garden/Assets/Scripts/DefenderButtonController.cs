using UnityEngine;

public class DefenderButtonController : MonoBehaviour
{
    [SerializeField] DefenderButton[] defenderSpawnButtons;
    [SerializeField] Color selectedColor, notSelectedColor;

    private void Start()
    {
        foreach (DefenderButton defenderButton in defenderSpawnButtons)
        {
            defenderButton.button.onClick.AddListener(() => { SelectDefender(defenderButton); }) ;
        }
    }

    public void SelectDefender(DefenderButton defenderButton)
    {
        foreach (DefenderButton button in defenderSpawnButtons)
        {
            button.image.color = notSelectedColor;
        }

        defenderButton.image.color = selectedColor;
        DefenderSpawner.instance.SetSelectedDefender(defenderButton.defender);
    }
}
