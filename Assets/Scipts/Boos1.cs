using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boos1 : MonoBehaviour
{
    public Rigidbody2D rbo;
    public Transform bost;
    public Animation bosan;
    public Animator bosar;

    public GameObject Posicaoflecha;
    public GameObject flecha;
    private bool momento;
    private bool coli;
    private int movimento;

    // Use this for initialization
    void Start()
    {
        bosar.SetBool("move1", true);
        bosar.SetBool("move2", false);
        bosar.SetBool("move3", false);
        momento = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (bosar.GetBool("move1") && !bosar.GetBool("move2") && !bosar.GetBool("move3"))
        {
            
            tempo(100f);
            bosar.SetBool("move1", false);
            bosar.SetBool("move2", false);
            bosar.SetBool("move2", false);
            bosar.SetBool("idle", false);
            movimento = 1;
            momento = false;
            print("true1");

        }
        else if (!bosar.GetBool("move1") && bosar.GetBool("move2") && !bosar.GetBool("move3"))
        {
            bosar.Play("atack2");
            tempo(100f);
            bosar.SetBool("move1", false);
            bosar.SetBool("move2", false);
            bosar.SetBool("move2", false);
            bosar.SetBool("idle", false);
            movimento = 2;
            momento = false;
            print("true2");
        }
        else if (!bosar.GetBool("move1") && !bosar.GetBool("move2") && bosar.GetBool("move3"))
        {
            bosar.Play("atack3");
            tempo(100f);
            bosar.SetBool("move1", false);
            bosar.SetBool("move2", false);
            bosar.SetBool("move3", false);
            movimento = 3;
            momento = false;
            print("true3");
            bosar.SetBool("idle", false);
        }
        else
        {
            momento = true;
            print("true4");
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "raio" && !bosan.IsPlaying("atac1") && !bosan.IsPlaying("atcak2") && !bosan.IsPlaying("atcak3") && momento)
        {
            print("colide");
            switch (movimento)
            {
                case 1:
                    tempo(100f);
                    veriMov1();
                    break;
                case 2:
                    tempo(100f);
                    veriMov2();
                    break;
                case 3:
                    tempo(100f);
                    veriMov3();
                    break;

            }
        }
    }
    void veriMov1()
    {
            bosar.SetBool("move1", false);
            bosar.SetBool("move2", true);
            bosar.SetBool("move3", false);

    }
    void veriMov2()
    {
            bosar.SetBool("move1", false);
            bosar.SetBool("move2", false);
            bosar.SetBool("move3", true);
            momento = false;
    }
    void veriMov3()
    {
        bosar.SetBool("move1", false);
        bosar.SetBool("move2", false);
        bosar.SetBool("move3", false);
        zerou();
    }
    void atirar(float posx)
    {
        //GameObject tmpProjetil = (GameObject)(Instantiate(flecha, Posicaoflecha.transform.position, Quaternion.identity));
        //tmpProjetil.GetComponent<rasioS>().inicializar(Vector2.down);
        GameObject tmpProjetil = Instantiate(flecha, new Vector3(posx, 0.78f, 0), Quaternion.identity);
    }
    private IEnumerator tempo(float Times)
    {
        while (true)
        {

            yield return new WaitForSeconds(Times);
        }
    }
    void zerou()
    {
        SceneManager.LoadScene("fimdademo");
    }

}