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
            if (status.PushW)
                rb.transform.Rotate(Vector3.right, CarTurnSpeed * Time.deltaTime, Space.Self);
            else if (status.PushS)
                rb.transform.Rotate(Vector3.right, -CarTurnSpeed * Time.deltaTime, Space.Self);
        }
        //if (status.PushQ)
        //    transform.Rotate(0, 0, CarTurnSpeed * Time.deltaTime * 3);
        //if (status.PushE)
        //    transform.Rotate(0, 0, -CarTurnSpeed * Time.deltaTime * 3);
    }
}
