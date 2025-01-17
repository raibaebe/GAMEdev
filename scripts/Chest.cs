using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
	public GameObject[] Bonuses;
	private bool isOpened;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	public void Open()
	{
		int rand = Random.Range(0,2);
		GameObject bonus = Bonuses[rand];
		Vector3 instpos = transform.position;
		instpos.x = transform.position.x + 1;
		if(isOpened == false) Instantiate(bonus, instpos, Quaternion.identity);
		isOpened = true;
		StartCoroutine(DestroyChest());
	}
	
	IEnumerator DestroyChest()
	{
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}
}
