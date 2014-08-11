using System;
using System.IO;
using System.Xml.Linq;
using UnityEngine;
using System.Collections;

public class returnToMenu : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		if (File.Exists("scores.xml"))
		{
			var f = File.OpenText("scores.xml");
			var xml=f.ReadToEnd();
			f.Close();
			f = File.OpenText("scores.txt");
			var score = int.Parse(f.ReadLine());
			f.Close();
			var xdoc = XDocument.Parse(xml);
			xdoc.Root.Add(new XElement("score",score));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)||Input.touchCount>0)
		{
			Application.LoadLevel(0);
		}
	
	}
}
