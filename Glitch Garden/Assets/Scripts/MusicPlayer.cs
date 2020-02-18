using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float _volume)
    {
        audioSource.volume = _volume;
    }
}
