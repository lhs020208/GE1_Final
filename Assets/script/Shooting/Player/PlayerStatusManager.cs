using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerStatusManager : MonoBehaviour
{
    public bool IsContact = false;
    public bool PushW = false;
    public bool PushS = false;
    public bool PushA = false;
    public bool PushD = false;
    public bool PushAlt = false;
    public bool LeftClick = false;
    public bool RightClick = false;

    public GameObject Picking = null;

    Vector2 Move;

    public GameObject SM;

    void Start()
    {
        SM = GameObject.Find("SceneManager");
    }

    void Update()
    {
        if (Picking) PushAlt = false;
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
    void OnAim(InputValue value)
    {
        PushAlt = value.Get<float>() > 0.5f;
    }

    void OnClickLeft(InputValue value)
    {
        LeftClick = value.Get<float>() > 0.5f;
    }
    void OnClickRight(InputValue value)
    {
        RightClick = value.Get<float>() > 0.5f;
    }
}
