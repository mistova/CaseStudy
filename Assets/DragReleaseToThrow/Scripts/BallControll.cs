using System;
using UnityEngine;

public class BallControll : MonoBehaviour
{
    [SerializeField]
    float pushForce;
    float pushMultiplier;

    [SerializeField]
    float rotationSpeedY;

    Vector3 clickedPosition;
    float clickedRotationY;

    [SerializeField]
    Transform lineStartLocation;

    [SerializeField]
    bool revertY;

    [SerializeField]
    LineRenderer lineRenderer;

    [SerializeField]
    int lineCornerLimit = 2;

    int index;

    int revY;

    bool canUse;

    private void Awake()
    {
        pushMultiplier = pushForce / 10;
        canUse = true;
        if (revertY)
            revY = -1;
        else
            revY = 1;
    }

    void Update()
    {
        if (canUse)
        {
            if (Input.GetMouseButtonDown(0))
                Clicked();
            else if(Input.GetMouseButton(0))
                AngularMovement();
            else if (Input.GetMouseButtonUp(0))
                UnClicked();
        }
    }

    private void AngularMovement()
    {
        Vector3 pos = Input.mousePosition - clickedPosition;
        float y;
        y = revY * (pos.x) * rotationSpeedY + clickedRotationY;
        transform.rotation = Quaternion.Euler(new Vector3(0, y, 0));

        SetForceMultiplier(pos);

        index = 0;
        Vector3 from = lineStartLocation.position;
        Vector3 to = transform.forward;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, from);
        DrawLine(from, to);
    }

    private void SetForceMultiplier(Vector3 pos)
    {
        pushMultiplier = pos.magnitude / 1000;
        if (pushMultiplier < 0.1f)
            pushMultiplier = 0.1f;
        else if (pushMultiplier > 1)
            pushMultiplier = 1;

        UIControll.instance.SetValueForceSlider(pushMultiplier);
    }

    private void DrawLine(Vector3 from, Vector3 to)
    {
        if (index > lineCornerLimit) return;
        if (Physics.Raycast(from, to, out RaycastHit hit))
        {
            if (hit.collider)
            {
                index = lineRenderer.positionCount++;
                lineRenderer.SetPosition(index, hit.point);
                to = Vector3.Reflect(to, hit.normal);
                from = hit.point;
                if (hit.transform.gameObject.CompareTag("Wall"))
                    DrawLine(from, to);
            }
        }
        else
        {
            to *= 100;
            to.y = 1;
            index = lineRenderer.positionCount++;
            lineRenderer.SetPosition(index, to);
        }
    }

    private void Clicked()
    {
        SetActiveSlider(true);
        clickedPosition = Input.mousePosition;
    }

    private void SetActiveSlider(bool state)
    {
        UIControll.instance.SetActiveForceSlider(state);
    }

    private void UnClicked()
    {
        SetActiveSlider(false);
        lineRenderer.positionCount = 0;
        ThrowBall();
        canUse = false;
        clickedRotationY = transform.rotation.eulerAngles.y;

        if (clickedRotationY > 180)
            clickedRotationY -= 360;
    }

    private void ThrowBall()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * pushForce * rb.mass * pushMultiplier, ForceMode.Impulse);
    }
}
