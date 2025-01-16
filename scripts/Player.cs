using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	private float moveInput, verInput;
	private Rigidbody2D rb;
	public float speed;
	public int Health;
	private Animator anim;
	[SerializeField] string walkAnim, idleAnim;
	
	[SerializeField] GameObject fakeloff, fakelon, ruka, toTreeFakelText;
	[SerializeField] Transform ShootPoint; 
	[SerializeField] GameObject fakelAsBullet;
	
	private short counterToDownTree = 0;
	
	private int fakels = 0;
	private bool canShoot = false, facingRiht = false, lookingUp = false;
	// Start is called before the first frame update
    void Start()
	{
		fakeloff.SetActive(false);
		fakelon	.SetActive(false);
		
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	    
		anim.Play(idleAnim);
		toTreeFakelText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
	{
		Debug.Log(canShoot);
		move();
		if(moveInput == 0 && verInput == 0)
		{
			anim.Play(idleAnim);
		}
		
		if(moveInput < 0)
		{
			if(facingRiht == true)
			{
				flip();
			}
			
			rotateShootPoint(new Vector3(0f, 0f, 180f));
		}
		else if(moveInput > 0 )
		{
			if(facingRiht == false)
			{
				flip();
			}
			
			rotateShootPoint(new Vector3(0f, 0f, 0f));
		}
		
		if(verInput > 0 )
		{
			if(lookingUp == false)
			{
				rotateShootPoint(new Vector3(0f, 0f, 90f));
				lookingUp = true;
			}
			
		}
		
		else if(verInput < 0 )
		{
			if(lookingUp == true)
			{
				rotateShootPoint(new Vector3(0f, 0f, -90f));
				lookingUp = false;
			}
		}
		
		
		if(canShoot == true)
		{
			Shoot();
			
		}
	}
    

	public void move(){
		moveInput = Input.GetAxis("Horizontal");
		verInput = Input.GetAxis("Vertical");
		rb.velocity = new Vector2(moveInput * speed, verInput*speed);
		
		if(moveInput != 0 || verInput != 0) anim.Play(walkAnim);
	}
	
	public void Shoot()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			Instantiate(fakelAsBullet, ShootPoint.position, ShootPoint.rotation);
			fakels--;
			if(fakels <= 0)
			{
				canShoot = false;
			}
		}
	}
	
	public void takeDamage(int damage)
	{
		Health -= damage;
	}
	
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Tree")
		{
			toTreeFakelText.SetActive(true);
			if(Input.GetKeyDown(KeyCode.F))
			{
				counterToDownTree++;
			}
			if(counterToDownTree == 3)
			{
				counterToDownTree = 0;
				fakeloff.SetActive(true);
				ruka.SetActive(false);
				canShoot = true;
				fakels += 15;
				toTreeFakelText.SetActive(false);
				Destroy(other.gameObject);
			}
			
		}
	}
	
	// Sent when another object leaves a trigger collider attached to this object (2D physics only).
	protected void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Tree")
		{
			toTreeFakelText.SetActive(false);
		}
	}
	
	public void rotateShootPoint(Vector3 angles)
	{
		Quaternion degree = Quaternion.Euler(angles);
		ShootPoint.rotation = degree;
	}
	
	public void flip()
	{
		facingRiht = !facingRiht;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
		
	}

}
