using UnityEngine;
using UnityEditor;

public class ApplyCubePhysics
{
    [MenuItem("Tools/Apply Physics to Cubes")]
    public static void ApplyPhysicsToCubes()
    {
        // ���� �ִ� ��� GameObject ��������
        GameObject[] allObjects = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        int modifiedCount = 0;

        foreach (GameObject obj in allObjects)
        {
            if (obj.name.Contains("Cube"))
            {
                // BoxCollider �߰�(������)
                if (obj.GetComponent<BoxCollider>() == null)
                    obj.AddComponent<BoxCollider>();

                // Rigidbody �߰�(������)
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb == null)
                    rb = obj.AddComponent<Rigidbody>();

                // Rigidbody �ɼ�
                rb.isKinematic = true;
                rb.useGravity = false;

                // Static ����
                obj.isStatic = true;

                modifiedCount++;
            }
        }

        Debug.Log($"'Cube'�� ���Ե� ������Ʈ�� ���� ���� �Ϸ�: {modifiedCount}��");
    }
}
