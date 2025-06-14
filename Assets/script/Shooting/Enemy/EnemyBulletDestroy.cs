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
