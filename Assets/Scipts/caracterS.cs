using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class caracterS : MonoBehaviour {
    public static int playerid;
    public void caracterSelection(int select) {
        playerid = select;
        Debug.Log(playerid);
        SceneManager.LoadScene("Level1");
    }

}
