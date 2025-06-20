using UnityEngine;

public class GoForward : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.right * -speed, ForceMode.Acceleration);

    }
}
