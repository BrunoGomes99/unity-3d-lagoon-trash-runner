using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {

    public CharacterController controller; // cria o controller para a cobra

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>(); // Inicializa o controller com o objeto o qual utiliza este componente
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
