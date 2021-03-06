﻿using UnityEngine;
using System.Collections;

public class insectoidcontroller : MonoBehaviour {

	
	public float speed;
	private Animator animator;
	public Rigidbody2D plasma;
	public ParticleSystem ParticleSystem1;
	private bool isLive = true;
	private bool isHurt = true;


	public int HP;
	private int timelimit=1;
	private int timelimit1=1;
	
	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
		ParticleSystem1.startDelay = Random.Range(1f, 1.6f);
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "bullet")
		{
			HP -= 20;
			DestroyObject(collider.gameObject);
			if (HP <= 30)
			{

				animator.SetBool("isHurt", false);
				transform.position.Set(transform.position.x, transform.position.y, 0);
				isHurt = false;
				DestroyObject(collider.gameObject);

			}

			if (HP <= 0)
			{
				animator.SetBool("isLive", false);
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				transform.position.Set(transform.position.x+4.0f, transform.position.y, 0);
				isLive = false;
				DestroyObject(collider.gameObject);
				GetComponent<Rigidbody2D>().GetComponent<Collider2D>().enabled = false;
			}
		}
	}
	
	private void ApplyForce(Vector2 direction)
	{
		GetComponent<Rigidbody2D>().AddForce(direction * speed * 10);
	}

	
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(ParticleSystem1.time);
		if (ParticleSystem1.isPlaying && ParticleSystem1.time>=(ParticleSystem1.duration-ParticleSystem1.startDelay-0.25f))
		{
			ParticleSystem1.Stop();
			ParticleSystem1.gameObject.SetActive(false);
		}
		if (timelimit > 1) {
			timelimit -= 1;
		}
		if (timelimit1 > 1) {
			timelimit1 -= 1;
		}
		
		if (timelimit == 1 && isHurt) {
			Rigidbody2D plasmaInstance = Instantiate (plasma, new Vector3 (transform.position.x + 0.7f, transform.position.y + 0.6f, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
			if (plasmaInstance != null)
				plasma.velocity = Vector2.right;
			timelimit = Random.Range (10, 70);
		}
		if (timelimit == 1 && !isHurt && isLive) 
		{
			Rigidbody2D plasmaInstance = Instantiate (plasma, new Vector3 (transform.position.x + 0.7f, transform.position.y + 0.6f, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
			if (plasmaInstance != null)
				plasma.velocity = Vector2.right;
			timelimit = Random.Range (100, 300);
		}
		if (timelimit1 == 1 && !isHurt && isLive)
		{
			//ParticleSystem biobulletInstance = Instantiate (ParticleSystem1, new Vector3 (transform.position.x+3.0f, transform.position.y, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0))) as ParticleSystem;
			//if (ParticleSystem1 != null)
			//Debug.Log(ParticleSystem1.isStopped.ToString()+" --stopped, "+ParticleSystem1.isPlaying+" --playing, "+ParticleSystem1.isPaused+" --paused");
			ParticleSystem1.gameObject.SetActive(true);
			ParticleSystem1.Play();
			timelimit1 = Random.Range(80, 170);
		}
	}
}
