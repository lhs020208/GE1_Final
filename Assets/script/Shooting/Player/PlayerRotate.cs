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
        // ���콺 ���� ��ư ���� �� ����
        if (Input.GetMouseButtonDown(1))
        {
            isDragging = true;
            lastMouseX = Input.mousePosition.x;
        }

        // ���콺 ���� ��ư�� ���� �巡�� ����
        if (Input.GetMouseButtonUp(1))
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
