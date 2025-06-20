using UnityEngine;

public class EffectShrapnel : MonoBehaviour
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
        // 회전축 랜덤 설정
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        spinAxis = new Vector3(x, y, z);

        Rigidbody rb = GetComponent<Rigidbody>();

        // Y축 양수 방향으로만 튕기는 랜덤 벡터 생성
        Vector3 randomDir;
        do
        {
            randomDir = Random.onUnitSphere;
        }
        while (randomDir.y <= 0); // y > 0일 때까지 반복

        // 시작 위치를 약간 이동시키고 콜라이더 활성화
        transform.position += randomDir * 0.5f;
        GetComponent<Collider>().enabled = true;

        // Force 적용
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
