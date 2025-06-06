using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    PlayerStatusManager Status;
    public float accel = 20.0f;
    public float maxForwardSpeed = 10.0f;
    public float maxBackwardSpeed = 5.0f;
    public float maxSideSpeed = 7.0f;

    int moveDir = 0;
    int sideDir = 0;

    CharacterController cc;

    float verticalSpeed = 0f;
    float forwardSpeed = 0f;
    float sideSpeed = 0f;

    void Start()
    {
        Status = GetComponent<PlayerStatusManager>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Status.PushW && moveDir == 0)
            moveDir = 1;
        if (Status.PushS && moveDir == 0)
            moveDir = -1;
        if (!Status.PushW && moveDir == 1)
            moveDir = 0;
        if (!Status.PushS && moveDir == -1)
            moveDir = 0;

        if (Status.PushD && sideDir == 0)
            sideDir = 1;
        if (Status.PushA && sideDir == 0)
            sideDir = -1;
        if (!Status.PushD && sideDir == 1)
            sideDir = 0;
        if (!Status.PushA && sideDir == -1)
            sideDir = 0;
    }

    void FixedUpdate()
    {
        if (moveDir == 1)
        {
            forwardSpeed += accel * Time.fixedDeltaTime;
            if (forwardSpeed > maxForwardSpeed)
                forwardSpeed = maxForwardSpeed;
        }
        else if (moveDir == -1)
        {
            forwardSpeed -= accel * Time.fixedDeltaTime;
            if (forwardSpeed < -maxBackwardSpeed)
                forwardSpeed = -maxBackwardSpeed;
        }
        else
        {
            forwardSpeed = Mathf.MoveTowards(forwardSpeed, 0, accel * Time.fixedDeltaTime);
        }

        if (sideDir == 1)
        {
            sideSpeed += accel * Time.fixedDeltaTime;
            if (sideSpeed > maxSideSpeed)
                sideSpeed = maxSideSpeed;
        }
        else if (sideDir == -1)
        {
            sideSpeed -= accel * Time.fixedDeltaTime;
            if (sideSpeed < -maxSideSpeed)
                sideSpeed = -maxSideSpeed;
        }
        else
        {
            sideSpeed = Mathf.MoveTowards(sideSpeed, 0, accel * Time.fixedDeltaTime);
        }

        Vector3 move = transform.forward * forwardSpeed + transform.right * sideSpeed + Vector3.up * verticalSpeed;
        cc.Move(move * Time.fixedDeltaTime);
    }
}
