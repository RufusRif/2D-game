using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SpriteFlipper : MonoBehaviour
{
    private float direction;

    private void Flip(float moveDirection)
    {
        if (moveDirection != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * Mathf.Sign(moveDirection);
            transform.localScale = scale;
        }   
    }
    public void SetFlipDirection(float newDirection)
    {
        direction = newDirection;
        Flip(direction);
    }
}