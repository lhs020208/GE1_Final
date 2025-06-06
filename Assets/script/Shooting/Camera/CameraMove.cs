using UnityEngine;
using UnityEngine.LightTransport;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{
    PlayerStatusManager Status;
    public GameObject Player;

    public float Up_Distance = 1.5f;
    public float Back_Distance = 3.0f;
    public float LookAhead_Distance = 3.0f;

    Vector3 LastSaveForward;
    void Start()
    {
        Player = GameObject.Find("Player");
        if (Player == null) print("no Player");
        Status = Player.GetComponent<PlayerStatusManager>();
        LastSaveForward = Player.transform.forward;
    }

    void Update()
    {
        LastSaveForward = Player.transform.forward;
        Vector3 offset = -LastSaveForward * Back_Distance * 2 + Vector3.up * Up_Distance;
        transform.position = Player.transform.position + offset;
        transform.LookAt(Player.transform.position + LastSaveForward * LookAhead_Distance);
    }

}