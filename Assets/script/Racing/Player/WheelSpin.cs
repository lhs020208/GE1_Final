using UnityEngine;

public class WheelSpin : MonoBehaviour
{
    public Rigidbody rb;
    public RacingPlayerStatusManager status;

    public float spinSpeed = 10.0f;       // 최대 회전 속도
    public float deceleration = 1.0f;    // 감속 속도
    private float currentSpinSpeed = 0.0f;

    // 바퀴 비주얼 자식 Transform 참조
    private Transform leftVisual, rightVisual, leftBackVisual, rightBackVisual;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        status = GetComponent<RacingPlayerStatusManager>();

        // 자식 오브젝트들에서 Visual 파트만 찾아서 저장
        leftVisual = status.LeftWheel.transform.Find("wheel_LF");
        rightVisual = status.RightWheel.transform.Find("wheel_RF");
        leftBackVisual = status.LeftBackWheel.transform.Find("wheel_LR");
        rightBackVisual = status.RightBackWheel.transform.Find("wheel_RR");
    }

    void Update()
    {
        // 가속
        if (status.PushW)
        {
            currentSpinSpeed = spinSpeed;
        }
        else if (status.PushS)
        {
            currentSpinSpeed = -spinSpeed;
        }
        else
        {
            // 감속 (선형 보간)
            currentSpinSpeed = Mathf.MoveTowards(currentSpinSpeed, 0f, deceleration);
        }

        // 회전 적용
        RotateWheel(leftVisual);
        RotateWheel(rightVisual);
        RotateWheel(leftBackVisual);
        RotateWheel(rightBackVisual);
    }

    void RotateWheel(Transform visual)
    {
        if (visual == null) return;

        // 바퀴 비주얼을 로컬 right 축 기준으로 자전
        visual.Rotate(visual.right, currentSpinSpeed, Space.World);
    }
}
