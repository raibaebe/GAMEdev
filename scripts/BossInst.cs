using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInst : MonoBehaviour
{
	public GameObject Boss, Spawner;
	public FakelAsBullet pl;
	private bool Spawned;
	public int NeededScore;
    // Start is called before the first frame update
	void Instant()
    {
	    Instantiate(Boss, Spawner.transform.position, Spawner.transform.rotation);
	    Spawned = true;
    }

    // Update is called once per frame
    void Update()
    {
	    if(pl.score >= NeededScore && Spawned == false)
	    {
	    	Instant();
	    }
    }
}
