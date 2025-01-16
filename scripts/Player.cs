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
	
	private short counterToDownTree;
	
	private int fakels = 0;
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
		move();
		if(moveInput == 0 && verInput == 0)
		{
			anim.Play(idleAnim);
		}
    }
	public void move(){
		moveInput = Input.GetAxis("Horizontal");
		verInput = Input.GetAxis("Vertical");
		rb.velocity = new Vector2(moveInput * speed, verInput*speed);
		
		if(moveInput != 0 || verInput != 0) anim.Play(walkAnim);
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
			if(Input.GetKey(KeyCode.F))
			{
				counterToDownTree++;
			}
			if(counterToDownTree == 3)
			{
				counterToDownTree = 0;
				fakeloff.SetActive(true);
				ruka.SetActive(false);
				fakels = 5;
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

}
