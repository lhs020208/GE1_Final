using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingRoad : MonoBehaviour
{
    public int moveType; // 1 = x, 2 = y, 3 = z
    public float moveSpeed = 1.0f;

    public float MaxDistance;
    public float MinDistance;

    private Vector3 startPos;
    private Vector3 moveDir = Vector3.zero;
    private Rigidbody rb;

    private float direction = 1f;       // 현재 방향 (보간됨)
    private float targetDirection = 1f; // 목표 방향
    public float directionSmooth = 2f;  // 회전 보간 속도

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation; // 1. 회전 고정

        startPos = transform.position;

        // 이동 방향 설정
        switch (moveType)
        {
            case 1: moveDir = Vector3.right; break;
            case 2: moveDir = Vector3.up; break;
            case 3: moveDir = Vector3.forward; break;
            default: moveDir = Vector3.zero; break;
        }
    }

    private void FixedUpdate()
    {
        if (moveDir == Vector3.zero) return;

        float moved = Vector3.Dot(transform.position - startPos, moveDir);

        if (moved > MaxDistance)
        {
            transform.position = startPos + moveDir * MaxDistance;
            targetDirection = -1f; // ← 목표만 바꿈
        }
        else if (moved < MinDistance)
        {
            transform.position = startPos + moveDir * MinDistance;
            targetDirection = 1f; // ← 목표만 바꿈
        }

        // 현재 방향을 목표 방향으로 서서히 보간
        direction = Mathf.MoveTowards(direction, targetDirection, directionSmooth * Time.fixedDeltaTime);

        // 등속 이동 + 다른 축 제거
        Vector3 velocity = moveDir * moveSpeed * direction;
        if (moveType == 1) rb.linearVelocity = new Vector3(velocity.x, 0, 0);
        else if (moveType == 2) rb.linearVelocity = new Vector3(0, velocity.y, 0);
        else if (moveType == 3) rb.linearVelocity = new Vector3(0, 0, velocity.z);
    }

}
