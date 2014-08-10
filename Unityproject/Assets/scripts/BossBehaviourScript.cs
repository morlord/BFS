using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class BossBehaviourScript : MonoBehaviour {

	
	public float speed;
	private Animator animator;
	public Rigidbody2D plasma;
	private bool isLive = true;
	public int HP;
	private int timelimit=1;

		// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
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
                transform.position.Set(transform.position.x, transform.position.y, 0);
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
	
	// Update is called once per frame
	void Update () {
	
		if (timelimit > 1) 
		{
			timelimit -= 1;
		}
	
	
	if (timelimit == 1 &&isLive) 
		
		{
			Rigidbody2D plasmaInstance = Instantiate(plasma, new Vector3( transform.position.x+0.7f,transform.position.y+0.9f,transform.position.z), Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			if (plasmaInstance != null) plasma.velocity = Vector2.right;
			timelimit = Random.Range(10, 70);
		}
	}
}

