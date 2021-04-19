using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Script : MonoBehaviour {

    public GameObject[] object0;

    private bool isleft;

    public float delayInicial;
    public float delaymax;
    public float tempomovimento;

	void Start () {
       //InvokeRepeating("Spawn", delayInicial, delaymax);
        InvokeRepeating("TrocarLado", tempomovimento, tempomovimento);
	}

	void Update () {
        Movimentar();
        
    }
//void Spawn()
  // {
      //  int index = Random.Range(0,object0.Length);
       // Instantiate(object0[index], transform.position, transform.rotation);
        
   //}      
void Movimentar() {
        if (isleft) {
            print(isleft);
            transform.Translate(Vector2.left * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else {
            print(isleft);
            transform.Translate(Vector2.right  *Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    void TrocarLado() {
        isleft = !isleft;
    }
}
