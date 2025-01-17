using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	private bool facingRiht;
	private Player player;
	
	private Vector3 difference;
	
	private float rotz;
	public float offset;
	
	public float speed;
	public int health;
	
	private bool Rotated = false;
	
	
	public GameObject WinPanel, WinParticle;
	
    // Start is called before the first frame update
    void Start()
    {
	    player = FindObjectOfType<Player>();
    }
	 

    // Update is called once per frame
    void Update()
	{
		if(player != null)
		{
			 transform.Translate(Vector2.left*speed*Time.deltaTime);
			 goToPlayer();
		}
		if(health <= 0)
		{
			Death();
		}
    }
    
	public void takeDamage(int damage)
	{
		health -= damage;
	}
	
	public void goToPlayer()
	{
		difference = player.transform.position - transform.position;
		rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
		if(difference.x > 0 && facingRiht == false && Rotated == false)
		{
			flip();
			Rotated =true;
		}
		else if(difference.x < 0 && facingRiht == true && Rotated == false)
		{
			flip();
			Rotated = true;
		}
		if(!Rotated)
		{
			if(difference.x > 0 && facingRiht == true || difference.x < 0 && facingRiht == false)
			{
				Rotated = true;
			}
		}

	}
	
	public void Death()
	{
		WinPanel.SetActive(true);
		Instantiate(WinParticle, transform.position, Quaternion.identity);
		Destroy(gameObject);
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
