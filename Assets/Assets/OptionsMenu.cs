using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;         // Set Min = 1, Max = 100, Whole Numbers = ON
    public TMP_Text volumeText;

    private bool isInitializing = true;

    private void Start()
    {
        // Load saved volume (default = 100)
        int savedVolume = PlayerPrefs.GetInt("MasterVolumeInt", 100);

        // Prevent OnValueChanged from firing during initialization
        isInitializing = true;

        volumeSlider.value = savedVolume;
        UpdateVolumeUI(savedVolume);

        isInitializing = false;

        // Apply the volume to mixer once initialization finishes
        ApplyVolume(savedVolume);
    }

    public void SetVolume(float sliderValue)
    {
        if (isInitializing) return; // Stop bouncing bug

        UpdateVolumeUI(sliderValue);
        ApplyVolume(sliderValue);

        // Save the values
        PlayerPrefs.SetInt("MasterVolumeInt", (int)sliderValue);
        PlayerPrefs.SetFloat("MasterVolume", Mathf.Clamp(sliderValue / 100f, 0.0001f, 1f));
    }

    private void UpdateVolumeUI(float sliderValue)
    {
        volumeText.text = Mathf.RoundToInt(sliderValue).ToString();
    }

    private void ApplyVolume(float sliderValue)
    {
        float normalized = Mathf.Clamp(sliderValue / 100f, 0.0001f, 1f);
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(normalized) * 20f);
    }
}
