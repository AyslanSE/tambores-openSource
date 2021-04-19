using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMIE : MonoBehaviour {

    private bool isleft;
    public float tempomovimento;

    public int vida;
    public int dano;
    // Use this for initialization
    void Start () {
        InvokeRepeating("TrocarLado", tempomovimento, tempomovimento);
    }
	
	// Update is called once per frame
	void Update () {
        Movimentar();
        
    }
    void Movimentar()
    {
        if (isleft)
        {
            transform.Translate(Vector2.left * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.Translate(Vector2.right * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    void TrocarLado()
    {
        isleft = !isleft;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="raio")
        {
            print("hello");
            Destroy(gameObject);
        }
    }
}
