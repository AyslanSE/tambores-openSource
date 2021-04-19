using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1_Mult : MonoBehaviour
{
    //Movimento
    private Animator anim;
    public Transform player;
    public Rigidbody2D rb;

    public float velocidade;
    public float alturapulo;

    private bool elado;

    public Transform ground;
    public bool grounded;
    public LayerMask whatIsground;
    public bool doubleJump;
    public bool tripleJump;

    public bool fly;

    public float vidamax = 100;
    public float vidaatual = 100;

    public Rigidbody2D playerRidgidbody;

    //Tiro
    public GameObject Posicaoprojetil;
    public GameObject Projetil;

    float horizontal;

    void Start()
    {
        anim = player.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        fly = false;
        elado = transform.localScale.x > 0;

    }
    void FixedUpdate()
    {
        MudarDirecao(horizontal);
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Movimentar();
        jump();
    }
    void Movimentar()
    {

        if (fly == true)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.Translate(Vector2.right * velocidade * Time.deltaTime);

            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.Translate(Vector2.left * velocidade * Time.deltaTime);
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                transform.Translate(Vector2.up * velocidade * Time.deltaTime);

            }
            if (Input.GetAxis("Vertical") < 0)
            {
                transform.Translate(Vector2.down * velocidade * Time.deltaTime);
            }

        }
        if (fly == false)
        {
            anim.SetFloat("walk", Mathf.Abs(Input.GetAxis("Horizontal")));
            rb.gravityScale = 1;
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.Translate(Vector2.right * velocidade * Time.deltaTime);
                transform.localScale = new Vector3(1, 1, 1);
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.Translate(Vector2.left * velocidade * Time.deltaTime);
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            fire();
        }
    }
    void jump()
    {
        grounded = Physics2D.OverlapCircle(ground.position, 0.2f, whatIsground);
        anim.SetBool("jump", !grounded);


        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            anim.SetBool("fly", false);
            playerRidgidbody.AddForce(Vector2.up * alturapulo);
            doubleJump = true;
            fly = false;
        }
        if (Input.GetButtonDown("Jump") && grounded == false && doubleJump == true)
        {
            anim.SetBool("fly", true);
            doubleJump = true;
            fly = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "life")
        {
            vidaatual += 5;
            if (vidaatual > vidamax)
            {
                vidaatual = 100;
            }

        }
        if (collision.gameObject.tag == "Enemies")
        {
            vidaatual -= 100;
            if (vidaatual <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("gameover");
            }
        }
        if (collision.gameObject.tag == "raioP2")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("gameover_2");
        }
    }
    void fire()
    {
        {
            GameObject tmpProjetil = (GameObject)(Instantiate(Projetil, Posicaoprojetil.transform.position, Quaternion.identity));
            if (elado)
            {
                tmpProjetil.GetComponent<raio_s_2_p1>().inicializar(Vector2.right);
            }
            if (!elado)
            {
                tmpProjetil.GetComponent<raio_s_2_p1>().inicializar(Vector2.left);
            }

        }
    }
    private void MudarDirecao(float horizontal)
    {
        if (horizontal > 0 && !elado || horizontal < 0 && elado)
        {
            elado = !elado;
        }
    }
    IEnumerator segundos()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }
}
