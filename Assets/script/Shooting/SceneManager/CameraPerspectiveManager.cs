using UnityEngine;

public class CameraPerspectiveManager : MonoBehaviour
{

    GameObject Camera;
    CameraMove CameraMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        CameraMove = Camera.GetComponent<CameraMove>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
