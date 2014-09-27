using UnityEngine;
using System.Collections;

public class PlaneBehaviourScript : MonoBehaviour {

	private Animator animator;
	private bool isLive = true;
	private int timelimit=1;
	public Rigidbody2D rocket;
	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
		//Debug.Log ("start debug");
		StartCoroutine(StartLoader());
		
	}
	IEnumerator StartLoader () 
	{
		rigidbody2D.velocity = -Vector2.right*2;
		yield return new WaitForSeconds(4.0f);
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.gravityScale = 0;
		if (timelimit == 1 && isLive == true) {
			Rigidbody2D rocketInstance = Instantiate (rocket, new Vector3 (transform.position.x - 1.0f, transform.position.y + 0.1f, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
			if (rocketInstance != null)
				rocket.velocity = -Vector2.right;
			timelimit = Random.Range (10, 70);
		}
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "acid") {

			DestroyObject (collider.gameObject);

			animator.SetBool ("isLive", false);
			transform.position.Set (transform.position.x, transform.position.y, 0);
			isLive = false;
			//DestroyObject (collider.gameObject);
			rigidbody2D.collider2D.enabled = false;
		}
	}
	// Update is called once per frame
	void FixedUpdate()
	{ 	
	}
	void Update () {

	}
}
