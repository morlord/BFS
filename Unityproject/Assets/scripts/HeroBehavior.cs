﻿using System;
//using System.Xml.Serialization;
using System.IO;
using System.Linq;
using Assets.scripts;
using UnityEngine;
using UnityEngine.UI;

public class HeroBehavior : MonoBehaviour
{
    public float maxSpeed;
	[HideInInspector]
    public Animator anim; 
    public Rigidbody2D bullet;
    public Joystick  RJoystick;
	private bool isLive = true;
	public float hp;
	public float HP { get { return hp; } }
    //Vector2 inputForce;
	protected UnityEngine.UI.Text BulletsNum;
	public int bullets;
	private int bulletsNum;
	private bool isReloading = false;
	//private float reloadTime;
	public AudioClip reloadSound;
	public AudioClip fireSound;
	public float DeltaTime;
    private float deltaTime = 0.4f;
	public int Dmg=1;
	// Use this for initialization
	void Start ()
	{
			anim = GetComponent<Animator>();
			GetComponent<AudioSource>().clip = reloadSound;
			deltaTime = DeltaTime;
			bulletsNum = bullets;
			var texts = FindObjectsOfType<Text>();
			BulletsNum = texts.Single(a => a.name == "bullets");
			BulletsNum.text = bulletsNum.ToString();
	}

	void OnEnable()
	{
	}

	private bool LoadFromFile()
	{
		if (File.Exists("heroSave.xml"))
		{
			var hero = new Hero();
			Serializator.Deserialize("heroSave.xml",out hero);
			bullet = hero.bullet as Rigidbody2D;
			bullets = hero.bullets;
			DeltaTime = hero.deltaTime;
			transform.position = hero.position;
			var anims = FindObjectsOfType<Animator>();
			anim = anims.Single(a => a.name == hero.animator);
			reloadSound = hero.reloadSound;
			fireSound = hero.fireSound;
			return true;
		}
		else return false;
	}
	
	// Update is called once per frame
    private void FixedUpdate()
    {
		if (isLive)
		{
			var moveR = Input.GetAxis("Horizontal");
			var moveD = Input.GetAxis("Vertical");
			if (Mathf.Abs(moveD) > 0.1 || Mathf.Abs(moveR) > 0.1)
				GetComponent<Rigidbody2D>().velocity = new Vector2(moveR * maxSpeed, moveD * maxSpeed);
			else
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(RJoystick.position.x * maxSpeed, RJoystick.position.y * maxSpeed);
				if (GetComponent<Rigidbody2D>().velocity.x > 0)
				{
					GetComponent<Rigidbody2D>().velocity*=1.3f;
				}
			}
			anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.magnitude));
		}
	}
	
	public void Hit(float dmg)
	{
		hp -= dmg;
		//CheckHP();
		if (HP <= 0) Invoke("endGame", 2);
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "plasma")
		{
			hp -= 1;
			DestroyObject(collider.gameObject);
			CheckHP();
		}
	}

	private void CheckHP()
	{
		//Collider2D collider;
		if (HP <= 0)
		{
			anim.SetBool("isLive", false);
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			transform.position.Set(transform.position.x, transform.position.y, 0);
			isLive = false;
			//DestroyObject(collider.gameObject);
			GetComponent<Rigidbody2D>().GetComponent<Collider2D>().enabled = false;
			GetComponent<SpriteRenderer>().sortingLayerName = "mobs";
			Destroy(this);
			Invoke("endGame", 2);
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
			//bulletsNum = int.Parse(BulletsNum.text);
			if ((touch.position.x <= Screen.currentResolution.width / 2) && (deltaTime < 0) && !isReloading)
			{
				if (bulletsNum > 0)
				{
					deltaTime = DeltaTime;

					Rigidbody2D bulletInstance =
						Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z),
							Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
					if (bulletInstance != null) bulletInstance.velocity = Vector2.right * -1;
					GetComponent<AudioSource>().clip = fireSound;
					GetComponent<AudioSource>().Play();
					bulletsNum -= 1;
					BulletsNum.text = bulletsNum.ToString();
				}
			}
		}
		if ((Input.GetKey(KeyCode.Space)) && (deltaTime < 0) && !isReloading)
		{
			if (bulletsNum > 0)
			{
				deltaTime = DeltaTime;

				Rigidbody2D bulletInstance =
					Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z),
						Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
				if (bulletInstance != null) bulletInstance.velocity = Vector2.right * -1;
				GetComponent<AudioSource>().clip = fireSound;
				GetComponent<AudioSource>().Play();
				bulletsNum -= 1;
				BulletsNum.text = bulletsNum.ToString();
			}
		}
		if (bulletsNum <= 0 && !isReloading && !GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource>().clip = reloadSound;
			isReloading = true;
			GetComponent<AudioSource>().Play();
			//reloadTime = reloadSound.length;
		}
		if (isReloading)
		{
			//reloadTime -= Mathf.Abs(deltaTime);
			if (!GetComponent<AudioSource>().isPlaying)
			{
				isReloading = false;
				bulletsNum = bullets;
				BulletsNum.text = bulletsNum.ToString();
			}
		}
	}

	void SetBullets()
	{
		bulletsNum = bullets;
		var texts = FindObjectsOfType<Text>();
		BulletsNum = texts.Single(a => a.name == "bullets");
		BulletsNum.text = bulletsNum.ToString();
	}
}
