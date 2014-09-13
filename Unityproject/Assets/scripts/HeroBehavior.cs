using UnityEngine;

public class HeroBehavior : MonoBehaviour
{

    public float maxSpeed;
    private Animator anim; 
    public Rigidbody2D bullet;
    public Joystick  RJoystick;
	private bool isLive = true;
	public int HP;
    Vector2 inputForce;
	public UnityEngine.UI.Text BulletsNum;
	public int bullets;
	private bool isReloading = false;
	private float reloadTime;
	public AudioClip reloadSound;
	public AudioClip fireSound;

    private float deltaTime = 0.5f;
	// Use this for initialization
	void Start ()
    {
        inputForce = new Vector2(0f, 0f);
		anim = GetComponent<Animator>();
		audio.clip = reloadSound;
		
	}
	
	// Update is called once per frame
    private void FixedUpdate()
    {
		if (isLive)
		{
			var moveR = Input.GetAxis("Horizontal");
			var moveD = Input.GetAxis("Vertical");
			if (Mathf.Abs(moveD) > 0.1 || Mathf.Abs(moveR) > 0.1)
				rigidbody2D.velocity = new Vector2(moveR * maxSpeed, moveD * maxSpeed);
			else
			{
				rigidbody2D.velocity = new Vector2(RJoystick.position.x * maxSpeed, RJoystick.position.y * maxSpeed);
				if (rigidbody2D.velocity.x > 0)
				{
					rigidbody2D.velocity*=1.3f;
				}
			}
			anim.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.magnitude));
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
				GetComponent<SpriteRenderer>().sortingLayerName = "mobs";
				Invoke("endGame",2);
			}
		}
	}

	void endGame()
	{
		Application.LoadLevel(3);
	}

	private void Update()
	{
		RJoystick.touchZone = new Rect(Screen.width/2, 0, Screen.width/2, Screen.height);
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel(0);
		}
		deltaTime -= Time.deltaTime;
		var touchC = Input.touchCount;
		for (int i = 0; i < touchC; i++)
		{
			var touch = Input.GetTouch(i);
			if ((Input.GetKey(KeyCode.Space) || touch.position.x <= Screen.currentResolution.width/2) && deltaTime < 0)
			{
				deltaTime = 0.3f;
				Rigidbody2D bulletInstance =
					Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z),
						Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
				if (bulletInstance != null) bulletInstance.velocity = Vector2.right*-1;
			}
		}
		var bulletsnum = int.Parse(BulletsNum.text);
		if ((Input.GetKey(KeyCode.Space)) && (deltaTime < 0) && !isReloading)
		{
			if (bulletsnum > 0)
			{
				deltaTime = 0.3f;
				Rigidbody2D bulletInstance =
					Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z),
						Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
				if (bulletInstance != null) bulletInstance.velocity = Vector2.right*-1;
				audio.clip = fireSound;
				audio.Play();
				bulletsnum -= 1;
				BulletsNum.text = bulletsnum.ToString();
			}
		}
		if (bulletsnum <= 0 && !isReloading)
		{
			isReloading = true;
			audio.Play();
			reloadTime = reloadSound.length;
		}
		if(isReloading)
		{
			reloadTime -= Mathf.Abs(deltaTime);
			if (reloadTime <= 0)
			{
				isReloading = false;
				BulletsNum.text = bullets.ToString();
			}
		}

	}
}
