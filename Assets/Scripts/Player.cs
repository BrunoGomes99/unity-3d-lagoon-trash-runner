using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    static public bool die;
    static public bool comecou = false;
    public GameObject balao4;

    public Button buttonMenu;
    public Button buttonRestart;

    private float speedTemp;
    private float speedTempSky;

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
    private float accTempSlide = 0;
    private float tempColider;
    private bool podePular = true;

    public Collider2D pe;

    public TextMesh textScore;
    public TextMesh recordOver;
    public TextMesh scoreOver;
    public GameObject gameOver;
    public GameObject scoreObject;

    public AudioSource musica;

    private float tempScore;

    // Use this for initialization
    void Start()
    {
        posXChao = chao.position.x;
        posYChao = chao.position.y;
        posXPlayer = -1.263748f;
        posYPlayer = positionPlayer.position.y;
        posXColisor = -1.263748f;
        posYColisor = colisor.position.y;
        scaleXColisor = colisor.localScale.x;
        scaleYColisor = colisor.localScale.y;
        accTempSlide = 0;
        die = false;
    }

    void Finalizar(Vector2 posicao)
    {
        if (posicao.y > posicaoInicial.y)
        {
            //cima
            if (NoChao == true)
            {
                if (podePular)
                {
                    //chao.position = new Vector3(posXChao, posYChao, chao.position.z);
                    //positionPlayer.position = new Vector2(posXPlayer, posYPlayer);
                    //playerRigidboy.AddForce(new Vector2(0, force));
                    //slide = false;
                    chao.position = new Vector3(posXChao, posYChao, chao.position.z);
                    positionPlayer.position = new Vector2(posXPlayer, posYPlayer);
                    colisor.position = new Vector2(posXColisor, posYColisor);
                    colisor.localScale = new Vector2(scaleXColisor, scaleYColisor);
                    playerRigidboy.AddForce(new Vector2(0, force));
                    slide = false;
                    accTempSlide = 0;
                    tempColider = 0;
                }
            }
        }
        else
        {
            //baixo
            if (NoChao == true)
            {
                //slide = true;
                //accTime = 0;
                //chao.position = new Vector3(posXChao, posYChao, chao.position.z);
                //positionPlayer.position = new Vector2(posXPlayer, posYPlayer);
                //chao.position = new Vector3(chao.position.x, chao.position.y - 0.7f, chao.position.z);
                //positionPlayer.position = new Vector2(positionPlayer.position.x, positionPlayer.position.y - 0.694622f);
                accTempSlide = 0;
                slide = true;
                accTime = 0;
                chao.position = new Vector3(posXChao, posYChao, chao.position.z);
                positionPlayer.position = new Vector2(posXPlayer, posYPlayer);
                colisor.position = new Vector2(posXColisor, posYColisor);
                colisor.localScale = new Vector2(scaleXColisor, scaleYColisor);
                chao.position = new Vector3(chao.position.x, chao.position.y - 0.2f, chao.position.z);
                positionPlayer.position = new Vector2(positionPlayer.position.x, positionPlayer.position.y - 0.2f);
            }
        }
    }

    // Update is called once per frame

    void Update()
    {

        NoChao = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, OQueEhChao);

        if (positionPlayer.transform.position.x <= -1.3f)
        {
            //speedTemp = MoveOffset.speed;
            //speedTempSky = MoveOffset.speedSky;
            //MoveOffset.speed = 0;
            //MoveOffset.speedSky = 0;
            positionPlayer.transform.position += new Vector3(2.7f, 0, 0) * Time.deltaTime;
            snake.transform.position += new Vector3(2.7f, 0, 0) * Time.deltaTime;
        }
        else
        {
            comecou = true;
            //MoveOffset.speed = 4.5f;
            //MoveOffset.speedSky = 1.2f;
            musica.pitch = 1;
            positionPlayer.transform.position += new Vector3(0, 0, 0) * Time.deltaTime;
            snake.transform.position += new Vector3(0, 0, 0) * Time.deltaTime;
        }


        if (die)
        {
            musica.enabled = false;
        }

        if (comecou)
        {
            if (Options.pause)
            {
                SaveScore.score = SaveScore.score;
            }
            else
            {
                tempScore += Time.deltaTime;
                if (tempScore > 0.6f && !die)
                {
                    SaveScore.score++;
                    tempScore = 0;
                }
                textScore.text = SaveScore.score.ToString();
            }

            if (Input.touchCount > 0 && toqueIniciado == false && Input.GetTouch(0).phase == TouchPhase.Began && !die)
            {
                toqueIniciado = true;
                toque = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                posicaoInicial = toque;
            }

            if (Input.touchCount > 0 && toqueIniciado == true && Input.GetTouch(0).phase == TouchPhase.Ended && !die)
            {
                toqueIniciado = false;
                toque = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                if (Vector2.Distance(posicaoInicial, toque) > 1)
                {
                    Finalizar(toque);
                }
            }


            if (Input.GetKeyDown(KeyCode.W) && NoChao == true && !die)
            {
                if (podePular)
                {
                    chao.position = new Vector3(posXChao, posYChao, chao.position.z);
                    positionPlayer.position = new Vector2(posXPlayer, posYPlayer);
                    colisor.position = new Vector2(posXColisor, posYColisor);
                    colisor.localScale = new Vector2(scaleXColisor, scaleYColisor);
                    playerRigidboy.AddForce(new Vector2(0, force));
                    slide = false;
                    accTempSlide = 0;
                    tempColider = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.S) && NoChao == true && !die)
            {
                accTempSlide = 0;
                slide = true;
                accTime = 0;
                chao.position = new Vector3(posXChao, posYChao, chao.position.z);
                positionPlayer.position = new Vector2(posXPlayer, posYPlayer);
                colisor.position = new Vector2(posXColisor, posYColisor);
                colisor.localScale = new Vector2(scaleXColisor, scaleYColisor);
                chao.position = new Vector3(chao.position.x, chao.position.y - 0.2f, chao.position.z);
                positionPlayer.position = new Vector2(positionPlayer.position.x, positionPlayer.position.y - 0.2f);
            }

            if (slide == true)
            {
                accTempSlide += Time.deltaTime;
                if (accTempSlide >= 0.2f)
                {
                    podePular = true;
                }
                else
                {
                    podePular = false;
                }
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
            //if (die)  //animation.GetBool("Damage") == true
            //{
            //    chao.position = new Vector3(posXChao, posYChao, chao.position.z);
            //    accTime += Time.deltaTime;
            //    comecou = false;
            //    tempScore = 0;
            //    textScore.GetComponent<FileManager>().setScore(score);
            //    if (score > record)
            //    {
            //        record = score;
            //        textScore.GetComponent<FileManager>().setRecord(record);
            //    }
            //    else
            //    {
            //        textScore.GetComponent<FileManager>().setRecord(record);
            //    }

            //    MoveOffset.speed = 0;
            //    //if (die == true)
            //    //{
            //        snake.GetComponent<Animator>().enabled = false;
            //        snake.GetComponent<SpriteRenderer>().sprite = spriteSnakeEnd;
            //        starsPrefab.GetComponent<SpriteRenderer>().enabled = true;
            //        balao4.GetComponent<SpriteRenderer>().enabled = true;
            //        recordOver.text = "High score: " + record.ToString();
            //        scoreOver.text = score.ToString();
            //        scoreOver.GetComponent<MeshRenderer>().enabled = true;
            //        recordOver.GetComponent<MeshRenderer>().enabled = true;
            //        gameOver.GetComponent<SpriteRenderer>().enabled = true;
            //        buttonMenu.image.enabled = true;
            //        buttonRestart.image.enabled = true;
            //    //}


            //    if (accTime >= 1.06f)
            //    {
            //        //Destroy(GameObject.Find("Player"));
            //    }

            //}
        }

        if (!NoChao)
        {
            pe.isTrigger = true;
            tempColider += Time.deltaTime;
            if (tempColider >= 0.77f)
            {
                pe.isTrigger = false;
            }
        }

    }

    void OnTriggerEnter2D()
    {
        animation.SetBool("Damage", true);
        die = true;
        Destroy(GameObject.Find("Spawn"));
        Destroy(GameObject.Find("Banana(Clone)"));
        Destroy(GameObject.Find("barril1(Clone)"));
        Destroy(GameObject.Find("sodaObstacle(Clone)"));
        Destroy(GameObject.Find("urubu2(Clone)"));
        //animation.SetBool("Die", true);
        accTime = 0;
        chao.position = new Vector3(posXChao, posYChao, chao.position.z);
        accTime += Time.deltaTime;
        comecou = false;
        scoreObject.GetComponent<SaveScore>().ChecarScore();
       //tempScore = 0;
       //textScore.GetComponent<FileManager>().setScore(score);
       //if (score > record)
       //{
       //    record = score;
       //    textScore.GetComponent<FileManager>().setRecord(record);
       //}
       //else
       //{
       //    textScore.GetComponent<FileManager>().setRecord(record);
       //}

        MoveOffset.speed = 0;
        //if (die == true)
        //{
        snake.GetComponent<Animator>().enabled = false;
        snake.GetComponent<SpriteRenderer>().sprite = spriteSnakeEnd;
        starsPrefab.GetComponent<SpriteRenderer>().enabled = true;
        balao4.GetComponent<SpriteRenderer>().enabled = true;
        recordOver.text = "High score: " + SaveScore.record.ToString();
        scoreOver.text = SaveScore.score.ToString();
        scoreOver.GetComponent<MeshRenderer>().enabled = true;
        recordOver.GetComponent<MeshRenderer>().enabled = true;
        gameOver.GetComponent<SpriteRenderer>().enabled = true;
        buttonMenu.image.enabled = true;
        buttonRestart.image.enabled = true;
       
    }
}
