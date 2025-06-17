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
        float currentSpeed = Vector3.Dot(rb.linearVelocity, forward);
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
