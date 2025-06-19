using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
            Destroy(gameObject);
        else if (other.gameObject.layer == LayerMask.NameToLayer("Missile"))
            Destroy(gameObject);
    }
}
