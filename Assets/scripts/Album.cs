using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Album : MonoBehaviour {

	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GotoMenu();
        }
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
