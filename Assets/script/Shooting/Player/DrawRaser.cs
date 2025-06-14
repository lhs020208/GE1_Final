using UnityEditor;
using UnityEngine;

public class DrawRaser : MonoBehaviour
{
    PlayerStatusManager playerStatusManager;
    public Transform startPoint;
    public Vector3 direction = Vector3.forward;
    public float maxDistance = 10000f;

    private LineRenderer lineRenderer;
    public LayerMask hitLayers;

    void Start()
    {
        playerStatusManager = GetComponent<PlayerStatusManager>();
        
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.widthMultiplier = 0.05f;
        Material material = AssetDatabase.LoadAssetAtPath<Material>("Assets/Material/Laser.mat");
        lineRenderer.material = new Material(material);
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
    }

    void Update()
    {
        Vector3 startPos = transform.position;
        Vector3 direction = transform.up;

        RaycastHit hit;
        Vector3 endPos;

        // 충돌체크
        if (Physics.Raycast(startPos, direction, out hit, maxDistance, hitLayers))
        {
            endPos = hit.point;
        }
        else
        {
            endPos = startPos + direction * maxDistance;
        }

        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
