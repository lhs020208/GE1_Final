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
        // 마우스 왼쪽 버튼 누를 때 시작
        if (Input.GetMouseButtonDown(1))
        {
            isDragging = true;
            lastMouseX = Input.mousePosition.x;
        }

        // 마우스 왼쪽 버튼을 떼면 드래그 종료
        if (Input.GetMouseButtonUp(1))
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
