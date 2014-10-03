using UnityEngine;
using System.Collections;

public class insectoidcontroller : MonoBehaviour {

	
	public float speed;
	private Animator animator;
	public Rigidbody2D plasma;
	public Rigidbody2D biobullet;
	private bool isLive = true;
	private bool isHurt = true;
	public int HP;
	private int timelimit=1;
	private int timelimit1=1;
	
	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if(!isHurt&&isLive)
			rigidbody2D.velocity = Vector2.zero;
		if (isLive && isHurt)
		   rigidbody2D.velocity = Vector2.right * speed;

	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "bullet")
		{
			HP -= 1;
			DestroyObject(collider.gameObject);
			if (HP <= 30)
			{

				animator.SetBool("isHurt", false);
				rigidbody2D.velocity = Vector2.right * speed;
				transform.position.Set(transform.position.x, transform.position.y, 0);
				isHurt = false;
				DestroyObject(collider.gameObject);
				rigidbody2D.collider2D.enabled = false;
			}
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
		
		if (timelimit > 1) {
			timelimit -= 1;
		}
		if (timelimit1 > 1) {
			timelimit -= 1;
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
			Rigidbody2D biobulletInstance = Instantiate (biobullet, new Vector3 (transform.position.x + 9.0f, transform.position.y + 0.6f, transform.position.z), Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
			if (biobulletInstance != null)
				biobullet.velocity = Vector2.right;
			timelimit1 = Random.Range (100, 300);
		}
	}
}
