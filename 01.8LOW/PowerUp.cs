using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour 
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "block")
		{
			other.transform.tag = "PowerUP";
		}	
	}
	private void OnTriggerExit(Collider other)
	{
		
		other.transform.tag = "block";
	}
}
