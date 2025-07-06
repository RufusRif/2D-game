using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject gameWinCanvas;
    public void Die(GameObject target)
    {
        target.SetActive(false);
       
        StartCoroutine(ShowCanvasWithDelay(ShowDeathCanvas));
    }
    public void Win()
    {
        StartCoroutine(ShowCanvasWithDelay(ShowWinCanvas));
    }
    public void ShowWinCanvas()
    {
        gameWinCanvas.SetActive(true);
        StopGame();
    }
    public void ShowDeathCanvas()
    {
        gameOverCanvas.SetActive(true);
        StopGame();

    }
    public void StopGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void RestartGame()
    {
        ResumeGame();
        SceneManager.LoadScene("GameScene");

    }
    public void GoToMenu()
    {
        ResumeGame();
        SceneManager.LoadScene("StartScene");
    }

    private IEnumerator ShowCanvasWithDelay(Action showCanvas)
    {
        yield return new WaitForSeconds(3f);
        showCanvas?.Invoke();
    }
}
