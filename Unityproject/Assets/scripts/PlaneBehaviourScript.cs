using UnityEngine;
using System.Collections;

public class PlaneBehaviourScript : MonoBehaviour {

	private Animator animator;
	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
		Debug.Log ("start debug");
		StartCoroutine(StartLoader());
		
	}
	IEnumerator StartLoader () 
	{
		rigidbody2D.velocity = -Vector2.right*2;
		yield return new WaitForSeconds(4.0f);
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.gravityScale = 0;
		
	}
	// Update is called once per frame
	void FixedUpdate()
	{ 	
	}
}
