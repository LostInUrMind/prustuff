using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMP_Text gameOverText;
    private string gameOverMessage = "Game Over!";
    private string victoryMessage = "You Won!";
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver(int finalScore)
    {
        gameOverPanel.SetActive(true);
        StartCoroutine(ShowScoreAndRestart(finalScore, gameOverMessage));
    }

    public void ShowVictory(int finalScore)
    {
        gameOverPanel.SetActive(true);
        StartCoroutine(ShowScoreAndRestart(finalScore, victoryMessage));
    }

    IEnumerator ShowScoreAndRestart(int finalScore, string message)
    {
        Debug.Log("Start freeze");

        Time.timeScale = 0;
        gameOverText.text = message + "\nFinal Score: " + finalScore.ToString();
        Debug.Log(gameOverText.text);
        Canvas.ForceUpdateCanvases();
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1;

        Debug.Log("Stop freeze, restarting");

        RestartGame();
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
