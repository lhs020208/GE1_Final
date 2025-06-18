using UnityEngine;

public class PrintHeight : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BoxCollider box = GetComponent<BoxCollider>();

        // ���� ���� y �ִ밪
        float localMaxY = box.center.y + (box.size.y * 0.5f);

        // ������Ʈ�� Transform�� ���� ���� ��ġ (���� ����)
        float worldMaxY = transform.position.y + localMaxY * transform.lossyScale.y;

        print($"{gameObject.name} {worldMaxY}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
