using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {
    public void Tapete(string Cena)
    {
        SceneManager.LoadScene(Cena);
    }
}
