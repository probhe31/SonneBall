﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour {

	void Start () {
        GotoMenu();

    }

    

    public void GotoMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
