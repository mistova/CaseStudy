using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    [SerializeField]
    int innerSquare, outterSquare;

    //[HideInInspector]
    internal bool state = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.GetComponent<Item>().SetTrigger(transform, innerSquare, outterSquare, state);
        }
    }
}
