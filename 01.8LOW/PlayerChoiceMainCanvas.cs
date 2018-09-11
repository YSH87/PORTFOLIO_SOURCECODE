using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoiceMainCanvas : MonoBehaviour
{
	public GameObject[] playerBackGround;
	
	public int lastChoiceNum;

	private void Start()
	{
	lastChoiceNum = PlayerPrefs.GetInt("num2");
	PlayerSelec(lastChoiceNum);
	}

	public void PlayerSelec(int a)
	{
		lastChoiceNum = a;
		PlayerPrefs.SetInt("num2", lastChoiceNum);
		for (int i = 0; i < playerBackGround.Length; i++)
		{
			playerBackGround[i].SetActive(false);
		}
			playerBackGround[a].SetActive(true);
	}

	
}
