using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowMan : MonoBehaviour
{
	public float speed, distanceToCheck;
	private bool facingRiht;
	private bool isRunningAfter;
	public LayerMask WhatIsSolid;
	
	public int direction;
	private Player player;
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
	{

		transform.Translate(Vector2.left*speed*Time.deltaTime);
		check();
	    
    }
    
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Turn")
		{
			flip();
		}
	}
	
	public void check()
	{
		RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.forward, distanceToCheck);
		foreach(RaycastHit2D hit in hits)
		{
			
			if(hit != null && hit.collider.GetComponent<Player>() != null)
			{
				speed = 0;
			}
		}
		
	}
	
	public void goToPlayer()
	{
		
	}
	
	public void flip()
	{
		facingRiht = !facingRiht;
		speed = -speed;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
		
	}
}
