using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject gameWinCanvas;

    private void Start()
    {
        SoundManager.Instance.PlayMusic("GameMusic");
    }
    public void Die(GameObject target)
    {
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayMusic("PlayerDeathMusic");
        target.SetActive(false);
       
        StartCoroutine(ShowCanvasWithDelay(ShowDeathCanvas));
    }
    public void Win()
    {
        StartCoroutine(ShowCanvasWithDelay(ShowWinCanvas));
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayMusic("WinMusic");
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
        Debug.Log("Кнопка нажата. SceneManager.LoadScene(StartScene) ");
        ResumeGame();
        SceneManager.LoadScene("StartScene");
        SoundManager.Instance.PlayMusic("MenuMusic");
        Debug.Log("должна была проиграться музыка MenuMusic ");
    }

    private IEnumerator ShowCanvasWithDelay(Action showCanvas)
    {
        yield return new WaitForSeconds(3f);
        showCanvas?.Invoke();
    }
}
