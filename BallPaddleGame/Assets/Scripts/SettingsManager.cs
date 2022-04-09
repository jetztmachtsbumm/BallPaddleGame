using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private InputField fpslimitInput;
    [SerializeField] private Toggle vSyncToggle;
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Slider volumeSlider;

    private void Awake()
    {
        LoadSettings();
    }

    public void OnBackButtonClicked()
    {
        ApplySettings();

        if(mainMenuUI == null)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            mainMenuUI.SetActive(true);
            settingsUI.SetActive(false);
        }
    }

    //For game over screen
    public void OnRetryButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void OnSetToRefreshRateButtonClicked()
    {
        fpslimitInput.text = Screen.currentResolution.refreshRate + "";
    }

    public void ApplySettings()
    {
        Application.targetFrameRate = int.Parse(fpslimitInput.text) + 1;
        QualitySettings.vSyncCount = vSyncToggle.isOn ? 1 : 0;
        Screen.fullScreenMode = fullscreenToggle.isOn ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;
        AudioListener.volume = volumeSlider.value;

        SaveSettings();
    }

    private void LoadSettings()
    {
        if(PlayerPrefs.GetInt("fpsLimit") == 0)
        {
            fpslimitInput.text = "60";
            vSyncToggle.isOn = false;
            fullscreenToggle.isOn = true;
            volumeSlider.value = 0.5f;
        }
        else
        {
            fpslimitInput.text = "" + PlayerPrefs.GetInt("fpsLimit");
            vSyncToggle.isOn = PlayerPrefs.GetInt("vsyncOn") == 1 ? true : false;
            fullscreenToggle.isOn = PlayerPrefs.GetInt("fullscreen") == 1 ? true : false;
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
        }

        ApplySettings();
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetInt("fpsLimit", int.Parse(fpslimitInput.text));
        PlayerPrefs.SetInt("vsyncOn", vSyncToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("fullscreen", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }

}
