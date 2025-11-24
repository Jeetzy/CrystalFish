using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public AudioMixer audioMixer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        bool paused = !pausePanel.activeSelf;
        pausePanel.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }

    public void Mute(bool mute)
    {
        audioMixer.SetFloat("MasterVolume", mute ? -80f : Mathf.Log10(PlayerPrefs.GetFloat("MasterVolume")) * 20f);
    }

}
