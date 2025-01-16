using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowfall : MonoBehaviour
{
	public float speed, LifeTime, distanceToPlayer;
	public LayerMask WhatIsSolid;
	
	public GameObject Particles;
	public int damage;
    // Start is called before the first frame update
    void Start()
    {
	    Destroy(gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
	    transform.Translate(Vector2.right*speed*Time.deltaTime);
	    RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, distanceToPlayer, WhatIsSolid);
	    
	    if(hitinfo.collider != null)
	    {
	    	Instantiate(Particles, transform.position, Quaternion.identity);
	    	Destroy(gameObject);
	    	
	    	if(hitinfo.collider.GetComponent<Player>() != null)
	    	{
	    		hitinfo.collider.GetComponent<Player>().takeDamage(damage);
	    	}
	    }

    }
}
