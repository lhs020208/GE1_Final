using UnityEngine;
using UnityEngine.InputSystem;

public class RacingPlayerStatusManager : MonoBehaviour
{
    public GameObject LeftWheel;
    public GameObject RightWheel;
    public GameObject LeftBackWheel;
    public GameObject RightBackWheel;

    public bool IsContact = false;
    public bool PushW = false;
    public bool PushS = false;
    public bool PushA = false;
    public bool PushD = false;
    public bool PushQ = false;
    public bool PushE = false;
    float verticalInput;

    Vector2 Move;
    Vector3 Up;

    public GameObject SM;
    Rigidbody rb;

    void Start()
    {
        SM = GameObject.Find("SceneManager");
        rb = GetComponent<Rigidbody>();
        //rb.centerOfMass = new Vector3(0, -0.5f, 0);
    }

    void Update()
    {
        Up = transform.up;
    }
    void OnCollisionStay(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            IsContact = true;
            return;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        IsContact = false;
    }

    void OnWASDMove(InputValue value)
    {
        Move = value.Get<Vector2>();

        PushW = Move.y > 0;
        PushS = Move.y < 0;
        PushA = Move.x < 0;
        PushD = Move.x > 0;
    }
    void OnQEMove(InputValue value)
    {
        verticalInput = value.Get<float>();

        PushQ = verticalInput > 0;
        PushE = verticalInput < 0;
    }
}
