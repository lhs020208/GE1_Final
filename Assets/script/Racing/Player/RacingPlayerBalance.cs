using UnityEngine;

public class RacingPlayerBalance : MonoBehaviour
{
    private Rigidbody rb;
    public float balanceSpeed = 2.0f; // ȸ�� ���� �ӵ�

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ���� ȸ����
        Quaternion currentRotation = transform.rotation;

        // ��ǥ ȸ��: x, z ȸ�� ���� (y���� ����)
        Vector3 euler = currentRotation.eulerAngles;
        euler.x = 0f;
        euler.z = 0f;
        Quaternion targetRotation = Quaternion.Euler(euler);

        // ���� ȸ�� ����
        Quaternion newRotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * balanceSpeed);
        rb.MoveRotation(newRotation);
    }
}
