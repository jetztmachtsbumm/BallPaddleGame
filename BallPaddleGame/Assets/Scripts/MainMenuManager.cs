using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private GameObject settingsUI;

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnSettingsButtonClicked()
    {
        settingsUI.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnQuitButonClicked()
    {
        Application.Quit();
    }
}
