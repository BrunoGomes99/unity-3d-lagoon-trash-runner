using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieIntro : MonoBehaviour {

    public CharacterController controller; // cria o controller para a cobra
    public CharacterController kidController;
    public float speed = 0.4f;
    public float speedRun = 2.7f;
    public Animator kidAnimator;
    public Animator snakeAnimator;
    public GameObject sodaPrefab;
    public Transform kid;

    private float damageTime;
    private float startTime;
    public bool spawnou = false;
    public bool damage = false;
    public bool virou = false;

    // Teste
    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>(); // Inicializa o controller com o objeto o qual utiliza este componente
        kidAnimator.SetBool("JaAtacou", false);
        startTime = Time.time;

    }
	
	// Update is called once per frame
	void Update () {

        var passedTime = Time.time - startTime;
        if (passedTime > 3f)
        {
            kidAnimator.SetBool("JaAtacou", true);
            if (spawnou == false)
            {
                GameObject tempPrefab = Instantiate(sodaPrefab) as GameObject;
                tempPrefab.GetComponent<Rigidbody>().AddForce(new Vector2(-180, 130));
                spawnou = true;
            }
        }
        if (damage == false)
        {
            controller.Move(new Vector3(speed * Time.deltaTime, 0, 0));  //Realiza o movimento, instanciando um Vector3
        }
        else
        {
            passedTime = Time.time - damageTime;
            if (passedTime > 3f)
            {
                Debug.Log("Acordou!");
                snakeAnimator.SetBool("Walk", true);
                snakeAnimator.SetBool("Damage", false);
                controller.Move(new Vector3(speedRun * Time.deltaTime, 0, 0));

                if (virou == true)
                {
                  kid.Rotate(0, 180.0f, 0);
                  virou = false;
                }
                kidAnimator.SetBool("Run", true);
                kidController.Move(new Vector3(speedRun * Time.deltaTime, 0, 0));
            }
        }

        if (transform.position.x >= 6)
        {
            Application.LoadLevel("Main");
        }

    }

    private void OnTriggerEnter(Collider other)  // Para verificar as colisões. Lembrando que o objeto em que vou colidir deve estar com o IsTrigger ativado
    {
        if (other.gameObject.CompareTag("soda"))
        {
            Debug.Log("Colidiu");
            snakeAnimator.SetBool("Damage", true);
            damageTime = Time.time;
            damage = true;
            virou = true;
        }

    }
}
