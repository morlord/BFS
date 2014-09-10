using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeWeapon : MonoBehaviour
{

    private bool paused=false;
	// Use this for initialization
	void Start () {
	    //gameObject.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(4f, 65f));
	}
	
	// Update is called once per frame
	void Update () {
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        } 
	}

    public void ChangeWeaponWindow(GameObject gameObject)
    {
        paused = true;
        //var go = GameObject.Find("Window");
        gameObject.SetActive(true);
    }

    public void SetWeapon(RuntimeAnimatorController controler)
    {
        paused = false;
        var hero = GameObject.Find("hero");
        var controller = hero.GetComponent<Animator>();
        controller.runtimeAnimatorController = controler;
    }
	public void SetBullet(Rigidbody2D bullet)
	{
		paused = false;
		var hero = GameObject.Find("hero").GetComponent<HeroBehavior>();
		hero.bullet = bullet;
		var go = GameObject.Find("Window");
		go.SetActive(false);
	}
}
