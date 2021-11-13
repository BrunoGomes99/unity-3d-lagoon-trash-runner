using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour {

    static public bool pause;
    private float speed;
    private float speedSky;
    private float timeTemp;

    private Material tempMaterial;
    public Button buttonPause;
    public Button buttonRestart;
    public GameObject credits;
    public Button buttonClose;
    public Button buttonSound;
    public AudioSource musica;
    public Sprite spriteMute;
    public Sprite spriteSound;

    // Use this for initialization
    void Start () {
        pause = false;

    }

    public void pausar()
    {
        if (pause == false)
        {
            Time.timeScale = 0;
            pause = true;
            //MoveOffset.speed = 0;
            //MoveOffset.speedSky = 0;
        }
        else
        {

            Time.timeScale = 1;
            pause = false;
            //MoveOffset.speed = 4.5f;
            //MoveOffset.speedSky = 1.8f;

        }
    }

    public void restart()
    {
        Application.LoadLevel("Main");
    }

    public void menu()
    {
        Application.LoadLevel("Menu");
    }

    public void start()
    {
        Application.LoadLevel("Intro");
    }

    public void creditos()
    {
        credits.GetComponent<SpriteRenderer>().enabled = true;
        buttonClose.GetComponent<Image>().enabled = true;
        buttonClose.GetComponent<Button>().interactable = true;
    }

    public void closeCredit()
    {
        credits.GetComponent<SpriteRenderer>().enabled = false;
        buttonClose.GetComponent<Image>().enabled = false;
        buttonClose.GetComponent<Button>().interactable = false;
    }

    public void sound()
    {
        if (!Player.die)
        {

            if (musica.enabled)
            {
                buttonSound.GetComponent<Image>().sprite = spriteMute;
                musica.enabled = false;
            }
            else
            {
                buttonSound.GetComponent<Image>().sprite = spriteSound;
                musica.enabled = true;
            }

        }
    }

    //public void despausar()
    //{
    //    if(pause)
    //    {
    //        Time.timeScale = 1;
    //        pause = false;
    //    }
    //}

    // Update is called once per frame
    void Update () {
        //buttonPause.onClick.AddListener(pausar);
        //buttonPause.onClick.AddListener(despausar);
        //if (pause == false)
        //{
        //    Time.timeScale = 0;
        //    pause = true;
        //    //MoveOffset.speed = 0;
        //    //MoveOffset.speedSky = 0;
        //}
        //else
        //{
        //    Time.timeScale = 1;
        //    pause = false;
        //    //MoveOffset.speed = 4.5f;
        //    //MoveOffset.speedSky = 1.8f;
        //}
    }

    //private void OnGUI()
    //{
    //    //if (GUI.Button(new Rect(25, 23, 50, 20), "Pause"))
    //    //{
    //        if (pause == false)
    //        {
    //            Time.timeScale = 0;
    //            pause = true;
    //            //MoveOffset.speed = 0;
    //            //MoveOffset.speedSky = 0;
    //        }
    //        else
    //        {
    //            Time.timeScale = 1;
    //            pause = false;
    //            //MoveOffset.speed = 4.5f;
    //            //MoveOffset.speedSky = 1.8f;
    //        }
    //    //}

    //}
}
