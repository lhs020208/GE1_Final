using UnityEngine;

public class MissileMove : MonoBehaviour
{
    public GameObject Target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Rotate(90, 0, 0); // Adjust the missile's orientation if necessary
    }

    // Update is called once per frame
    void Update()
    {
        if (Target)
        {
            Vector3 current = transform.position;
            Vector3 targetXZ = new Vector3(Target.transform.position.x, current.y, Target.transform.position.z);
            transform.position = Vector3.MoveTowards(current, targetXZ, 0.1f);
        }
    }
}
