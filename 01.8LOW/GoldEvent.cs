using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.UI;

public class GoldEvent : MonoBehaviour
{
	public AudioSource GoldAddclick;
	public Gold gold;
	public GameObject goldBtn;
	public Text goldBtnText;
	public Slider goldPerSec;

	void Start ()
	{
		if(timeAfterLastPlay == 0)
		{
			goldBtn.SetActive(true);
		}
	}
	private void Update()
	{
		goldBtnText.text = ((timeAfterLastPlay % 3600) / 60) + "M " + (timeAfterLastPlay % 60) + "S / 10M";

		goldPerSec.value = timeAfterLastPlay;
		
		if(timeAfterLastPlay < 600 && timeAfterLastPlay > 1)
		{
			goldBtn.SetActive(false);
		}
		if(timeAfterLastPlay > 600)
		{
			goldBtn.SetActive(true);
			goldBtnText.text = "10M / 10M";
		}
		
	}

	public int timeAfterLastPlay
	{
		get
		{
			DateTime currrentTime = DateTime.Now;
			DateTime lastPlayDate = GetLastPlayDate();

			return (int)currrentTime.Subtract(lastPlayDate).TotalSeconds;
		}
	}
	DateTime GetLastPlayDate()
	{
		if(!PlayerPrefs.HasKey("Time"))
		{
			return DateTime.Now;
		}
		string timebinaryInString = PlayerPrefs.GetString("Time");
		long timebinaryInLong = Convert.ToInt64(timebinaryInString);

		return DateTime.FromBinary(timebinaryInLong);
	}
	
	public void UpdateLastPlayDate()
	{
		PlayerPrefs.SetString("Time",DateTime.Now.ToBinary().ToString());
	}


	
}
