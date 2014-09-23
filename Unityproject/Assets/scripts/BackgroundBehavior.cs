using UnityEngine;
using System.Collections;

public class BackgroundBehavior : MonoBehaviour
{

    private new SpriteRenderer renderer;
    private Color curColor;
    public float alpha=1;
    public float curAlpha;
    private bool _isUp;
    private float _timeElapsed;
	// Use this for initialization
	void Start ()
	{
	    renderer = GetComponent<SpriteRenderer>();
	    curColor = renderer.color;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    _timeElapsed += Time.deltaTime;
        if (alpha >= 1)
            _isUp = false;
        if (alpha <= 0)
            _isUp = true;
        if (_isUp && _timeElapsed > 0.1)
        {
            alpha += 0.10f;
            _timeElapsed = 0;
        }
        if (!_isUp && _timeElapsed > 0.1)
        {
            alpha -= 0.10f;
            _timeElapsed = 0;
        }
	    renderer.color=new Color(curColor.r,curColor.g,curColor.g,alpha);
	    curAlpha = renderer.color.a;
	}
}
