using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text endScoreText;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private SettingsManager settingsManager;

    private int score;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!settingsUI.activeInHierarchy) 
            { 
                settingsUI.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                settingsUI.SetActive(false);
                settingsManager.ApplySettings();
                Time.timeScale = 1;
            }
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void DisplayEndScore()
    {
        endScoreText.text = "Score: " + score;
    }
}
