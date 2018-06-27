using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterBuy : MonoBehaviour {

  
    public List<CharacterUI> charactersUI;

    void Start()
    {
        Refresh();
    }

    void Refresh()
    {
        DataManager.Instance.SaveCharacter(CharacterManager.Instance.characters.characterList[0].keyPlayerPrefs);
        for (int i = 0; i < CharacterManager.Instance.characters.characterList.Count; i++)
        {
            charactersUI[i].SetCharacter(CharacterManager.Instance.characters.characterList[i], CharacterManager.Instance.HasCharacter(i) ? "Usar" : "Comprar");
        }
    }

    public void OnClick(int idChar)
    {
       
        if (CharacterManager.Instance.HasCharacter(idChar))
        {
            //si ya lo tiene usarlo
            CharacterManager.Instance.Use(idChar);
        }
        else
        {
            if (CharacterManager.Instance.Buy(idChar))
            {
                Debug.Log("compro exitosamente");
                Refresh();
            }
            else
            {
                Debug.Log("misio");
                //no pasa nada
            }

        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GotoMenu();
        }

        /*if(Input.GetKeyDown(KeyCode.P))
            DataManager.Instance.AddCoin();*/
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
