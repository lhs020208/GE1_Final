using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    PlayerStatusManager Status;
    public float shootForce = 10.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Status = GetComponent<PlayerStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position + transform.forward, Quaternion.identity);
        BulletMove bulletStatus = newBullet.GetComponent<BulletMove>();

        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = transform.forward;
            newBullet.transform.forward = direction;
            rb.AddForce(direction * shootForce, ForceMode.Impulse);
        }
    }

    void OnAttack(InputValue value)
    {
        shoot();
    }

}
