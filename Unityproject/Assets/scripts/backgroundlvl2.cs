using UnityEngine;
using System.Collections;

public class backgroundlvl2 : MonoBehaviour {
	
	private Animator animator;
	public Rigidbody2D acid;
	private int timelimit=1;
	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
		Debug.Log ("start debug");
		StartCoroutine(StartLoader());

	}
	IEnumerator StartLoader () 
	{
		rigidbody2D.velocity = Vector2.right*2;
		yield return new WaitForSeconds(4.0f);
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.gravityScale = 0;
		if (timelimit == 1) 
			
		{
			Rigidbody2D plasmaInstance = Instantiate(acid, new Vector3( transform.position.x+4.0f,transform.position.y+0.1f,transform.position.z), Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			if (plasmaInstance != null) acid.velocity = Vector2.right;
			timelimit = Random.Range(10, 70);
		}

	}
	// Update is called once per frame
	void FixedUpdate()
	{ 	
	}
	}