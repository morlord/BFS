using UnityEngine;
using System.Collections;

public class PlasmaBehaviourScript : MonoBehaviour {

	public float speed;
	public float LifeTime;
	// Use this for initialization
	void Start()
	{
		Destroy(gameObject,LifeTime);
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		rigidbody2D.velocity = Vector2.right * speed;
	}
}
