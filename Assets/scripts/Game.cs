using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour {
    public static Game Instance;
    int numPoints = 0;
    public Hud score;
    public Animator face;
    
    void Awake()
    {
        Instance = this;        
    }

    public int GetNumPoints()
    {
        return numPoints;
    }
    public void AddPoint(int value)
    {
        numPoints+=value;
        score.SetNumber(numPoints);
        face.SetTrigger("eat");
    }

    public void OnEndTime()
    {
        int bestscore = PlayerPrefs.GetInt("bestscore");
        if(numPoints> bestscore)
        PlayerPrefs.SetInt("bestscore", numPoints);
        SceneManager.LoadScene("mainmenu");
    }


    

}
