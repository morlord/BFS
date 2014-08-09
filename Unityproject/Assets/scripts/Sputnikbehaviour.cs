using UnityEngine;
using System.Collections;

public class Sputnikbehaviour : MonoBehaviour {

	public float speed;
	private Animator animator;
	private bool isLive = true;
	private SpawnController controller;
	public int HP;
	// Use this for initialization
	void Start()
	{
		StartCoroutine(StartLoader());
		animator = GetComponent<Animator>();
		controller = FindObjectOfType<SpawnController>();
		Debug.Log ("start debug");

	}
	
	// Update is called once per frame
	void FixedUpdate()
	{

		}

	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log ("collides");
		if (collider.gameObject.tag == "bullet")
		{
			HP -= 1;
			DestroyObject(collider.gameObject);
			if (HP <= 0)
			{
				animator.SetBool("isLive", false);
				rigidbody2D.velocity = Vector2.zero;
				transform.position.Set(transform.position.x, transform.position.y, 0);
				isLive = false;
				DestroyObject(collider.gameObject);
				Destroy(rigidbody2D.collider2D);
				gameObject.layer = 0;
				this.GetComponent<SpriteRenderer>().sortingOrder = 0;
				controller.BroadcastMessage("AddScore",100);
			}
		}
	}


		IEnumerator StartLoader() 
	{ 		
			rigidbody2D.velocity = Vector2.right * speed * 2;
						yield return new WaitForSeconds (2.0f);
						rigidbody2D.velocity = Vector2.right*speed*5;
			
				

	}
}
