using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove_CrossCube : MonoBehaviour
{
	public GameObject cubes1;
	public GameObject cubes2;
	public GameObject cubes3;
	private void Start()
	{
		StartCoroutine(CrossCube());
	}
	
	IEnumerator CrossCube()
	{
		while(true)
		{
			for (int i = 0; i < 1000; i++)
			{
				yield return new WaitForSeconds(0f);
				cubes1.SetActive(true);
				yield return new WaitForSeconds(1f);
				cubes1.SetActive(false);
				cubes2.SetActive(true);
				yield return new WaitForSeconds(1f);
				cubes2.SetActive(false);
				cubes3.SetActive(true);
				yield return new WaitForSeconds(1f);
				cubes3.SetActive(false);
			}
			yield return new WaitForSeconds(0f);
		}
	}

}
