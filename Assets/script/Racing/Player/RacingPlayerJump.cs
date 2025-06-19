using UnityEngine;

public class RacingPlayerJump : MonoBehaviour
{
    public Rigidbody rb;
    public RacingPlayerStatusManager status;
    public float JumpForce = 10.0f;

    bool CanDoubleJump = false;
    float mass;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        status = GetComponent<RacingPlayerStatusManager>();
        mass = rb.mass; 
    }

    // Update is called once per frame
    void Update()
    {
        if (status.IsContact)
            CanDoubleJump = true;

        if (status.PushSpace)
        {
            if (status.IsContact)
            {
                // 점프를 위해 위로 힘을 가함
                rb.AddForce(Vector3.up * JumpForce * mass, ForceMode.Impulse);
            }
            else if (CanDoubleJump)
            {
                rb.AddForce(Vector3.up * JumpForce * mass, ForceMode.Impulse);
                CanDoubleJump = false;
            }
                status.PushSpace = false;
        }
    }
}
