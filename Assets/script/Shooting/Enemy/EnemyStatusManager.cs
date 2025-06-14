using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EnemyStatusManager : MonoBehaviour
{
    public bool IsContact = false;

    void Start()
    {
    }

    void Update()
    {

    }
    void OnCollisionStay(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            IsContact = true;
            return;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        IsContact = false;
    }
}
