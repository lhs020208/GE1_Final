using UnityEngine;

public class RacingPlayerTurn : MonoBehaviour
{
    public Rigidbody rb;
    public RacingPlayerStatusManager status;
    public float WheelTurnSpeed = 0.3f;
    public float CarTurnSpeed = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        status = GetComponent<RacingPlayerStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = status.LeftWheel.transform.rotation.eulerAngles.y;
        if (angle > 180f) angle -= 360f;
        float speedInForward = Vector3.Dot(rb.linearVelocity, transform.forward);

        if (status.PushA)
        {
            if (angle > -45.0f)
            {
                status.LeftWheel.transform.Rotate(Vector3.up, -WheelTurnSpeed);
                status.RightWheel.transform.Rotate(Vector3.up, -WheelTurnSpeed);
            }
            if (speedInForward > 0)
            {
                rb.transform.Rotate(Vector3.up, -CarTurnSpeed);
            }
            else if (speedInForward < 0)
            {
                rb.transform.Rotate(Vector3.up, CarTurnSpeed);
            }
        }
        else
        {
            if (angle < 0.0f)
            {
                status.LeftWheel.transform.Rotate(Vector3.up, WheelTurnSpeed);
                status.RightWheel.transform.Rotate(Vector3.up, WheelTurnSpeed);
            }
        }
        if (status.PushD)
        {
            if (angle < 45.0f)
            {
                status.LeftWheel.transform.Rotate(Vector3.up, WheelTurnSpeed);
                status.RightWheel.transform.Rotate(Vector3.up, WheelTurnSpeed);
            }
            if (speedInForward > 0)
            {
                rb.transform.Rotate(Vector3.up, CarTurnSpeed);
            }
            else if (speedInForward < 0)
            {
                rb.transform.Rotate(Vector3.up, -CarTurnSpeed);
            }
        }
        else
        {
            if (angle > 0.0f)
            {
                status.LeftWheel.transform.Rotate(Vector3.up, -WheelTurnSpeed);
                status.RightWheel.transform.Rotate(Vector3.up, -WheelTurnSpeed);
            }
        }
    }
}

