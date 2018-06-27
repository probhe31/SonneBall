using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    public CharacterCollection characters;
    public static CharacterManager Instance;

    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public bool Buy(int idChar)
    {

        if (DataManager.Instance.numCoins >= characters.characterList[idChar].price)
        {
            DataManager.Instance.numCoins = DataManager.Instance.numCoins - characters.characterList[idChar].price;
            PlayerPrefs.SetInt("numCoins", DataManager.Instance.numCoins);

            GetChar(idChar);
            return true;
        }

        return false;
    }

    public bool HasCharacter(int idChar)
    {
        return DataManager.Instance.HasCharacter(characters.characterList[idChar].keyPlayerPrefs);
    }

    public void GetChar(int idChar)
    {
        DataManager.Instance.SaveCharacter(characters.characterList[idChar].keyPlayerPrefs);
    }

    public void Use(int idChar)
    {
        DataManager.Instance.SetCurrentSkin(idChar);
    }
}
