using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour {

    public GameObject scenario;
    public Material CurrentMaterial;
    private float offset;
    static public float speed = 4.5f;
    static public float speedSky = 1.2f;

    // Use this for initialization
    void Start()
    {
        CurrentMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {


        if(scenario == GameObject.FindGameObjectWithTag("sky"))
        {
            offset += 0.1f;
            CurrentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speedSky, 0));
        }
        else
        {
            offset += 0.001f;
            CurrentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
        }

    }
}
