using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInst : MonoBehaviour
{
	public GameObject Boss, Spawner;
	public Score pl;
	private bool Spawned;
	public int NeededScore;
	
	public GameObject Text;
	
    // Start is called before the first frame update
	void Instant()
    {
	    Instantiate(Boss, Spawner.transform.position, Spawner.transform.rotation);
	    Spawned = true;
	    Text.SetActive(true);
	    StartCoroutine(aaaa());
    }

    // Update is called once per frame
    void Update()
    {
	    if(pl.score >= NeededScore && Spawned == false)
	    {
	    	Instant();
	    }
    }
    
	IEnumerator aaaa()
	{
		yield return new WaitForSeconds(2f);
		Text.SetActive(false);
		Destroy(gameObject);
	}
}
