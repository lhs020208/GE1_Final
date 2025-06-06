using UnityEngine;
using UnityEditor;

public class ApplyCubePhysics
{
    [MenuItem("Tools/Apply Physics to Cubes")]
    public static void ApplyPhysicsToCubes()
    {
        // 씬에 있는 모든 GameObject 가져오기
        GameObject[] allObjects = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        int modifiedCount = 0;

        foreach (GameObject obj in allObjects)
        {
            if (obj.name.Contains("Cube"))
            {
                // BoxCollider 추가(없으면)
                if (obj.GetComponent<BoxCollider>() == null)
                    obj.AddComponent<BoxCollider>();

                // Rigidbody 추가(없으면)
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb == null)
                    rb = obj.AddComponent<Rigidbody>();

                // Rigidbody 옵션
                rb.isKinematic = true;
                rb.useGravity = false;

                // Static 설정
                obj.isStatic = true;

                modifiedCount++;
            }
        }

        Debug.Log($"'Cube'가 포함된 오브젝트에 물리 적용 완료: {modifiedCount}개");
    }
}
