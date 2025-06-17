using UnityEngine;
using UnityEngine.InputSystem;

public class RacingPlayerStatusManager : MonoBehaviour
{
    public GameObject LeftWheel;
    public GameObject RightWheel;

    public bool IsContact = false;
    public bool PushW = false;
    public bool PushS = false;
    public bool PushA = false;
    public bool PushD = false;

    Vector2 Move;

    public GameObject SM;

    void Start()
    {
        SM = GameObject.Find("SceneManager");
    }

    void Update()
    {

    }
    void OnCollisionStay(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            //IsContact = true;
            return;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        //IsContact = false;
    }

    void OnWASDMove(InputValue value)
    {
        Move = value.Get<Vector2>();

        PushW = Move.y > 0;
        PushS = Move.y < 0;
        PushA = Move.x < 0;
        PushD = Move.x > 0;
    }
}
