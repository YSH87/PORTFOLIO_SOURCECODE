using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour 
{
	public MeshRenderer[] cubel;
	public MeshRenderer[] cuber;

	public Text timeText;
	public Text BottomText;
	
	public GameObject buttons;
	public GameObject pauseButtons;

	public GameObject monkeyHeadMain;
	public GameObject monkeyHeadSad;
	public GameObject monkeyHeadSmile;

	
	public Animator monkeyup;
	public float gameTime1 = 121f;
	public float gameTime2 = 61f;
	public float gameTime3 = 31f;
	public float gameTimeSum;
	public bool isGamestart = true;

	public GameObject bigCubel;
	public GameObject bigCubeR;
	public ColorChangeCube[] colorC;

	public AudioSource backGroundMusic;
	public AudioSource levelMusic;
	public AudioSource timeLimit;
	public AudioSource levelDone;
	public AudioSource levelFail;
	public AudioSource menuClick;

	public GameObject mainmap;

	public GameObject gameovermap;
	public GameObject successmap;

	public GameObject boxCube;

	public GameObject colorText;

	public MeshRenderer cubebottom;

	public int colornum = 0;


	void Start()
	{
		isGamestart = false;
		mainmap.SetActive(true);
		gameovermap.SetActive(false);
		successmap.SetActive(false);
		backGroundMusic.Play();
		boxCube.SetActive(true);
		colorText.SetActive(false);
		BottomText.text = "MONKEY";
	}

	public void GameStartButton(float levelTime)
	{
		menuClick.Play();
		monkeyup.SetBool("ok",false);
		monkeyup.Play("monkeydown");

		for(int i = 0; i < cubel.Length; ++i)
		{
			colornum = Random.Range(0,3);
			switch(colornum)
			{
				case 0: 
				cubel[i].material.SetColor("_Color", new Color32(100,0,0,255));
				break;
			
				case 1:
				cubel[i].material.SetColor("_Color", new Color32(0,100,0,255));
				break;
			
				case 2:
				cubel[i].material.SetColor("_Color", new Color32(0,0,100,255));
				break;
			}
		}
		
		for(int i = 0; i < cuber.Length; ++i)
		{
			cuber[i].material.SetColor("_Color", new Color32(0,0,0,255));
			colorC[i].colornum = 0;
		}

		mainmap.SetActive(true);
		gameovermap.SetActive(false);
		successmap.SetActive(false);
		timeText.color = new Color32(0,23,135,255);
		boxCube.SetActive(false);
		buttons.SetActive(false);
		pauseButtons.SetActive(true);
		colorText.SetActive(true);
		isGamestart = true;
		gameTimeSum = levelTime;
		bigCubel.transform.rotation = new Quaternion(0,0,0,0);
		bigCubeR.transform.rotation = new Quaternion(0,0,0,0);
		monkeyHeadMain.SetActive(true);
		monkeyHeadSad.SetActive(false);
		monkeyHeadSmile.SetActive(false);
		backGroundMusic.Stop();
		levelMusic.Play();
		timeLimit.Play();

		
	}
	public void GameStartButton1()
	{
		GameStartButton(gameTime1);
	}
	public void GameStartButton2()
	{
		GameStartButton(gameTime2);
	}
	public void GameStartButton3()
	{
		GameStartButton(gameTime3);
	}
	public void LimitTime()
	{	
		timeText.text = "TIME : " + (int)gameTimeSum;
	}
	void Update ()
	{
		if(isGamestart == true)
		{
			if(Time.time > 1)
			{
				gameTimeSum -= Time.deltaTime;
				LimitTime();
				if(gameTimeSum < 0f)
				{
				Debug.Log("end");
				timeText.color = new Color32(255,0,0,255);
				timeText.text = "GAMEOVER";
				BottomText.text = "MONKEY";
				colorText.SetActive(false);
				cubebottom.material.SetColor("_Color", new Color32(255,255,255,255));
				timeLimit.Stop();
				levelFail.Play();
				levelMusic.Stop();
				boxCube.SetActive(true);
				mainmap.SetActive(false);
				gameovermap.SetActive(true);
				monkeyup.Play("gameover");
				monkeyHeadMain.SetActive(false);
				monkeyHeadSad.SetActive(true);
				buttons.SetActive(true);
				pauseButtons.SetActive(false);
				gameTimeSum = 0f;
				isGamestart = false;
				}
			}
		}
	}

	
	public bool CountGame()
	{
		for(int i = 0; i < 16; ++i)
		{
			if(cubel[i].material.color != cuber[i].material.color)
			{
				Debug.Log(false);
				return false;
			}
		}
		Debug.Log(true);
		cubebottom.material.SetColor("_Color", new Color32(255,255,255,255));
		timeText.color = new Color32(255,0,0,255);
		timeText.text = "SUCCESS";
		BottomText.text = "MONKEY";
		colorText.SetActive(false);
		timeLimit.Stop();
		levelDone.Play();
		levelMusic.Stop();
		boxCube.SetActive(true);
		mainmap.SetActive(false);
		successmap.SetActive(true);
		isGamestart = false;
		
		return true;
	}

	
}
