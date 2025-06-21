using UnityEngine;

public class Fix : MonoBehaviour
{
    RCPlayerStatusManager status;
    Rigidbody rb;
    public float power = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        status = GetComponent<RCPlayerStatusManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (status.IsContact)
            rb.AddForce(-transform.up * power, ForceMode.Force);

    }
}
