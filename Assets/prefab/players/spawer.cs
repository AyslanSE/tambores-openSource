using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawer : MonoBehaviour {
    public GameObject[] caracter;
    public Transform[] carac;
    public Transform playerspawnpoint;
    void Start () {
        Instantiate(caracter[caracterS.playerid], playerspawnpoint.position, playerspawnpoint.rotation);
        
    }
}
