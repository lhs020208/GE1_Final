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
            // 1. 물리 회전 정지 및 초기화
            rb.angularVelocity = Vector3.zero;
            rb.rotation = Quaternion.identity;

            // 2. 약간 위로 띄우고 수직 정렬
            transform.position += Vector3.up * 0.1f;

            status.PushF = false;
        }
    }
}
