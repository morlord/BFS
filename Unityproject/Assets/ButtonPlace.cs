using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonPlace : MonoBehaviour
{
    private Button btn;
	// Use this for initialization
	void Start ()
	{

        btn = GetComponentInParent<Button>();
        btn.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(14f, 55f));

	}
	
	// Update is called once per frame
    void Update()
    {
	}
}
