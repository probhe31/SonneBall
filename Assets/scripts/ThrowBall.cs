using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Types
{
    SPOON = 1,
    EGG = 2,
    FLY = 3,
    PENCIL = 4,    
    CAT = 5,
    PEPSI = 6,
    COCACOLA = 7,
    FISH = 8,
}


public class ThrowBall : MonoBehaviour {

    public Transform spawningPoint;
    Ball currentBall;
    public AudioClip[] sounds;

    public void CreateBall(Vector3 pos)
    {
        int bestScore = PlayerPrefs.GetInt("bestscore");
        int score = Game.Instance.GetNumPoints();

        if (score > bestScore)
        {
            if (score > 0 && score < 8)
            {
                PlayerPrefs.SetInt("ItemsUnlock", 2);
            }
            else if (score >= 8 && score < 30)
            {
                PlayerPrefs.SetInt("ItemsUnlock", 3);
            }
            else if (score >= 30 && score < 40)
            {
                PlayerPrefs.SetInt("ItemsUnlock", 4);
            }
            else if (score >= 40 && score < 60)
            {
                PlayerPrefs.SetInt("ItemsUnlock", 5);
            }
            else if (score >= 60)
            {
                PlayerPrefs.SetInt("ItemsUnlock", 6);
            }


        }

        /**/

        int unlockValue = PlayerPrefs.GetInt("ItemsUnlock");
        int random = Random.Range(1, unlockValue);

        Debug.Log("aqui " + random + " u " + unlockValue);

        switch ((Types)random)
        {
            case Types.FLY:
                currentBall = TrashMan.spawn("fly", pos).GetComponent<Ball>();
                break;
            case Types.PENCIL:
                currentBall = TrashMan.spawn("pencil", pos).GetComponent<Ball>();
                break;
            case Types.SPOON:
                currentBall = TrashMan.spawn("spoon", pos).GetComponent<Ball>();
                break;
            case Types.EGG:
                currentBall = TrashMan.spawn("egg", pos).GetComponent<Ball>();
                break;
            case Types.CAT:
                currentBall = TrashMan.spawn("cat", pos).GetComponent<Ball>();
                /*AudioSource audioSource = TrashMan.spawn("sfx").GetComponent<AudioSource>();
                audioSource.clip = sounds[0];
                audioSource.Play();*/
                break;            
        }

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

        /*if (Input.GetKeyDown(KeyCode.P))
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
