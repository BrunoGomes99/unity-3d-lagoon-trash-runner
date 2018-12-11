using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour {

    public GameObject scenario;
    public Material CurrentMaterial;
    static public float offset;
    static public float speed;
    static public float speedSky;

    // Use this for initialization
    void Start()
    {
        speed = 4.5f;
        speedSky = 1.8f;
        offset = 0;
        CurrentMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

        if (!Options.pause)
        {

            if (scenario == GameObject.FindGameObjectWithTag("sky"))
            {
                //offset += 0.001f;
                CurrentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speedSky, 0));
            }
            else
            {
                //offset += 0.001f;
                CurrentMaterial.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
            }

        }
    }
}
