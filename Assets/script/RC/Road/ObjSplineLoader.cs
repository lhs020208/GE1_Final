using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(LineRenderer))]
public class ObjSplineLoader : MonoBehaviour
{
    public List<Vector3> splinePoints = new List<Vector3>();
    public string absoluteObjPath = @"Assets\Obj\RC\Road\RoadEdge_sorted.obj";
    public GameObject Player;
    public SplineFollower follower;

    void Start()
    {
        Player = GameObject.Find("Player");
        LoadObjFromFile(absoluteObjPath);
        follower = Player.GetComponent<SplineFollower>();
        if (follower != null)
        {
            follower.SetSpline(splinePoints);
        }
    }

    void LoadObjFromFile(string path)
    {
        if (!File.Exists(path)) return;

        splinePoints.Clear();

        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("v "))
                {
                    string[] tokens = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                    if (tokens.Length == 4 &&
                        float.TryParse(tokens[1], out float x) &&
                        float.TryParse(tokens[2], out float y) &&
                        float.TryParse(tokens[3], out float z))
                    {
                        splinePoints.Add(new Vector3(x, y, z));
                    }
                }
                // "l" 정보는 이제 무시함
            }
        }

        if (splinePoints.Count >= 2)
        {
            //LineRenderer lr = GetComponent<LineRenderer>();
            //lr.positionCount = splinePoints.Count;
            //lr.useWorldSpace = true;
            //lr.SetPositions(splinePoints.ToArray());
        }
    }
}
