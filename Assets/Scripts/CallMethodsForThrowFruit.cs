using UnityEngine;

public class CallMethodsForThrowFruit : MonoBehaviour
{
    [SerializeField] private PushRigidBody pushRigidBody;
    [SerializeField] private ChangerLayer changerLayer;

    private void Start()
    {
        pushRigidBody.Push();
        changerLayer.ChangeTheLayer();
    }
}