using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	    
	public void LoadLevel()
    {
        Application.LoadLevel(1);
    }

	public void LoadOptions()
	{
		Application.LoadLevel(2);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
