using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dificuldade : MonoBehaviour {

    public List<float> Easy;
    public List<float> Medio;
    public List<float> Hard;

    private float accTime;

	// Use this for initialization
	void Start () {
        Hard = new List<float> { 1, 1.3f, 1.5f };
        Medio = new List<float> { 2, 2.5f, 2.8f };
        Easy = new List<float> { 3, 3.5f, 4f };
    }
	
	// Update is called once per frame
	void Update () {

        accTime += Time.deltaTime;
        //Debug.Log(Spawn.tempoSpawn);
        if (accTime <= 20)
        {
            Spawn.tempoSpawn = Easy[Random.Range(0,3)];
        }
        else
        {
            if (accTime <= 40)
            {
                //Debug.Log("MEDIO");
                MoveOffset.speed = 6f;
                Spawn.tempoSpawn = Medio[Random.Range(0, 3)];
            }
            else
            {
                //Debug.Log("DIFICIL");
                MoveOffset.speed = 7f;
                Spawn.tempoSpawn = Random.Range(Hard[Random.Range(0, 3)], Medio[Random.Range(0, 3)]);
            }
        }

	}
}
