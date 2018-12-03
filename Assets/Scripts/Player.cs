using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D playerRigidboy;
    public int force;
    public Animator animation;

    public GameObject snake;
    public Sprite spriteSnakeEnd;

    public bool NoChao;
    public Transform GroundCheck;
    public LayerMask OQueEhChao;
    public bool slide;
    public Transform chao;
    public Transform positionPlayer;
    public Transform colisor;
    public GameObject starsPrefab;
    public bool die = false;

    private float posXChao;
    private float posYChao;
    private float posXPlayer;
    private float posYPlayer;
    private float posXColisor;
    private float posYColisor;
    private float scaleXColisor;
    private float scaleYColisor;

    private Vector2 posicaoInicial;
    private Vector2 toque;
    private bool toqueIniciado = false;

    private float accTime;
    public float slideTemp;

    // Use this for initialization
    void Start()
    {
        posXChao = chao.position.x;
        posYChao = chao.position.y;
        posXPlayer = positionPlayer.position.x;
        posYPlayer = positionPlayer.position.y;
        posXColisor = colisor.position.x;
        posYColisor = colisor.position.y;
        scaleXColisor = colisor.localScale.x;
        scaleYColisor = colisor.localScale.y;
    }

    //void Finalizar(Vector2 posicao)
    //{
    //    if (posicao.y > posicaoInicial.y)
    //    {
    //        //cima
    //        if (NoChao == true)
    //        {
    //            chao.position = new Vector3(posXChao, posYChao, chao.position.z);
    //            positionPlayer.position = new Vector2(posXPlayer, posYPlayer);
    //            playerRigidboy.AddForce(new Vector2(0, force));
    //            slide = false;
    //        }
    //    }
    //    else
    //    {
    //        //baixo
    //        if (NoChao == true)
    //        {
    //            slide = true;
    //            accTime = 0;
    //            chao.position = new Vector3(posXChao, posYChao, chao.position.z);
    //            positionPlayer.position = new Vector2(posXPlayer, posYPlayer);
    //            chao.position = new Vector3(chao.position.x, chao.position.y - 0.7f, chao.position.z);
    //            positionPlayer.position = new Vector2(positionPlayer.position.x, positionPlayer.position.y - 0.694622f);
    //        }
    //    }
    //}

    // Update is called once per frame

    void Update()
    {

        NoChao = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, OQueEhChao);

        //if (Input.touchCount > 0 && toqueIniciado == false && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    toqueIniciado = true;
        //    toque = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        //    posicaoInicial = toque;
        //}

        //if (Input.touchCount > 0 && toqueIniciado == true && Input.GetTouch(0).phase == TouchPhase.Ended)
        //{
        //    toqueIniciado = false;
        //    toque = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        //    if (Vector2.Distance(posicaoInicial, toque) > 1)
        //    {
        //        Finalizar(toque);
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Space) && NoChao == true)
        {
            Debug.Log("Pulou");
            chao.position = new Vector3(posXChao, posYChao, chao.position.z);
            positionPlayer.position = new Vector2(posXPlayer, posYPlayer);
            colisor.position = new Vector2(posXColisor, posYColisor);
            colisor.localScale = new Vector2(scaleXColisor, scaleYColisor);
            playerRigidboy.AddForce(new Vector2(0, force));
            slide = false;
        }
        if (Input.GetKeyDown(KeyCode.S) && NoChao == true)
        {
            slide = true;
            accTime = 0;
            chao.position = new Vector3(posXChao, posYChao, chao.position.z);
            positionPlayer.position = new Vector2(posXPlayer, posYPlayer);
            colisor.position = new Vector2(posXColisor, posYColisor);
            colisor.localScale = new Vector2(scaleXColisor, scaleYColisor);
            chao.position = new Vector3(chao.position.x, chao.position.y - 1.5f, chao.position.z);
            positionPlayer.position = new Vector2(positionPlayer.position.x, positionPlayer.position.y - 1.5f);
        }

        if (slide == true)
        {
            accTime += Time.deltaTime;
            if (accTime >= slideTemp)
            {
                slide = false;
                chao.position = new Vector3(posXChao, posYChao, chao.position.z);
                positionPlayer.position = new Vector2(posXPlayer, posYPlayer);
                colisor.position = new Vector2(posXColisor, posYColisor);
                colisor.localScale = new Vector2(scaleXColisor, scaleYColisor);
            }
        }
        animation.SetBool("Jump", !NoChao);
        animation.SetBool("Slide", slide);
        if (animation.GetBool("Damage") == true)
        {
            chao.position = new Vector3(posXChao, posYChao, chao.position.z);
            accTime += Time.deltaTime;
            MoveOffset.speed = 0;
            Debug.Log("entrou");
            if (die == true)
            {
                snake.GetComponent<Animator>().enabled = false;
                snake.GetComponent<SpriteRenderer>().sprite = spriteSnakeEnd;
                GameObject tempPrefab = Instantiate(starsPrefab) as GameObject;
                die = false;
            }


            if (accTime >= 1.06f)
            {
                //Destroy(GameObject.Find("Player"));
            }
        }
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("Colidiu!");
        animation.SetBool("Damage", true);
        die = true;
        Destroy(GameObject.Find("Spawn"));
        Destroy(GameObject.Find("Banana(Clone)"));
        Destroy(GameObject.Find("barril1(Clone)"));
        Destroy(GameObject.Find("sodaObstacle(Clone)"));
        //animation.SetBool("Die", true);
        accTime = 0;
        Update();
    }
}
