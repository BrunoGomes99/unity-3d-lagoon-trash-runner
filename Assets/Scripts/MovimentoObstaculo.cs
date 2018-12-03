using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoObstaculo : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        if (transform.position.x <= -5.5f)
        {
            Destroy(transform.gameObject);
        }
    }
}
