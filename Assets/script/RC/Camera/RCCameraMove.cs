using UnityEngine;

public class RCCameraMove : MonoBehaviour
{
    public GameObject Player;

    public float Up_Distance = 1.5f;
    public float Back_Distance = 3.0f;
    public float LookAhead_Distance = 3.0f;

    Vector3 LastSaveForward;

    void Start()
    {
        Player = GameObject.Find("Player");
        if (Player == null) print("no Player");
        LastSaveForward = Player.transform.forward;
    }

    void Update()
    {
        // 플레이어의 현재 forward 방향 저장
        LastSaveForward = Player.transform.forward;

        // 카메라 위치 계산 (뒤로, 위로)
        Vector3 offset = -LastSaveForward * Back_Distance + Player.transform.up * Up_Distance;
        transform.position = Player.transform.position + offset;

        // 카메라가 플레이어가 이동할 방향 (forward + lookahead) 바라보게 설정
        Vector3 lookTarget = Player.transform.position + LastSaveForward * LookAhead_Distance;
        transform.LookAt(lookTarget);
        // 이때 transform.forward는 lookTarget - transform.position 방향이 됩니다.
    }
}
