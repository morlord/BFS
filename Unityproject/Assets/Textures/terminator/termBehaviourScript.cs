using UnityEngine;
using System.Collections;

public class termBehaviourScript : MonoBehaviour {
	public float speed;
	public Animator animator;
	private bool isLive = true;
	public int HP;
	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if(isLive)
			rigidbody2D.velocity = Vector2.right * speed;
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "bullet")
		{
			HP -= 1;
			DestroyObject(collider.gameObject);
			if (HP <= 0)
			{
				animator.SetBool("isLive", false);
				rigidbody2D.velocity = Vector2.zero;
				isLive = false;
				DestroyObject(collider.gameObject);
				rigidbody2D.collider2D.enabled = false;
			}
		}
	}
	
	private void ApplyForce(Vector2 direction)
	{
		rigidbody2D.AddForce(direction * speed * 10);
	}
}
