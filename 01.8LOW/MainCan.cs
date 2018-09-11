using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCan : MonoBehaviour
{
	public AudioSource click;
	public GameObject startCanvas;

	public void StartButtonClick()
	{
		click.Play();
		Time.timeScale = 1;
		startCanvas.SetActive(false);
	}

}
