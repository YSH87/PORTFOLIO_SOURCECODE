using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
	public AudioSource click;
	public GameObject startCanvas;

	public void Click()
	{
		click.Play();
		Time.timeScale = 0;
		startCanvas.SetActive(true);
	}
}
