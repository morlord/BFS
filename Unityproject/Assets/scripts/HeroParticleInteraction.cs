using Assets.scripts;
using UnityEngine;
using System.Collections;

public class HeroParticleInteraction : MonoBehaviour
{

	private HeroBehavior hero;
	// Use this for initialization
	void Start ()
	{
		hero = GetComponentInParent<HeroBehavior>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnParticleCollision(GameObject other)
	{
		if (hero != null)
		{
			Debug.Log(other.name);
			hero.Hit(0.1f);
		}
	}
}
