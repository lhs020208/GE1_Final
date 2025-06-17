using UnityEngine;

public class EnemyBulletDestroy : MonoBehaviour
{
    int timer = 0;
    public int distance = 2000;
    public GameObject shrapnel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer >= distance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 enemyVelocity = rb.linearVelocity;

            // 밀어내는 방향 = 적의 이동 방향 + 약간 위
            Vector3 knockbackDir = enemyVelocity.normalized + Vector3.up * 2.0f;

            PlayerHit playerHit = other.GetComponent<PlayerHit>();
            if (playerHit != null)
            {
                playerHit.ApplyKnockback(knockbackDir);
            }
        }

        for (int i = 0; i < 36; i++)
        {
            Vector3 Pos = transform.position;
            Pos -= transform.forward * 0.1f * i;
            GameObject go = Instantiate(shrapnel, transform.position, Quaternion.identity);
            BulletShrapnel bs = go.GetComponent<BulletShrapnel>();
            if (bs != null)
                bs.OriginDirect = transform.forward;
        }
        Destroy(gameObject);
    }
}
