using UnityEditor;
using UnityEngine;

public class PickingEnemy : MonoBehaviour
{
    PlayerStatusManager status;
    public GameObject enemy = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        status = GetComponent<PlayerStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (status.PushAlt)
        {
            if (status.RightClick || status.LeftClick)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                    {
                        enemy = hit.collider.gameObject;
                        Material mat = AssetDatabase.LoadAssetAtPath<Material>("Assets/Material/Missile.mat");
                        if (mat != null)
                            enemy.GetComponent<Renderer>().material = mat;
                    }
                }
            }
            if (enemy)
            {
                status.Picking = enemy;
                enemy = null;
            }
        }
    }
}
