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
        // �÷��̾��� ���� forward ���� ����
        LastSaveForward = Player.transform.forward;

        // ī�޶� ��ġ ��� (�ڷ�, ����)
        Vector3 offset = -LastSaveForward * Back_Distance + Player.transform.up * Up_Distance;
        transform.position = Player.transform.position + offset;

        // ī�޶� �÷��̾ �̵��� ���� (forward + lookahead) �ٶ󺸰� ����
        Vector3 lookTarget = Player.transform.position + LastSaveForward * LookAhead_Distance;
        transform.LookAt(lookTarget);
        // �̶� transform.forward�� lookTarget - transform.position ������ �˴ϴ�.
    }
}
