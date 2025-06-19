using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    PlayerStatusManager Status;
    bool isDragging = false;
    float lastMouseX;

    public float rotateSpeed = 1.0f; // ȸ�� �ӵ� ������

    void Start()
    {
        Status = GetComponent<PlayerStatusManager>();
    }

    void Update()
    {
        if (Status.RightClick && !isDragging)
        {
            isDragging = true;
            lastMouseX = Input.mousePosition.x;
        }
        else if (!Status.RightClick && isDragging)
        {
            isDragging = false;
        }

        // �巡�� ���� ��
        if (isDragging)
        {
            float dx = Input.mousePosition.x - lastMouseX;
            // y�� �������� ȸ�� (���� �巡�� = ����, ������ �巡�� = ���)
            transform.Rotate(0, dx * rotateSpeed, 0, Space.World);
            lastMouseX = Input.mousePosition.x;
        }
    }
}
