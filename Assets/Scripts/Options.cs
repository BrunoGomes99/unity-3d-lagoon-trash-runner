using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {

    private bool pause;
    private float speed;
    private float speedSky;

    private Material tempMaterial;

	// Use this for initialization
	void Start () {
        pause = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if (GUI.Button(new Rect(25, 23, 50, 20), "Pause"))
        {
            if (pause == false)
            {
                Time.timeScale = 0;
                pause = true;
                //speed = MoveOffset.speed;
                //speedSky = MoveOffset.speedSky;
                //MoveOffset.speed = 0;
                //MoveOffset.speedSky = 0;
            }
            else
            {
                Time.timeScale = 1;
                pause = false;
                //MoveOffset.speed = speed;
                //MoveOffset.speedSky = speedSky;
            }
        }

    }
}
