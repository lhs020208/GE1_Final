using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public float shootForce = 10.0f;
    public float maxDistance = 10000f;

    bool CanShoot = true;
    public int reloading = 0;
    public int reloadTime = 30; // Time in frames to reload

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (CanShoot)
        {
            Vector3 startPos = transform.position + transform.right * 0.6f;
            Vector3 direction = transform.forward;

            RaycastHit[] hits = Physics.RaycastAll(startPos, direction, Mathf.Infinity);
            System.Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));

            foreach (var hit in hits)
            {
                int playerLayer = LayerMask.NameToLayer("Player");
                if (hit.collider.gameObject.layer == playerLayer)
                {
                    shoot();
                    CanShoot = false;
                    break;
                }
                else
                {
                    break;
                }
            }
        }
        else
        {
            reloading++;
            if (reloading >= reloadTime) 
            {
                CanShoot = true;
                reloading = 0;
            }
        }
    }

    private void shoot()
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
}
