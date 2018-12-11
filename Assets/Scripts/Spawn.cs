using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public List<GameObject> obstaculos;

    public GameObject banana;
    public GameObject garbage;
    public GameObject soda;
    public GameObject vulture;

    private float accTime;
    static public float tempoSpawn;

    // Use this for initialization
    void Start()
    {
        obstaculos = new List<GameObject> { banana, garbage, soda, vulture };
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.comecou)
        {
            accTime += Time.deltaTime;
            if (accTime >= tempoSpawn)
            {
                accTime = 0;
                Instantiate(obstaculos[Random.Range(0, 4)]);
            }
        }
    }
}
