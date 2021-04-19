using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarFala : MonoBehaviour {

    public GameObject fala;
    private bool tocando;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (tocando && Input.GetKeyUp(KeyCode.E))
        {
            fala.SetActive(true);
        }
	}
    private void OnCollisionEnter2D(Collision2D colisorObjetos)
    {
        if (colisorObjetos.gameObject.tag == "Player")
        {
            tocando = true;
        }
        else
        {
            tocando = false;
        }
    }
}
