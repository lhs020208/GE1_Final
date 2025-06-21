using UnityEngine;

public class GoForward : MonoBehaviour
{
    RCPlayerStatusManager status;
    Rigidbody rb;
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        status = GetComponent<RCPlayerStatusManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (status.PushW)
        {
            rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
            print("Go Forward");
        }
        else if (status.PushS)
            rb.AddForce(transform.forward * -speed, ForceMode.Acceleration);

    }
}
