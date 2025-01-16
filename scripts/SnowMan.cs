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
	
	private Vector3 difference;
	
	private float rotz;
	public float offset;
	private bool Found = false;
    // Start is called before the first frame update
    void Start()
	{
		player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
	{

		transform.Translate(Vector2.left*speed*Time.deltaTime);
		check();
		if(Found)
		{
			goToPlayer();
		}
	    
    }
    
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Turn")
		{
			if(Found == false) flip();
		}
	}
	
	public void check()
	{
		RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.right, distanceToCheck);
		foreach(RaycastHit2D hit in hits)
		{
			
			if(hit.collider.GetComponent<Player>() != null)
			{
				Found = true;
			}
		}
		
	}
	
	public void goToPlayer()
	{
		difference = player.transform.position - transform.position;
		rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
		//if(difference.x > 0 && facingRiht == false)
		//{
		//	flip();
		//}
		//else if(difference.x < 0 && facingRiht == true)
		//{
		//	flip();
		//}

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
