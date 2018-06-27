﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestroy : MonoBehaviour {

	void Awake () {
        GameObject.DontDestroyOnLoad(this.gameObject);
	}
	
	
}
