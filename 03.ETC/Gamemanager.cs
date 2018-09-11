using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
	public GameObject startScene;
	public GameObject textBox;

	public InputField startCode;
	public GameObject group1;
	public GameObject group2;
	public GameObject group3;
	public GameObject group4;
	public GameObject group5;
	public GameObject group6;
	

	void Update()
	{
		if(startCode.text == "@11#")
		{
			group1.SetActive(true);
			textBox.SetActive(true);
			startScene.SetActive(false);
		}
		if(startCode.text == "##22")
		{
			group2.SetActive(true);
			textBox.SetActive(true);
			startScene.SetActive(false);
		}
		if(startCode.text == "!!3jo")
		{
			group3.SetActive(true);
			textBox.SetActive(true);
			startScene.SetActive(false);
		}
		if(startCode.text == "4#@!")
		{
			group4.SetActive(true);
			textBox.SetActive(true);
			startScene.SetActive(false);
		}
		if(startCode.text == "5@@!")
		{
			group5.SetActive(true);
			textBox.SetActive(true);
			startScene.SetActive(false);
		}
		if(startCode.text == "6^^!")
		{
			group6.SetActive(true);
			textBox.SetActive(true);
			startScene.SetActive(false);
		}
	}
}

