using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

    public Text textBack;
    public Text textFront;

    public void SetNumber(int value)
    {
        textBack.text = ""+value;
        textFront.text = "" + value;
    }
}
