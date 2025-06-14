using UnityEditor;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    CharacterController cc;

    float distancePerStep = 3.0f / 360.0f;

    bool Check = false;
    int step = 0;
    int move_type = 0; // 0: Move, 1: turn right, 2: turn left


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(move_type)
        {
            case 0: // Move
                cc.Move(transform.forward * distancePerStep);
                step++;
                if (step == 360)
                {
                    step = 0;
                }
                break;
            case 1: // turn right
                transform.Rotate(0, 3, 0);
                step++;
                if (step == 30)
                {
                    step = 0;
                }
                break;
            case 2: // turn left
                transform.Rotate(0, -3, 0);
                step++;
                if (step == 30)
                {
                    step = 0;
                }
                break;
        }
        if (step == 0)
        {
            CheckWallOrRoad();
            if (Check)
            {
                move_type = Random.Range(1, 3);
            }
            else
            {
                float r = Random.value;
                if (r < 0.8f)
                    move_type = 0;         // 80%
                else if (r < 0.9f)
                    move_type = 1;         // 10%
                else
                    move_type = 2;         // 10%
            }
        }

    }

    void CheckWallOrRoad()
    {
        Check = false;
        int wallLayer = LayerMask.NameToLayer("Wall");
        int wallMask = 1 << wallLayer;

        Vector3 startPoint = transform.position;
        if (Physics.Raycast(startPoint, transform.forward, 3.0f, wallMask))
        {
            Check = true;
            return;
        }

        int roadLayer = LayerMask.NameToLayer("Road");
        int wallOrRoadMask = (1 << wallLayer) | (1 << roadLayer);

        startPoint = transform.position;
        Vector3 checkDir = (transform.forward + Vector3.down).normalized; // 45도 전방하향

        if (!Physics.Raycast(startPoint, checkDir, 3.0f, wallOrRoadMask))
        {
            Check = true;
        }
    }
}
