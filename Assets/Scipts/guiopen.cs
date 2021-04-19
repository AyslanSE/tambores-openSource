using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guiopen : MonoBehaviour {

    private bool activemensage;
    public GameObject FalaCanvas;
    public Collider2D player;

    public Text fala;
    public string falaNPC;
    public string falaNPC2;
    // Use this for initialization
    void Start()
    {
        FalaCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (activemensage == true)
        {
            if (Input.GetKeyDown("space"))
            {
                Falabrir(falaNPC);

                if (Input.GetKeyDown("space"))
                {
                    Falabrir(falaNPC2);

                }
            }  
        }
        if (activemensage == false)
        {
            Falafechar();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.tag == "Player")
            {
                activemensage = true;
            }
            else
            {
                activemensage = false;
            }

    }
    public void Falabrir(string f)
    {
        fala.text = f;
        FalaCanvas.SetActive(true);
    }
    public void Falafechar()
    {
        FalaCanvas.SetActive(false);

    }
    IEnumerator segundos()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }
}
