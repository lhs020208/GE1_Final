using UnityEngine;
using System.Collections.Generic;

public class SplineFollower : MonoBehaviour
{
    public List<Vector3> splinePoints; // spline 경로
    public float speed = 5f;           // 이동 속도
    private int currentIndex = 0;
    private float t = 0f;

    void Update()
    {
        if (splinePoints == null || splinePoints.Count < 2)
            return;

        Vector3 from = splinePoints[currentIndex];
        Vector3 to = splinePoints[currentIndex + 1];

        t += Time.deltaTime * speed / Vector3.Distance(from, to);
        transform.position = Vector3.Lerp(from, to, t);
        transform.LookAt(to);

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
}
