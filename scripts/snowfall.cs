using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowfall : MonoBehaviour
{
	public float speed, LifeTime;
    // Start is called before the first frame update
    void Start()
    {
	    Destroy(gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
	    transform.Translate(Vector2.right*speed*Time.deltaTime);
	    
    }
}
