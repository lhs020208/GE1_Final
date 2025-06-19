using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public GameObject Player;
    PlayerReset playerReset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        playerReset = Player.GetComponent<PlayerReset>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
