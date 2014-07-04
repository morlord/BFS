using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeWeapon : MonoBehaviour {

    private Button btn;
	// Use this for initialization
	void Start () {
        btn = GetComponentInParent<Button>();
	    btn.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(4.5f,Camera.main.orthographicSize));//ViewportToWorldPoint(new Vector3(4f, 15f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
