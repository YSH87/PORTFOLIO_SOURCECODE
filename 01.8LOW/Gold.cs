using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{

	[HideInInspector]
	public int gold;

	public Text goldText;
	public Text goldText2;

	private void Awake()
	{
		gold = PlayerPrefs.GetInt("Gold");
		UIUpdate();
	}

	public void GoldAdd(int add)
	{
		gold += add;
		PlayerPrefs.SetInt("Gold", gold);
		UIUpdate();
	}

	public void GoldMinus(int minus)
	{
		if(gold >= minus)
		{
			gold -= minus;
		}
		PlayerPrefs.SetInt("Gold", gold);
		UIUpdate();
	}

	public void UIUpdate()
	{
		goldText.text = gold + " G";
		goldText2.text = gold + " G";
	}

	public void GoldReset()
	{
		PlayerPrefs.DeleteKey("Gold");
	}

}
