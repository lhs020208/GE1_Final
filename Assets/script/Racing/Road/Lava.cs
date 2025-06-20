using UnityEngine;

public class Lava : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerReset playerReset = other.GetComponent<PlayerReset>();
            if (playerReset != null)
            {
                playerReset.ResetTransform();
            }
        }
    }
}
