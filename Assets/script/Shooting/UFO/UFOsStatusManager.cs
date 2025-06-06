using UnityEngine;

public class UFOsStatusManager : MonoBehaviour
{

    public GameObject Player;
    public Rigidbody rb;
    public bool CenterMoving = true;
    public Transform center;
    public int HP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Player = GameObject.Find("Player");
        if (Player == null)
        {
            Debug.LogError("Player ������Ʈ�� ã�� �� �����ϴ�.");
            this.enabled = false;
            return;
        }
        rb = GetComponent<Rigidbody>();
        HP = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
