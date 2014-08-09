using UnityEngine;
using System.Collections;

public class setSize : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		var obj = GetComponent<GUITexture>();
		obj.pixelInset = new Rect((Screen.width / 2), 0, Screen.width / 2, Screen.height);
	}
}
