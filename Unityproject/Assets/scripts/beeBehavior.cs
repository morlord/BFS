using UnityEngine;
using System.Collections;

public class beeBehavior : MonoBehaviour
{

    public float speed;
    private Animator animator;
    private bool isLive = true;
    private SpawnController controller;
    public int HP;
	public int dmg;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = FindObjectOfType<SpawnController>();

		//Debug.Log ("start debug");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isLive)
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
		//Debug.Log ("collides");
        if (collider.gameObject.tag == "bullet")
        {
			dmg = FindObjectOfType<HeroBehavior>().Dmg;
            HP -= dmg;
			//HP -=1;
            DestroyObject(collider.gameObject);
            if (HP <= 0)
            {
                animator.SetBool("isLive", false);
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                transform.position.Set(transform.position.x, transform.position.y, 0);
                isLive = false;
                DestroyObject(collider.gameObject);
                Destroy(GetComponent<Rigidbody2D>().GetComponent<Collider2D>());
				gameObject.layer = 0;
				this.GetComponent<SpriteRenderer>().sortingOrder = 0;
                controller.BroadcastMessage("AddScore",7);
            }
        }
    }

    private void ApplyForce(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * speed * 10);
    }
}