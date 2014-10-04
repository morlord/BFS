using UnityEngine;
using System.Collections;

public class EndGameMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MainMenu()
	{
		var heroB = GameObject.FindObjectOfType<HeroBehavior>();
		Destroy(heroB);
		Application.LoadLevel(0);
	}

	public void Continue(int lvl)
	{
		var heroB = GameObject.FindObjectOfType<HeroBehavior>();
		DontDestroyOnLoad(heroB);
		Application.LoadLevel(lvl);
	}
}