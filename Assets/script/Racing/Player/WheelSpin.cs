using UnityEngine;

public class WheelSpin : MonoBehaviour
{
    public Rigidbody rb;
    public RacingPlayerStatusManager status;

    public float spinSpeed = 10.0f;       // �ִ� ȸ�� �ӵ�
    public float deceleration = 1.0f;    // ���� �ӵ�
    private float currentSpinSpeed = 0.0f;

    // ���� ���־� �ڽ� Transform ����
    private Transform leftVisual, rightVisual, leftBackVisual, rightBackVisual;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        status = GetComponent<RacingPlayerStatusManager>();

        // �ڽ� ������Ʈ�鿡�� Visual ��Ʈ�� ã�Ƽ� ����
        leftVisual = status.LeftWheel.transform.Find("wheel_LF");
        rightVisual = status.RightWheel.transform.Find("wheel_RF");
        leftBackVisual = status.LeftBackWheel.transform.Find("wheel_LR");
        rightBackVisual = status.RightBackWheel.transform.Find("wheel_RR");
    }

    void Update()
    {
        // ����
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
            // ���� (���� ����)
            currentSpinSpeed = Mathf.MoveTowards(currentSpinSpeed, 0f, deceleration);
        }

        // ȸ�� ����
        RotateWheel(leftVisual);
        RotateWheel(rightVisual);
        RotateWheel(leftBackVisual);
        RotateWheel(rightBackVisual);
    }

    void RotateWheel(Transform visual)
    {
        if (visual == null) return;

        // ���� ���־��� ���� right �� �������� ����
        visual.Rotate(visual.right, currentSpinSpeed, Space.World);
    }
}
