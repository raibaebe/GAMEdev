using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private float moveInput, verInput;
	private Rigidbody2D rb;
	public float speed;
    // Start is called before the first frame update
    void Start()
    {
	    rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
	    move();
    }
	public void move(){
		moveInput = Input.GetAxis("Horizontal");
		verInput = Input.GetAxis("Vertical");
		rb.velocity = new Vector2(moveInput * speed, verInput*speed);
		//anim.Play(walkAnim);
	}

}
