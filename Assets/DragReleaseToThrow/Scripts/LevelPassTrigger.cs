using UnityEngine;
using UnityEngine.Events;

public class LevelPassTrigger : MonoBehaviour
{
    [SerializeField]
    UnityEvent onFinishEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            onFinishEvent.Invoke();
        }
    }
}
