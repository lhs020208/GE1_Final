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
        // 바닥에 닿아 있으면(즉, 착지 상태) 중력 속도 0, 점프 입력시 점프
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
            // 공중에 있으면 중력 적용
            verticalSpeed -= gravity * Time.deltaTime;
        }

        // 실제 이동 적용 (이 예제에선 y축 이동만)
        Vector3 move = new Vector3(0, verticalSpeed, 0);
        cc.Move(move * Time.deltaTime);
    }

    void OnJump(InputValue value)
    {
        IsJumping = value.Get<float>() > 0.5f;
    }
}
