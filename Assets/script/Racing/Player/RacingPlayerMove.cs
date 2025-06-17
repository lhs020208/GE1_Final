using UnityEngine;

public class RacingPlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public RacingPlayerStatusManager status;

    public float Acceleration = 10.0f;
    public float MaxSpeedForward = 20.0f;
    public float MaxSpeedBack = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        status = GetComponent<RacingPlayerStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        // 전방 속도
        float currentSpeed = Vector3.Dot(rb.linearVelocity, forward);

        // 좌우 속도 분해
        float lateralSpeed = Vector3.Dot(rb.linearVelocity, right);

        // 좌우 속도 감소 적용
        Vector3 lateralVelocity = right * lateralSpeed;
        rb.linearVelocity -= lateralVelocity * 0.2f; // 0.2f: 감속률 (조절 가능)

        // W/S 전후진 가속
        if (status.IsContact)
        {
            if (status.PushW)
            {
                if (currentSpeed < MaxSpeedForward)
                    rb.AddForce(forward * Acceleration, ForceMode.Acceleration);
            }
            else if (status.PushS)
            {
                if (currentSpeed > -MaxSpeedBack)
                    rb.AddForce(-forward * Acceleration, ForceMode.Acceleration);
            }
        }
    }
}
