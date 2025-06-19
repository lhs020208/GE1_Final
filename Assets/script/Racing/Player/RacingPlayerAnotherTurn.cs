using UnityEngine;

public class RacingPlayerAnotherTurn : MonoBehaviour
{
    public Rigidbody rb;
    public RacingPlayerStatusManager status;
    public float CarTurnSpeed = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        status = GetComponent<RacingPlayerStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!status.IsContact)
        {
            float angle = 0f;
            if (status.PushW)
                angle = CarTurnSpeed * Time.deltaTime;
            else if (status.PushS)
                angle = -CarTurnSpeed * Time.deltaTime;

            if (angle != 0f)
            {
                Quaternion deltaRotation = Quaternion.Euler(angle, 0f, 0f); // x√‡ »∏¿¸
                rb.MoveRotation(rb.rotation * deltaRotation);
            }
        }
    }
}
