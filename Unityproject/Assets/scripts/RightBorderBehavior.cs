using UnityEngine;
using System.Collections;

public class RightBorderBehavior : MonoBehaviour
{

    //public int k;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider2)
    {
        if (collider2.gameObject.tag == "mob")
        {
            DestroyObject(collider2.gameObject);
            //k++;
        }
    }
}
