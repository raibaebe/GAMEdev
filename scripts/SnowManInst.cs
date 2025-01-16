using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManInst : MonoBehaviour
{
	public GameObject snowMan;
	public float timeBetween, initialTimeBetween;
    // Start is called before the first frame update
    void Start()
    {
	    //Instantiate(snowMan, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
	    if(timeBetween <= 0)
	    {
	    	Instantiate(snowMan, transform.position, Quaternion.identity);
	    }
	    else
	    {
	    	timeBetween = initialTimeBetween;
	    }
    }
}
