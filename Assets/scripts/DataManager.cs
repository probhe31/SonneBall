using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    public static DataManager Instance;
    public int numCoins = 0;
       
    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public void AddCoin()
    {
        numCoins++;
        PlayerPrefs.SetInt("numCoins", numCoins);
    }

    void Initialize()
    {
        if (!PlayerPrefs.HasKey("bestscore"))
        {
            PlayerPrefs.SetInt("bestscore", 0);
            PlayerPrefs.SetInt("ItemsUnlock", 0);
            PlayerPrefs.SetInt("currentSkin", 0);
            PlayerPrefs.SetInt("numCoins", 0);
        }
        else
        {
            numCoins = PlayerPrefs.GetInt("numCoins");            
        }
    }

    public bool HasCharacter(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key) == 1;
        }
        else
        {
            PlayerPrefs.SetInt(key, 0);
            return false;
        }
    }

    public void SaveCharacter(string key)
    {
        PlayerPrefs.SetInt(key, 1);
    }

    public void SetCurrentSkin(int idChar)
    {
        PlayerPrefs.SetInt("currentSkin", idChar);
    }

}
