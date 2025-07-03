using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    public void Die(GameObject target)
    {
        target.SetActive(false);

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
    
}
