using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    public Vector3 initPosition;
    public Quaternion initRotation;
    public Rigidbody rb;

    void Start()
    {
        initPosition = transform.position;
        initRotation = transform.rotation;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y <= -10.0f)
        {
            ResetTransform();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetTransform();
        }
    }
    void ResetTransform()
    {
        transform.position = initPosition;
        transform.rotation = initRotation;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("SavePoint"))
        {
            initPosition = transform.position;
            initRotation = transform.rotation;
            Destroy(other.gameObject);
        }
    }
}
