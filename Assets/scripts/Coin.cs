using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public AudioClip audioclip;

    void OnMouseDown()
    {
        Eat();

    }

    void OnMouseOver()
    {
        Eat();
    }

    void Eat()
    {
        if (kill)
            return;
        kill = true;
        DataManager.Instance.AddCoin();

        AudioSource audioso = TrashMan.spawn("sfx").GetComponent<AudioSource>();
        audioso.clip = audioclip;
        audioso.Play();

        Kill();
    }

    bool kill = false;
    public void Throw()
    {
        kill = false;
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        
        //rb.maxAngularVelocity = 200;
        //rb.AddTorque(new Vector3(0, 100.0f, 0));
        rb.AddForce(new Vector3(1000, 1000));
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destructor")
        {
            StartCoroutine(Destruct());
        }
    }

    void Kill()
    {
        TrashMan.despawn(this.gameObject);
        

    }
    IEnumerator Destruct()
    {
        yield return new WaitForSeconds(1.0f);
        Kill();
    }
}
