using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRevivalSpawn : MonoBehaviour
{
	public BlockManager playerJoystick;

	public int count;

	private void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			playerJoystick.centerline = count;
			Debug.Log(playerJoystick.centerline);
		}
	}
}
