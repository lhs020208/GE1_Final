using UnityEngine;

public class StepClimber : MonoBehaviour
{
    public float stepHeight = 0.4f;        // ���� �� �ִ� �ִ� ���� ����
    public float stepCheckDistance = 0.5f; // ���� �Ÿ�
    public float stepSmooth = 5.0f;        // ���� �ӵ�

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // �� ��ġ ���� ������ (�ణ ������ ��� �� ������)
        Vector3 origin = transform.position + Vector3.up * 0.1f;

        // ���� �Ʒ� ���� Ray�� ���� ����
        Vector3 direction = transform.forward;
        Vector3 checkPoint = origin + direction * stepCheckDistance;

        // 1. ���� �ٴ� ����
        if (Physics.Raycast(checkPoint + Vector3.up * stepHeight, Vector3.down, out RaycastHit hit, stepHeight + 0.1f))
        {
            float hitHeight = hit.point.y;
            float bottom = transform.position.y;

            float step = hitHeight - bottom;

            // 2. ���� ���� ���̸� �ε巴�� �ø�
            if (step > -0.05f && step <= stepHeight)
            {
                Vector3 targetPos = new Vector3(transform.position.x, hit.point.y, transform.position.z);
                rb.position = Vector3.Lerp(rb.position, targetPos, Time.fixedDeltaTime * stepSmooth);
            }
        }
    }
}
