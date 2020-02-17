using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplayController : MonoBehaviour
{
    [SerializeField] Transform completeLevelPanel;
    [SerializeField] TextMeshProUGUI starPointsText;
    [SerializeField] TextMeshProUGUI lifesPointsText;
    [SerializeField] Slider timerSlider;
    bool timeHasFinished = false;

    GameManager m_GameManager;

    private void Awake()
    {
        m_GameManager = GameManager.instance;
        completeLevelPanel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        m_GameManager.OnStarPointsUpdate.AddListener(SetStarPointsText);
        m_GameManager.OnLifePointsUpdate.AddListener(SetLifePointsText);
        m_GameManager.OnLevelComplete.AddListener(ShowLevelCompletePanel);
    }

    private void OnDisable()
    {
        m_GameManager.OnStarPointsUpdate.RemoveListener(SetStarPointsText);
        m_GameManager.OnLifePointsUpdate.RemoveListener(SetLifePointsText);
        m_GameManager.OnLevelComplete.RemoveListener(ShowLevelCompletePanel);
    }

    private void Update()
    {
        if (timeHasFinished) return;
        
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timerSlider.value = Time.timeSinceLevelLoad / m_GameManager.levelTime;

        timeHasFinished = (Time.timeSinceLevelLoad >= m_GameManager.levelTime);
        if (timeHasFinished)
            m_GameManager.LevelTimerHasFinished();
    }

    void SetStarPointsText(int starAmount)
    {
        starPointsText.text = starAmount.ToString();
    }

    void SetLifePointsText(int lifeAmount)
    {
        lifesPointsText.text = lifeAmount.ToString();
    }

    void ShowLevelCompletePanel()
    {
        completeLevelPanel.gameObject.SetActive(true);
    }

}
