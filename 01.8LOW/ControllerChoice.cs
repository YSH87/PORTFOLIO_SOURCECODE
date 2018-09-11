using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerChoice : MonoBehaviour
{
	public AudioSource click;
	public GameObject joyStick;
	public GameObject touchPad;

	public Outline joyStickOL;
	public Outline touchPadOL;

	public int lastChoiceNum;

	private void Start()
	{
		lastChoiceNum = PlayerPrefs.GetInt("lastnum");
		Sel(lastChoiceNum);
	}

	public void Sel(int num)
	{
		lastChoiceNum = num;
		PlayerPrefs.SetInt("lastnum", lastChoiceNum);
		switch (num)
		{
			case 1:
			click.Play();
			joyStick.SetActive(false);
			touchPad.SetActive(true);
			joyStickOL.enabled = false;
			touchPadOL.enabled = true;
			break;

			case 2:
			click.Play();
			touchPad.SetActive(false);
			joyStick.SetActive(true);
			touchPadOL.enabled = false;
			joyStickOL.enabled = true;
			break;
		}
	}
}
