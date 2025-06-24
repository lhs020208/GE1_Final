using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class SplineFollower : MonoBehaviour
{
    public List<Vector3> splinePoints; // spline 경로
    public float speed = 0;           // 이동 속도
    private int currentIndex = 0;
    private float t = 0f;

    Vector2 Move;
    bool PushW = false;
    bool PushS = false;

    void Update()
    {
        if (splinePoints == null || splinePoints.Count < 2)
            return;

        if (PushW)
        {
            if (speed < 20.0f)
                speed += 0.01f;
        }
        else if (PushS)
        {
            if (speed > 0.0f)
                speed -= 0.01f;
        }
        else
        {
            if (speed > 0.0f)
                speed -= 0.001f;
        }

        float slopeInfluence = -transform.forward.y * 0.01f; // 계수는 필요에 따라 조절
        speed += slopeInfluence;

        if (speed < 0.0f)
            speed = 0f;
        


        Vector3 from = splinePoints[currentIndex];
        Vector3 to = splinePoints[currentIndex + 1];

        t += Time.deltaTime * speed / Vector3.Distance(from, to);
        transform.position = Vector3.Lerp(from, to, t);
        transform.forward = (to - from).normalized;

        Resetting();

        if (t >= 1f)
        {
            t = 0f;
            currentIndex++;
            print(currentIndex);
            if (currentIndex >= splinePoints.Count - 1)
            {
                currentIndex = splinePoints.Count - 2;
                enabled = false; // 끝에 도달하면 정지
            }
        }
    }

    public void SetSpline(List<Vector3> points)
    {
        splinePoints = points;
        transform.position = points[0];
        currentIndex = 0;
        t = 0;
    }
    void Resetting()
    {
        if (currentIndex >= 81 && currentIndex <= 98)
        {
            transform.up = -transform.up.normalized;
        }
        else if (currentIndex == 99)
        {
            transform.Rotate(0, 0, -90);
        }
        else if (currentIndex >= 108 && currentIndex <= 132)
        {
            float angle = 360 / (132 - 108);
            transform.Rotate(0, 0, -angle * (132 - currentIndex));
        }

        else if(currentIndex >= 141 && currentIndex <= 149)
        {
            transform.Rotate(0, 0, -90);
        }

        else if (currentIndex >= 152 && currentIndex <= 182)
        {
            Vector3 LittleMove = transform.right * -0.4f + transform.up * -0.25f;
            transform.position += LittleMove;
        }
        else if (currentIndex >= 190 && currentIndex <= 200)
        {
            Vector3 LittleMove =  transform.up * -0.25f;
            transform.position += LittleMove;
        }
        else if (currentIndex >= 201 && currentIndex <= 232)
        {
            Vector3 LittleMove = transform.right * 0.4f + transform.up * -0.25f;
            transform.position += LittleMove;
        }
        else if (currentIndex >= 233 && currentIndex <= 284)
        {
            Vector3 LittleMove = transform.right * -0.4f + transform.up * -0.25f;
            transform.position += LittleMove;
        }

        Vector3 offset = transform.right * 0.2f + transform.up * 1.0f;
        transform.position += offset;
    }
    void OnWASDMove(InputValue value)
    {
        Vector2 Move;
        Move = value.Get<Vector2>();

        PushW = Move.y > 0;
        PushS = Move.y < 0;

    }
}
