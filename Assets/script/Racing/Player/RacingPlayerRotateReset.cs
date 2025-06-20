using UnityEngine;

public class RacingPlayerRotateReset : MonoBehaviour
{
    RacingPlayerStatusManager status;
    Rigidbody rb;

    void Start()
    {
        status = GetComponent<RacingPlayerStatusManager>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (status.PushF)
        {
            // 1. ���� ȸ�� ���� �� �ʱ�ȭ
            rb.angularVelocity = Vector3.zero;
            rb.rotation = Quaternion.identity;

            // 2. �ణ ���� ���� ���� ����
            transform.position += Vector3.up * 0.1f;

            status.PushF = false;
        }
    }
}
