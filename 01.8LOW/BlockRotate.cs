using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockRotate : MonoBehaviour
{

	public GameObject block;
	public Transform blockSpawn;
	float time;
	void Start ()
	{
		time = Random.Range(1.5f,5);
		StartCoroutine(CreateBlock());
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public IEnumerator CreateBlock()
	{
		while(true)
		{
			Instantiate(block, blockSpawn.position, blockSpawn.rotation);
			yield return new WaitForSeconds(time);
		}
		
	}


}
