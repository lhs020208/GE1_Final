using UnityEngine;

public class EnemyFall : MonoBehaviour
{
    EnemyStatusManager Status;
    CharacterController cc;

    float verticalSpeed = 0f;
    const float gravity = 9.81f;

    void Start()
    {
        Status = GetComponent<EnemyStatusManager>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (cc.isGrounded)
        {
            verticalSpeed = 0f;
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        Vector3 move = new Vector3(0, verticalSpeed, 0);
        cc.Move(move * Time.deltaTime);
    }
}
