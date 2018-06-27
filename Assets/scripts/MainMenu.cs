using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Text t1;
    public Text t2;

    


    private void Start()
    {
        t1.text = "" + PlayerPrefs.GetInt("bestscore");
        t2.text = "" + PlayerPrefs.GetInt("bestscore");
    }

  

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GotoGame();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GoToAlbum();
        }
    }

    public void GotoGame()
    {
        SceneManager.LoadScene("game");
    }

    public void GoToAlbum()
    {
        SceneManager.LoadScene("album");
    }
}
