using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.PlayMusic("MenuMusic");
    }
    public void ClickButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
