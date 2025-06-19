using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    PlayerStatusManager Status;
    CharacterController cc;
    public bool IsJumping = false;
    public float JumpForce = 20.0f;
    float verticalSpeed = 0f;
    const float gravity = 9.81f;

    void Start()
    {
        Status = GetComponent<PlayerStatusManager>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        // �ٴڿ� ��� ������(��, ���� ����) �߷� �ӵ� 0, ���� �Է½� ����
        if (cc.isGrounded)
        {
            verticalSpeed = 0f;
            if (IsJumping)
            {
                verticalSpeed = JumpForce;
                IsJumping = false;
            }
        }
        else
        {
            // ���߿� ������ �߷� ����
            verticalSpeed -= gravity * Time.deltaTime;
        }

        // ���� �̵� ���� (�� �������� y�� �̵���)
        Vector3 move = new Vector3(0, verticalSpeed, 0);
        cc.Move(move * Time.deltaTime);
    }

    void OnJump(InputValue value)
    {
        IsJumping = value.Get<float>() > 0.5f;
    }
}
