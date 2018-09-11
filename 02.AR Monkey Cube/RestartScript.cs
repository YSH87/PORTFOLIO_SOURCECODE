using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartScript : MonoBehaviour {

	public PauseScript pauseScript;

	public AudioSource menuClick;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartButtonClick()
	{	
		menuClick.Play();
		Time.timeScale = 1;
		pauseScript.isPause = true;
       
		SceneManager.LoadScene(0);
	}
}
