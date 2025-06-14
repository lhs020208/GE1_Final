using UnityEngine;
using UnityEditor;

public class SetCubeLayer : MonoBehaviour
{
    [MenuItem("Tools/Set Layer To Wall For All Cubes")]
    static void SetLayerForAllCubes()
    {
        int wallLayer = LayerMask.NameToLayer("Wall");
        if (wallLayer == -1)
        {
            Debug.LogError("\"Wall\" 레이어가 존재하지 않습니다. 레이어를 먼저 생성하세요!");
            return;
        }

        // 최신 Unity에서는 이렇게!
        var allObjects = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        int count = 0;
        foreach (var obj in allObjects)
        {
            if (obj.name == "Cube" || System.Text.RegularExpressions.Regex.IsMatch(obj.name, @"^Cube \(\d+\)$"))
            {
                obj.layer = wallLayer;
                count++;
            }
        }

        Debug.Log($"{count}개의 Cube 오브젝트에 Wall 레이어를 적용했습니다.");
    }
}
