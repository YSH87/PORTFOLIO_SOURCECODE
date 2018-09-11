using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoice : MonoBehaviour
{
	public GameObject[] players;
	
	public int lastChoiceNum;

	private void Start()
	{
	lastChoiceNum = PlayerPrefs.GetInt("Playerlastnum");
	PlayerSelec(lastChoiceNum);
	}

	public void PlayerSelec(int a)
	{
		lastChoiceNum = a;
		PlayerPrefs.SetInt("Playerlastnum", lastChoiceNum);
		for (int i = 0; i < players.Length; i++)
		{
			players[i].SetActive(false);
		}
			players[a].SetActive(true);
	}
	
	
}
