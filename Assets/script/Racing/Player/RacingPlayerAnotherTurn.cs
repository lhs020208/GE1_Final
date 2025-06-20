using UnityEngine;

public class RacingPlayerAnotherTurn : MonoBehaviour
{
    public Rigidbody rb;
    public RacingPlayerStatusManager status;
    public float CarTurnTorque = 5.0f; // 회전 힘의 세기

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        status = GetComponent<RacingPlayerStatusManager>();
    }

    void FixedUpdate()
    {
        if (!status.IsContact)
        {
            float torque = 0f;
            if (status.PushW)
                torque = CarTurnTorque;
            else if (status.PushS)
                torque = -CarTurnTorque;

            if (torque != 0f)
            {
                rb.AddTorque(transform.right * torque, ForceMode.Force);
            }
        }
    }
}
