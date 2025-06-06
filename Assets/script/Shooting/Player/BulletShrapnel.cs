using UnityEngine;

public class BulletShrapnel : MonoBehaviour
{
    public float maxForce = 10.0f;
    public int lifetimeThreshold = 100;

    private Vector3 spinAxis;
    public Vector3 OriginDirect;
    private int timer = 0;

    void Awake()
    {
        GetComponent<Collider>().enabled = false;
    }
    void Start()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        spinAxis = new Vector3(x, y, z);

        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 randomDir;
        do
        {
            randomDir = Random.onUnitSphere;
        }
        while (Vector3.Dot(randomDir, OriginDirect.normalized) > 0);

        transform.position = transform.position + randomDir * 0.5f;
        GetComponent<Collider>().enabled = true;

        float randomMag = Random.Range(0f, maxForce);
        rb.AddForce(randomDir * randomMag, ForceMode.Impulse);
    }

    void Update()
    {
        transform.Rotate(spinAxis);

        timer++;
        if (timer > lifetimeThreshold)
        {
            if (Random.value < 0.01f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
