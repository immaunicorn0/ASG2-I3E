using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = AudioListener.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    private void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void BackToMainMenu()
    {
        gameObject.SetActive(false);
    }
}
