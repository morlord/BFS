﻿using UnityEngine;
using System.Collections;

public class victory : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) || Input.touchCount > 0)
		{
			Application.LoadLevel(0);
		}
	}
}
