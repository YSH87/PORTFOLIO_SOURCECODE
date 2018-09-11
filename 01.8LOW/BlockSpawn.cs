using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockSpawn : MonoBehaviour
{

	public GameObject block;
	public Transform blockSpawn;
	float time;
	void Start ()
	{
		time = Random.Range(1.5f,4.5f);
		StartCoroutine(CreateBlock());
	}
	
	// Update is called once per frame


	public IEnumerator CreateBlock()
	{
		while(true)
		{
			
			yield return new WaitForSeconds(time);
		}
		
	}


}
