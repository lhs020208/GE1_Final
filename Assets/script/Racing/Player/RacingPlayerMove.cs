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

        Vector3 velocity = rb.linearVelocity;

        float currentSpeed = Vector3.Dot(velocity, forward);

        float lateralSpeed = Vector3.Dot(velocity, right);
        Vector3 lateralVelocity = right * lateralSpeed;
        velocity -= lateralVelocity * 0.2f; 

        velocity.y = rb.linearVelocity.y;
        rb.linearVelocity = velocity;

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
