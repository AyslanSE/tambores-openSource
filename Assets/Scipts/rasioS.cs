using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class rasioS : MonoBehaviour {
    [SerializeField]

    private float velociddade;
    private Vector2 direcao;


    private Rigidbody2D rb;

    private Vector3 velocity;

    void Start () {

        rb = GetComponent<Rigidbody2D>();
        
    }
void FixedUpdate()
    {
        rb.velocity = direcao*velociddade;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Enemies")
        {
            Destroy(gameObject,0.2f);
        }
    }
    public void inicializar(Vector2 _direcao)
    {
        direcao = _direcao;
    }
}
