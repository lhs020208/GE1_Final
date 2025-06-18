using UnityEngine;

public class PrintHeight : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BoxCollider box = GetComponent<BoxCollider>();

        // 로컬 기준 y 최대값
        float localMaxY = box.center.y + (box.size.y * 0.5f);

        // 오브젝트의 Transform에 따른 실제 위치 (월드 기준)
        float worldMaxY = transform.position.y + localMaxY * transform.lossyScale.y;

        print($"{gameObject.name} {worldMaxY}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
