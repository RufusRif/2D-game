using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void Die(GameObject target)
    {
        target.SetActive(false);
    }
}
