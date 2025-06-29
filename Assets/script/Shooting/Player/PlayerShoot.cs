using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject missile;
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

    void shoot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position + transform.forward, Quaternion.identity);
        newBullet.transform.position += transform.right * 0.6f; // Adjust bullet position slightly forward to avoid collision with player

        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 direction = transform.forward;
            newBullet.transform.forward = direction;
            rb.AddForce(direction * shootForce, ForceMode.Impulse);
        }
    }
    void intercept()
    {
        GameObject target = Status.Picking;
        GameObject newMissile = Instantiate(missile, transform.position + transform.forward, Quaternion.identity);
        newMissile.transform.position = target.transform.position + Vector3.up * 20.0f;
        newMissile.GetComponent<MissileMove>().Target = target;
    }
    void OnAttack(InputValue value)
    {
        if (Status.Picking == null)
            shoot();
        else
            intercept();
        
    }

}
