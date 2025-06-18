using UnityEngine;

public class StepClimber : MonoBehaviour
{
    public float stepHeight = 0.4f;        // 넘을 수 있는 최대 단차 높이
    public float stepCheckDistance = 0.5f; // 전방 거리
    public float stepSmooth = 5.0f;        // 보간 속도

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 발 위치 기준 기준점 (약간 위에서 쏘는 게 안정적)
        Vector3 origin = transform.position + Vector3.up * 0.1f;

        // 전방 아래 방향 Ray로 단차 감지
        Vector3 direction = transform.forward;
        Vector3 checkPoint = origin + direction * stepCheckDistance;

        // 1. 앞쪽 바닥 감지
        if (Physics.Raycast(checkPoint + Vector3.up * stepHeight, Vector3.down, out RaycastHit hit, stepHeight + 0.1f))
        {
            float hitHeight = hit.point.y;
            float bottom = transform.position.y;

            float step = hitHeight - bottom;

            // 2. 일정 이하 높이면 부드럽게 올림
            if (step > -0.05f && step <= stepHeight)
            {
                Vector3 targetPos = new Vector3(transform.position.x, hit.point.y, transform.position.z);
                rb.position = Vector3.Lerp(rb.position, targetPos, Time.fixedDeltaTime * stepSmooth);
            }
        }
    }
}
