using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplayController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI starPointsText;
    [SerializeField] TextMeshProUGUI lifesPointsText;
    [SerializeField] Slider timerSlider;
    bool timeHasFinished = false;

    GameManager m_GameManager;
    LevelController m_LevelController;

    private void Awake()
    {
        m_GameManager = GameManager.instance;
        m_LevelController = LevelController.instance;
    }

    private void OnEnable()
    {
        m_GameManager.OnStarPointsUpdate.AddListener(SetStarPointsText);
        m_GameManager.OnLifePointsUpdate.AddListener(SetLifePointsText);
    }

    private void OnDisable()
    {
        m_GameManager.OnStarPointsUpdate.RemoveListener(SetStarPointsText);
        m_GameManager.OnLifePointsUpdate.RemoveListener(SetLifePointsText);
    }

    private void Update()
    {
        if (timeHasFinished) return;
        
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timerSlider.value = Time.timeSinceLevelLoad / m_LevelController.levelTime;

        timeHasFinished = (Time.timeSinceLevelLoad >= m_LevelController.levelTime);
        if (timeHasFinished)
            m_LevelController.LevelTimerHasFinished();
    }

    void SetStarPointsText(int starAmount)
    {
        starPointsText.text = starAmount.ToString();
    }

    void SetLifePointsText(int lifeAmount)
    {
        lifesPointsText.text = lifeAmount.ToString();
    }
}
