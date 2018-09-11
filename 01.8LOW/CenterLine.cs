using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterLine : MonoBehaviour
{
	public GameObject[] blocks;
	public GameObject block;
	public GameManager gameManager;
	public BlockManager blockManager;
	public Transform spawnPoint1;
	public int index1 = 0;
	public int count;


	private void Start()
	{
		index1 = Random.Range(0,4);
	}

	public void NextFloor()
	{
		if(gameManager.nextFloor == true)
		{
			if(gameManager.nextFloorCount == 1)
			{
				index1 = Random.Range(0, 4);
			}
			if(gameManager.nextFloorCount == 2)
			{
				index1 = Random.Range(4, 8);
			}
			if(gameManager.nextFloorCount == 3)
			{
				index1 = Random.Range(8, 12);
			}
			if(gameManager.nextFloorCount >= 4)
			{
				index1 = Random.Range(12, 24);
			}
			
		}
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			
			count+=1;
			if(count == 1)
			{
				block = Instantiate(blocks[index1],spawnPoint1.position,spawnPoint1.rotation);
				block.SetActive(true);
			}
			
			
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			count=0;
			block.SetActive(false);
		}
	}

	
}
