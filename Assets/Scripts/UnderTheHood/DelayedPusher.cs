using System.Collections;
using UnityEngine;

public class DelayedPusher : MonoBehaviour
{
    [SerializeField] private PushRigidBody pushRigidBody;
    [SerializeField] private float delay = 0.05f;

    private void Start()
    {
        StartCoroutine(DelayAndPush());
    }
    private IEnumerator DelayAndPush()
    {
        yield return new WaitForSeconds(delay);
        pushRigidBody.Push();
    }

}
