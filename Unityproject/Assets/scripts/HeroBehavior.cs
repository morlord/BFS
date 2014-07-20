using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class HeroBehavior : MonoBehaviour
{

    public float maxSpeed;
    private Animator anim; 
    public Rigidbody2D bullet;
    public Joystick LJoystick, RJoystick;
	private bool isLive = true;
	public int HP;
    Vector2 inputForce;

    private float deltaTime = 0.5f;
	// Use this for initialization
	void Start ()
    {
        inputForce = new Vector2(0f, 0f);
	    anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
    private void FixedUpdate()
    {
		if (isLive) {
			var moveR = Input.GetAxis ("Horizontal");
			var moveD = Input.GetAxis ("Vertical");
			if (Mathf.Abs (moveD) > 0.1 || Mathf.Abs (moveR) > 0.1)
				rigidbody2D.velocity = new Vector2 (moveR * maxSpeed, moveD * maxSpeed);
			else {
				rigidbody2D.velocity = new Vector2 (RJoystick.position.x * maxSpeed, RJoystick.position.y * maxSpeed);

			}
			anim.SetFloat ("Speed", Mathf.Abs (rigidbody2D.velocity.magnitude));
		}
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "plasma")
		{
			HP -= 1;
			DestroyObject(collider.gameObject);
			if (HP <= 0)
			{
				anim.SetBool("isLive", false);
                rigidbody2D.velocity = Vector2.zero;
                transform.position.Set(transform.position.x, transform.position.y, 0);
				isLive = false;
				DestroyObject(collider.gameObject);
				rigidbody2D.collider2D.enabled = false;
			}
		}
	}

    void Update()
    {
        deltaTime -= Time.deltaTime;
        if ((Input.GetKey(KeyCode.Space)||LJoystick.IsFingerDown()) &&deltaTime<0)
        {
            deltaTime = 0.5f;
            Rigidbody2D bulletInstance = Instantiate(bullet, new Vector3( transform.position.x,transform.position.y+0.4f,transform.position.z), Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
            if (bulletInstance != null) bulletInstance.velocity = Vector2.right*-1;
        }
        

    }
}
