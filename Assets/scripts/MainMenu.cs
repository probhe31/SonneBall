using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Text t1;
    public Text t2;
    public Text coinTxt;




    private void Start()
    {
        t1.text = "" + PlayerPrefs.GetInt("bestscore");
        t2.text = "" + PlayerPrefs.GetInt("bestscore");
        coinTxt.text = "" + PlayerPrefs.GetInt("numCoins");
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
        int idSkin = PlayerPrefs.GetInt("currentSkin");        
        SceneManager.LoadScene(CharacterManager.Instance.characters.characterList[idSkin].sceneName);
    }

    public void GoToAlbum()
    {
        SceneManager.LoadScene("album");
    }

    public void GoToCharacters()
    {
        SceneManager.LoadScene("characters");
    }
}
