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
        if (PlayerPrefs.HasKey("bestscore"))
        {
            int bestScore = PlayerPrefs.GetInt("bestscore");   
                     
            t1.text = "" + bestScore;
            t2.text = "" + bestScore;

            if (bestScore > 0 && bestScore < 8)
            {
                PlayerPrefs.SetInt("ItemsUnlock", 2);
            }
            else if (bestScore >= 8 && bestScore < 30)
            {
                PlayerPrefs.SetInt("ItemsUnlock", 3);
            }
            else if (bestScore >= 30 && bestScore < 40)
            {
                PlayerPrefs.SetInt("ItemsUnlock", 4);
            }
            else if (bestScore >= 40 && bestScore < 60)
            {
                PlayerPrefs.SetInt("ItemsUnlock", 5);
            }
            else if (bestScore >= 60)
            {
                PlayerPrefs.SetInt("ItemsUnlock", 6);
            }


        }
        else
        {
            PlayerPrefs.SetInt("bestscore", 0);
            PlayerPrefs.SetInt("ItemsUnlock", 0);
            t1.text = "" + PlayerPrefs.GetInt("bestscore");
            t2.text = "" + PlayerPrefs.GetInt("bestscore");
        }

        
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
