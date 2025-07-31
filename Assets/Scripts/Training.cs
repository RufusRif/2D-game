//using System.Collections;
//using TMPro;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.EventSystems;
//using static UnityEngine.RuleTile.TilingRuleOutput;

//public class Training : MonoBehaviour
//{


//    [SerializeField] private UnityEvent onEnterRaycast;

//    [SerializeField] private UnityEvent onExitRaycast;
//    private bool isPlayerDetected = false;
//    private bool wasPlayerDetected = false;
//    private void Start()
//    {
//        StartCoroutine(CheckRaycastRoutine());
//    }
//    private IEnumerator CheckRaycastRoutine()
//    {
//        while (true)
//        {
//            wasPlayerDetected = isPlayerDetected;
//            isPlayerDetected = DetectPlayer();
//            if (!wasPlayerDetected && isPlayerDetected) { onEnterRaycast?.Invoke(); }
//            if (wasPlayerDetected && !isPlayerDetected) { onExitRaycast?.Invoke(); }
//            yield return null;
//        }
//    }
//    private bool DetectPlayer()
//    {
//        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 5f); if (hit.collider != null && hit.collider.CompareTag("Player"))
//        {
//            return true;
//        }
//        return false;

//    }

//}

