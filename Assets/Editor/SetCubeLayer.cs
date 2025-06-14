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
            Debug.LogError("\"Wall\" ���̾ �������� �ʽ��ϴ�. ���̾ ���� �����ϼ���!");
            return;
        }

        // �ֽ� Unity������ �̷���!
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

        Debug.Log($"{count}���� Cube ������Ʈ�� Wall ���̾ �����߽��ϴ�.");
    }
}
