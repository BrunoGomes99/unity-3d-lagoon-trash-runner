using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dificuldade : MonoBehaviour {

    public List<float> Easy;
    public List<float> Medio;
    public List<float> Hard;

    private float accTime;
    public AudioSource musica;

	// Use this for initialization
	void Start () {
        accTime = 0;
        Hard = new List<float> { 1, 1.3f, 1.5f };
        Medio = new List<float> { 2, 2.5f, 2.8f };
        Easy = new List<float> { 3, 3.5f, 4f };
    }
	
	// Update is called once per frame
	void Update () {

        if (Player.comecou)
        {
            if (!Options.pause)
            {

                accTime += Time.deltaTime;
                //Debug.Log(Spawn.tempoSpawn);
                if (accTime <= 20) //20
                {
                    MoveOffset.offset += 0.001f;
                    Spawn.tempoSpawn = Easy[Random.Range(0, 3)];
                }
                else
                {
                    if (accTime <= 40) //40
                    {
                        Debug.Log("MEDIO");
                        //MoveOffset.speed = 6f;
                        MoveOffset.offset += 0.0013f;
                        Spawn.tempoSpawn = Medio[Random.Range(0, 3)];
                    }
                    else
                    {
                        //Debug.Log("DIFICIL");
                        musica.pitch = 1.06f;
                        MoveOffset.offset += 0.0016f;
                        Spawn.tempoSpawn = Random.Range(Hard[Random.Range(0, 3)], Medio[Random.Range(0, 3)]);
                    }
                }

            }
        }
    }
}
