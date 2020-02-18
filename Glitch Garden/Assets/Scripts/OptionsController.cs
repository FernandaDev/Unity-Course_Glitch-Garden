using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.5f;

    [SerializeField] Slider difficultySlider;
    [SerializeField] int defaultDifficulty = 1;

    MusicPlayer m_MusicPlayer;

    private void Awake()
    {
        m_MusicPlayer = FindObjectOfType<MusicPlayer>();

        if (!m_MusicPlayer)
            Debug.LogWarning("Music player not found!");
    }

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    public void SetVolumeFromSlider(float sliderValue)
    {
        m_MusicPlayer.SetVolume(sliderValue);
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty((int)difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMenuScene();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }

}
