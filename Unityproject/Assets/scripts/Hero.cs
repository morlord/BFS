using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

namespace Assets.scripts
{
	[XmlRoot("Hero")]
	public class Hero
	{
		[XmlIgnore]
		protected GameObject _inst;
		public GameObject inst { set { _inst = value; } }
		[XmlElement("heroPosition")]
		public Vector3 position;
		[XmlElement("animatorController")]
		public string animator;
		[XmlElement("bullet")]
		public UnityEngine.Object bullet;
		[XmlElement("bulletsNum")]
		public int bullets;
		[XmlElement("reloadSound")]
		public AudioClip reloadSound;
		[XmlElement("fireSound")]
		public AudioClip fireSound;
		[XmlElement("deltaTime")]
		public float deltaTime;

		public Hero() { }

		public Hero(HeroBehavior hero)
		{
			inst = hero.gameObject;
			position = hero.transform.position;
			animator = hero.anim.name;
			bullet = PrefabUtility.GetPrefabObject(hero.bullet);
			bullets = hero.bullets;
			reloadSound = hero.reloadSound;
			fireSound = hero.fireSound;
			deltaTime = hero.DeltaTime;
		}

	}
}
