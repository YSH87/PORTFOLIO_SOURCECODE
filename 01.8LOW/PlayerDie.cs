using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
	public GameObject end;
	private void OnCollisionEnter(Collision other)
	{
		if(other.transform.tag == "Player")
		{
			Time.timeScale = 0;
			end.SetActive(true);
		}	
	}
}
