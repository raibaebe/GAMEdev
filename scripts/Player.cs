using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	private float moveInput, verInput;
	private Rigidbody2D rb;
	public float speed, initialTemperature;
	public int Health;
	private Animator anim;
	[SerializeField] string walkAnim, idleAnim;
	
	[SerializeField] GameObject fakeloff, fakelon, ruka, toTreeFakelText, toFireFakelText, toChestOpenText;
	[SerializeField] Transform ShootPoint; 
	[SerializeField] GameObject fakelAsBullet, fireAsBullet;
	
	
	private int fakels = 0;
	private bool canShoot = false, facingRiht = false, lookingUp = false;
	private short counterToDownTree = 0;

	[SerializeField] Text fakelsText, healthText, temperatureText;
	
	
	public float temperature;
	
	
	public GameObject DeathParticles, DeathPanel, Skin;
	
	private bool takingFire = false;
	
	// Start is called before the first frame update
    void Start()
	{
		fakeloff.SetActive(false);
		fakelon	.SetActive(false);
		
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	    
		anim.Play(idleAnim);
		toTreeFakelText.SetActive(false);
		toFireFakelText.SetActive(false);
		toChestOpenText.SetActive(false);
		
		DeathPanel.SetActive(false);
		temperature = initialTemperature;
		
		StartCoroutine(decreaseTemp());
    }

    // Update is called once per frame
    void Update()
	{
		UIUpdater();
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
		
		if(Health <= 0)
		{
			Death();
		}
		if(temperature <= 0)
		{
			Death();
		}
		if(takingFire == true && temperature < initialTemperature)
		{
			temperature += 0.02f;
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
			if(takingFire)
			{
				Instantiate(fireAsBullet,ShootPoint.position, ShootPoint.rotation);
				fakelon.SetActive(false);
				fakeloff.SetActive(true);
				takingFire = false;
				fakels--;
			}
			else
			{
				Instantiate(fakelAsBullet, ShootPoint.position, ShootPoint.rotation);
				fakels--;
				
			}
			if(fakels <= 0)
				{
					canShoot = false;
					fakeloff.SetActive(false);
					fakelon.SetActive(false);
					ruka.SetActive(true);
				}
			
		}
	}
	
	public void takeDamage(int damage)
	{
		Health -= damage;
	}
	
	public void Death()
	{
		Instantiate(DeathParticles, transform.position, Quaternion.identity);
		DeathPanel.SetActive(true);
		//Destroy(gameObject);
		gameObject.SetActive(false);
		//GetComponent<SpriteRenderer>().enabled = false;
		
	}
	
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	protected void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Boss")
		{
			Death();
		}
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
			if(counterToDownTree >= 2)
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
		
		if(other.tag == "Fire")
		{
			if(canShoot)
			{
				toFireFakelText.SetActive(true);
				if(Input.GetKeyDown(KeyCode.F))
				{
					fakelon.SetActive(true);
					ruka.SetActive(false);
					toFireFakelText.SetActive(false);
					takingFire = true;
				}
			}
			
			if(temperature < initialTemperature)
			{
				temperature += 0.05f;
			}
			
		}
		
		if(other.tag == "Chest")
		{
			toChestOpenText.SetActive(true);
			if(Input.GetKey(KeyCode.F))
			{
				other.GetComponent<Chest>().Open();
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
		if(other.tag == "Fire")
		{
			toFireFakelText.SetActive(false);
		}
		if(other.tag == "Chest")
		{
			toChestOpenText.SetActive(false);
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
	
	IEnumerator decreaseTemp()
	{
		while(true)
		{
			temperature--;
			yield return new WaitForSeconds(1f);
		}
	}
	
	
	public void UIUpdater()
	{
		healthText.text = "Health: " + Health.ToString();
		fakelsText.text = "Fakels: " + fakels.ToString();
		temperatureText.text = "Temperature: " + temperature.ToString();
	}

}
