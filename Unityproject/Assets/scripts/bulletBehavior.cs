using UnityEngine;
using System.Collections;

public class bulletBehavior : MonoBehaviour
{

    public float speed;
    public float LifeTime;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject,LifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = -Vector2.right * speed;
    }
}