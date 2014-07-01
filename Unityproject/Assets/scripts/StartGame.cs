using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var btn=GetComponent<Button>();
        btn.onClick.AddListener(OnPointerClick);

	}
	
	// Update is called once per frame
	void Update () {

        //GetComponent<Button>().transform.position = Camera.main.ViewportToScreenPoint(new Vector3(0.18f, 0.75f, 1));
	}
    
    void OnPointerClick(Button btn)
    {
        Application.LoadLevel(1);
    }
}
