using UnityEngine;

public class RacingPlayerBalance : MonoBehaviour
{
    private Rigidbody rb;
    public float balanceSpeed = 2.0f; // 회전 복원 속도

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 현재 회전값
        Quaternion currentRotation = transform.rotation;

        // 목표 회전: x, z 회전 제거 (y축은 유지)
        Vector3 euler = currentRotation.eulerAngles;
        euler.x = 0f;
        euler.z = 0f;
        Quaternion targetRotation = Quaternion.Euler(euler);

        // 물리 회전 보정
        Quaternion newRotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * balanceSpeed);
        rb.MoveRotation(newRotation);
    }
}
