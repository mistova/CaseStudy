using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    int value;

    Transform trigger;
    int outterSquare, innerSquare;
    Vector3 startPosition;

    bool state;

    private void Start()
    {
        startPosition = transform.position;
    }

    internal void SetTrigger(Transform triggerTransform, int inner, int outter, bool state)
    {
        Transform oldTriggerObject = trigger;
        this.state = state;
        trigger = triggerTransform;
        if (oldTriggerObject == null)
        {
            outterSquare = outter;
            innerSquare = inner;
            PlaceItem();
        }
        else if (state)
        {
            oldTriggerObject.gameObject.GetComponent<ItemTrigger>().state = true;
            SquareControll.instance.UnLoadSquare(innerSquare, outterSquare);
            outterSquare = outter;
            innerSquare = inner;
        }
    }

    internal void PlaceItem()
    {
        if (state)
        {
            transform.position = trigger.position;
            startPosition = trigger.position;
            SquareControll.instance.LoadSquare(value, innerSquare, outterSquare);
            trigger.gameObject.GetComponent<ItemTrigger>().state = false;
        }
        else
        {
            transform.position = startPosition;
        }
    }
}
