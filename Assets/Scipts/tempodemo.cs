using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class tempodemo : MonoBehaviour {

    public Text displayContagem;
    public float contagem= 100.0f;
	// Use this for initialization
	void Start () {
		InvokeRepeating("Diminui",0.0f,0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Diminui()
    {
        if (contagem > 0)
        {
            contagem -= 0.1f;
            displayContagem.text = contagem.ToString();
        }
        else
        {
            SceneManager.LoadScene("gameover");
            CancelInvoke();
        }
    }
}
