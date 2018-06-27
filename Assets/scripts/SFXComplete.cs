using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXComplete : MonoBehaviour {

    AudioSource audioSource;
    void OnEnable()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

	void Update () {
        if (audioSource && !audioSource.isPlaying)
        {
            TrashMan.despawn(this.gameObject);
        }
	}
}
