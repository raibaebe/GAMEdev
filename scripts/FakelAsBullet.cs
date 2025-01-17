using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakelAsBullet : MonoBehaviour
{	public float speed, LifeTime, distanceToEnemy;
	public LayerMask WhatIsSolid;
	
	public GameObject Particles;
	public int score;
	// Start is called before the first frame update
	void Start()
	{
		Destroy(gameObject, LifeTime);
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(Vector2.right*speed*Time.deltaTime);
		RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, distanceToEnemy, WhatIsSolid);
	    
		if(hitinfo.collider != null)
		{
			Instantiate(Particles, transform.position, Quaternion.identity);
			Destroy(gameObject);
	    	
			if(hitinfo.collider.GetComponent<SnowMan>() != null)
			{
				Destroy(hitinfo.collider.gameObject);
				score++;
			}
			else if(hitinfo.collider.gameObject.GetComponent<Boss>() != null)
			{
				Destroy(gameObject);
				hitinfo.collider.gameObject.GetComponent<Boss>().takeDamage(1);
			}
		}

	}
}
