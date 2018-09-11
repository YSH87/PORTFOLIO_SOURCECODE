using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCube : MonoBehaviour
{
	public Transform target;
	public Transform cube;

	public bool playerLookAt;

	private void Start()
	{
		playerLookAt = false;
		target = GameObject.Find("Player").transform;
		
	}
	
	void Update ()
	{
		

		if(playerLookAt)
		{
			cube.transform.LookAt(target,Vector3.up);
			cube.transform.position =
			Vector3.Lerp(cube.transform.position,target.position,0.9f * Time.deltaTime);			
		}

	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			playerLookAt = true;
		}
	}
}
