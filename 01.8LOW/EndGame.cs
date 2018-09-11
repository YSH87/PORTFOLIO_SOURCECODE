using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	public Text seconds;

	private void OnEnable()
	{
		StartCoroutine(GameRestart());	
	}
	
	IEnumerator GameRestart()
	{
		seconds.text = "3 seconds ...";
		yield return new WaitForSeconds(0.3f);
		seconds.text = "2 seconds ...";
		yield return new WaitForSeconds(0.3f);
		seconds.text = "1 seconds ...";
		yield return new WaitForSeconds(0.3f);
		SceneManager.LoadScene(0);
	}

	
}
