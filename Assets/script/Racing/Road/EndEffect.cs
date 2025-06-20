using UnityEngine;

public class EndEffect : MonoBehaviour
{
    public GameObject shrapnel;

    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < 1000; i++)
        {
            Vector3 spawnPos = transform.position;
            GameObject go = Instantiate(shrapnel, spawnPos, Quaternion.identity);
            BulletShrapnel bs = go.GetComponent<BulletShrapnel>();
            if (bs != null)
                bs.OriginDirect = transform.forward;
        }
    }
}
