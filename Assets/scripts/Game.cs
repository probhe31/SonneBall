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

    void Start()
    {
        StartCoroutine(WaitToGenerate());
    }

    public int GetNumPoints()
    {
        return numPoints;
    }
    public void AddPoint(int value)
    {
        numPoints += value;
        score.SetNumber(numPoints);
        if (face)
            face.SetTrigger("eat");
    }

    public void OnEndTime()
    {
        int bestscore = PlayerPrefs.GetInt("bestscore");
        if (numPoints > bestscore)
            PlayerPrefs.SetInt("bestscore", numPoints);
        SceneManager.LoadScene("mainmenu");


        StopAllCoroutines();
    }

    public Transform spwPointCoin;

    IEnumerator WaitToGenerate()
    {
        int randomTime = Random.Range(5, 10);
        yield return new WaitForSeconds(randomTime);
        GenerateCoin();
    }

    public void GenerateCoin()
    {
      
        Coin coin = TrashMan.spawn("coin", spwPointCoin.position).GetComponent<Coin>();
        coin.Throw();
        StartCoroutine(WaitToGenerate());
        
    }
    

}
