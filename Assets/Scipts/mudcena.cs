using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mudcena : MonoBehaviour {
    public string cena;
    private bool ativcena=false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ativcena==true) {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Local(cena);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ativcena = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ativcena =false;
    }
    private void Local(string local)
    {
        SceneManager.LoadScene(local);
    }
}
