using UnityEngine;

public class MissileDestroy : MonoBehaviour
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
        for (int i = 0; i < 3600; i++)
        {
            Vector3 spawnPos = transform.position + Vector3.down * 7.0f;
            GameObject go = Instantiate(shrapnel, spawnPos, Quaternion.identity);
            BulletShrapnel bs = go.GetComponent<BulletShrapnel>();
            if (bs != null)
                bs.OriginDirect = transform.forward;
        }
        Destroy(gameObject);
    }
}
