using UnityEngine;

public class DebugCheck : MonoBehaviour
{
    public void Up()
    {
        Debug.Log("Up pressed");
    }
    public void Down()
    {
        Debug.Log("Down pressed");
    }

    public void Move()
    {
        Debug.Log("Left or right arrows pressed");
    }
    public void Action()
    {
        Debug.Log("Space pressed");
    }
}
