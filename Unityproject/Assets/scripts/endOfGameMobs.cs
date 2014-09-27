using UnityEngine;
using System.Collections;

public class endOfGameMobs : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider2)
	{
		if (collider2.gameObject.tag == "mob")
		{
			Destroy(FindObjectOfType<HeroBehavior>());
			Application.LoadLevel(3);
			DestroyObject(collider2.gameObject);
			//k++;
		}
	}
}
