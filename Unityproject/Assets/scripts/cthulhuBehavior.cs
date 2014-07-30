using UnityEngine;
using System.Collections;

public class cthulhuBehavior : MonoBehaviour
{

    public float speed;
    private Animator animator;
    private bool isLive = true;
    public int HP;
    public GameObject skvi;
    public float tim = 0;
    private Vector3 delta;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        delta = new Vector3(0.4f, 0f,0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLive)
            rigidbody2D.velocity = Vector2.right * speed;
        tim = animator.GetCurrentAnimatorStateInfo(0).normalizedTime%1;
        //if (!animator.GetBool("isLive") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 > 0.9)
        //{
        //    DestroyObject(this.gameObject);
        //}
    }

    void CreateMob()
    {
        Instantiate(skvi, transform.position+delta, transform.rotation);
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
                transform.position.Set(transform.position.x,transform.position.y,0);
                rigidbody2D.velocity = Vector2.zero;
                isLive = false;
                DestroyObject(collider.gameObject);
                rigidbody2D.collider2D.enabled = false;
	            this.GetComponent<SpriteRenderer>().sortingOrder = 0;
                Invoke("CreateMob", 0.6f);
            }
        }
    }

    private void ApplyForce(Vector2 direction)
    {
        rigidbody2D.AddForce(direction * speed * 10);
    }
}