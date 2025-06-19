using UnityEngine;

public class RacingPlayerTurn : MonoBehaviour
{
    public Rigidbody rb;
    public RacingPlayerStatusManager status;
    public float WheelTurnSpeed = 0.3f;
    public float CarTurnSpeed = 0.1f;
    public float IsCanTurnSpeed = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        status = GetComponent<RacingPlayerStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float leftAngle = status.LeftWheel.transform.localEulerAngles.y;
        if (leftAngle > 180f) leftAngle -= 360f;
        float speedInForward = Vector3.Dot(rb.linearVelocity, transform.forward);

        if (status.PushA && !status.PushD)
        {
            if (leftAngle > -45.0f)
            {
                status.LeftWheel.transform.Rotate(Vector3.up, -WheelTurnSpeed, Space.Self);
                status.RightWheel.transform.Rotate(Vector3.up, -WheelTurnSpeed, Space.Self);
            }
            if (status.IsContact)
            {
                if (speedInForward > IsCanTurnSpeed)
                {
                    rb.transform.Rotate(Vector3.up, -CarTurnSpeed * Time.deltaTime, Space.Self);
                }
                else if (speedInForward < -IsCanTurnSpeed)
                {
                    rb.transform.Rotate(Vector3.up, CarTurnSpeed * Time.deltaTime, Space.Self);
                }
            }
            else
            {
                rb.transform.Rotate(Vector3.up, -CarTurnSpeed * Time.deltaTime, Space.Self);
            }
        }
        else if (status.PushD && !status.PushA)
        {
            if (leftAngle < 45.0f)
            {
                status.LeftWheel.transform.Rotate(Vector3.up, WheelTurnSpeed, Space.Self);
                status.RightWheel.transform.Rotate(Vector3.up, WheelTurnSpeed, Space.Self);
            }
            if (status.IsContact)
            {
                if (speedInForward > IsCanTurnSpeed)
                {
                    rb.transform.Rotate(Vector3.up, CarTurnSpeed * Time.deltaTime, Space.Self);
                }
                else if (speedInForward < -IsCanTurnSpeed)
                {
                    rb.transform.Rotate(Vector3.up, -CarTurnSpeed * Time.deltaTime, Space.Self);
                }
            }
            else
            {
                rb.transform.Rotate(Vector3.up, CarTurnSpeed * Time.deltaTime, Space.Self);
            }
        }
        else
        {
            if (leftAngle > 1.0f)
            {
                status.LeftWheel.transform.Rotate(Vector3.up, -WheelTurnSpeed, Space.Self);
                status.RightWheel.transform.Rotate(Vector3.up, -WheelTurnSpeed, Space.Self);
            }
            else if (leftAngle < -1.0f)
            {
                status.LeftWheel.transform.Rotate(Vector3.up, WheelTurnSpeed, Space.Self);
                status.RightWheel.transform.Rotate(Vector3.up, WheelTurnSpeed, Space.Self);
            }
            else
            {
                // 거의 0도면 정확히 고정
                Vector3 eul = status.LeftWheel.transform.localEulerAngles;
                eul.y = 0.0f;
                status.LeftWheel.transform.localEulerAngles = eul;

                eul = status.RightWheel.transform.localEulerAngles;
                eul.y = 0.0f;
                status.RightWheel.transform.localEulerAngles = eul;
            }
        }
    }
}

