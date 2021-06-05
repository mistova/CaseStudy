using UnityEngine;

public class ClickControll : MonoBehaviour
{
    Transform selectedItem;

    [SerializeField]
    float riseAmount;

    [SerializeField]
    float speed;

    Vector3 clickedPosition;
    Vector3 clickedItemPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Clicked();
        else if (Input.GetMouseButton(0))
            Move();
        else if (Input.GetMouseButtonUp(0))
            UnClicked();
    }

    private void Move()
    {
        if(selectedItem != null)
        {
            Vector3 pos = Input.mousePosition - clickedPosition;
            float x, z;

            x = pos.x * speed + clickedItemPosition.x;
            z = pos.y * speed + clickedItemPosition.z;

            selectedItem.position = new Vector3(x, selectedItem.position.y, z);
        }
    }

    private void UnClicked()
    {
        DropItem();
    }

    private void DropItem()
    {
        if(selectedItem != null)
            selectedItem.GetComponent<Item>().PlaceItem();
        selectedItem = null;
    }

    private void Clicked()
    {
        clickedPosition = Input.mousePosition;
        SelectItem();
    }

    void SelectItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.gameObject.CompareTag("Item"))
            {
                selectedItem = hit.transform;
                selectedItem.position += Vector3.up * riseAmount;

                clickedItemPosition = selectedItem.position;
            }
        }
    }
}
