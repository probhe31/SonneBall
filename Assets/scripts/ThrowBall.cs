using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public enum Types
{
    SPOON = 1,
    EGG = 2,
    FLY = 3,
    PENCIL = 4,    
    CAT = 5,
    PEPSI = 6,
    COCACOLA = 7,
    FISH = 8,
}*/


public class ThrowBall : MonoBehaviour {

    public Transform spawningPoint;
    Ball currentBall;
    public AudioClip[] sounds;

    public void CreateBall(Vector3 pos)
    {
        currentBall = ItemManager.Instance.RandomUnlockItem(Game.Instance.GetNumPoints(), pos);               
        currentBall.Initialize();
    }

    public void Throw(Vector3 force)
    {
        if (!currentBall)
            return;

        currentBall.Throw(force);
    }

    Vector3 initPos;
    Vector3 endPos;

    public void Update()
    {

        /*if (Input.GetKey(KeyCode.P))
        {
            Game.Instance.AddPoint(1);
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            //currentBall = null;
            initPos = Input.mousePosition;
            initPos.z = 10.0f;
            initPos = Camera.main.ScreenToWorldPoint(initPos);

            
            CreateBall(initPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            endPos.z = 10.0f;
            endPos = Camera.main.ScreenToWorldPoint(endPos);

            

            Vector3 force = new Vector3();
            force.z = 900.0f;
            force.y = (endPos.y -initPos.y) * 180.0f;
            force.x = (endPos.x - initPos.x) * 100.0f;
            Throw(force);
        }
    }
}
