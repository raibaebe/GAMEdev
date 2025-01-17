using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManShoot : MonoBehaviour
{
	public float offset;
	public GameObject bullet;
	public Transform shootPoint;

	private float timeBtwShots;
	public float startTimeBtw;

	private float rotz;
	private Vector3 difference;
	private Player player;

    // Start is called before the first frame update
    void Start()
    {
	    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
	    if(player != null)
	    {
	    	difference = player.transform.position - transform.position;
		    rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		    transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);

	    }
	    //else
	    //{
	    //	player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	    //}
	    
	    if(timeBtwShots <= 0)
	    {
	    	Shoot();
	    }
	    
	    else 
	    {
	    	timeBtwShots -= Time.deltaTime;
	    }
    }
    
	public void Shoot(){
		timeBtwShots = startTimeBtw;
		Instantiate(bullet, shootPoint.position, shootPoint.rotation);
	}

}
