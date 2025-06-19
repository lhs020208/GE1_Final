using System;
using UnityEditor;
using UnityEngine;

public class ShootIconColor : MonoBehaviour
{
    public GameObject player;
    public PlayerStatusManager status;
    public Material material;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        status = player.GetComponent<PlayerStatusManager>();
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Material mat;
        if (status.PushAlt)
        {
            mat = AssetDatabase.LoadAssetAtPath<Material>("Assets/Material/IsAim.mat");
        }
        else
        {
            mat = AssetDatabase.LoadAssetAtPath<Material>("Assets/Material/NotAim.mat");
        }
        if (mat != null)
            GetComponent<Renderer>().material = mat;
    }
}
