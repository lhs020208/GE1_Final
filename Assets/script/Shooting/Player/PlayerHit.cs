using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    CharacterController cc;
    Vector3 knockbackDir = Vector3.zero;
    float knockbackTimer = 0f;

    public float knockbackDuration = 100.0f;
    public float knockbackForce = 10f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (knockbackTimer > 0)
        {
            cc.Move(knockbackDir * knockbackForce * Time.deltaTime);
            knockbackTimer -= Time.deltaTime;
        }
    }

    public void ApplyKnockback(Vector3 direction)
    {
        knockbackDir = direction.normalized;
        knockbackTimer = knockbackDuration;
    }
}
