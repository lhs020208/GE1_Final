using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    PlayerStatusManager Status;
    bool isDragging = false;
    float lastMouseX;

    public float rotateSpeed = 1.0f; // 회전 속도 조절용

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

        // 드래그 중일 때
        if (isDragging)
        {
            float dx = Input.mousePosition.x - lastMouseX;
            // y축 기준으로 회전 (왼쪽 드래그 = 음수, 오른쪽 드래그 = 양수)
            transform.Rotate(0, dx * rotateSpeed, 0, Space.World);
            lastMouseX = Input.mousePosition.x;
        }
    }
}
