using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ClickButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
