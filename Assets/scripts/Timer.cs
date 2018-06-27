using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    float counter;
    public float totalTime = 60;
    public Text t1;
    public Text t2;

    void Start () {
        InvokeRepeating("Remove", 1, 1);
	}

    void Remove()
    {
        totalTime--;
        t1.text = "" + totalTime;
        t2.text = "" + totalTime;
        if (totalTime <= 0)
        {
           
            CancelInvoke();
            Game.Instance.OnEndTime();
        }
    }


}
