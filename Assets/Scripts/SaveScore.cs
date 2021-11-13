using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScore : MonoBehaviour {

    static public int score;
    static public int record;
    string nomeCena;

	// Use this for initialization
	void Start () {
        score = 0;
        record = 0;
        nomeCena = SceneManager.GetActiveScene().name;
        if (PlayerPrefs.HasKey(nomeCena + "score"))
        {
            record = PlayerPrefs.GetInt(nomeCena + "score");
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChecarScore()
    {
        if (score > record)
        {
            record = score;
            PlayerPrefs.SetInt(nomeCena + "score", record);
        }
    }
}
