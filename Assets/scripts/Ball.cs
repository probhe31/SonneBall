using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    Rigidbody myRigidbody;
    public AudioClip[] clips;
    public int value;

    public void Initialize()
    {
        //canDie = true;
        this.GetComponent<SphereCollider>().enabled = true;
        myRigidbody = this.GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;
        transform.rotation = Random.rotation;
    }

    public void Throw(Vector3 force)
    {
        myRigidbody.isKinematic = false;
        myRigidbody.AddForce(force);
		myRigidbody.maxAngularVelocity = 20.0f;
		myRigidbody.AddTorque (new Vector3(0,0,2.0f));

    }

    //bool canDie = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destructor")
        {
            StartCoroutine(Destruct());
        }

        

        if (collision.gameObject.tag == "Disabler")
        {
            //canDie = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PointSensor")
        {
            //if (!canDie)
            //return;

            Game.Instance.AddPoint(value);
            GameObject sfx = TrashMan.spawn("sfx");
            sfx.GetComponent<AudioSource>().clip = clips[0];
            sfx.GetComponent<AudioSource>().Play();
            this.GetComponent<SphereCollider>().enabled = false;
            //StartCoroutine(Destruct());
            myRigidbody.AddForce(new Vector3(0, 0, 20.0f));
            //Kill();            
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
