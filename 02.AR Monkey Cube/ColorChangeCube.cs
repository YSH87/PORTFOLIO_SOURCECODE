using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ColorChangeCube : MonoBehaviour,IPointerClickHandler 
{
	MeshRenderer my;
	public int colornum;

	public Animator monkeyup;

	public GameManager countgm;

	public Text colorText;
	public Text BottomcolorText;
	
	public GameObject buttons;
	public GameObject pauseButtons;

	public GameObject monkeyHeadMain;
	public GameObject monkeyHeadSmile;

	public Textscale textscale;

	public MeshRenderer cubebottom;




	AudioSource clickSound;


	// Use this for initialization
	void Start () 
	{
		my = GetComponent<MeshRenderer>();
		clickSound = GetComponent<AudioSource>();
	}
	
	public void OnPointerClick(PointerEventData data)
	{
		colornum++;
		ColorC(colornum);
		clickSound.Play();
		
		if(countgm.CountGame() == true)
		{
			monkeyup.Play("success");
			countgm.monkeyup.SetBool("ok",true);
			textscale.textScale.SetBool("scale", false);
			monkeyHeadMain.SetActive(false);
			monkeyHeadSmile.SetActive(true);
			buttons.SetActive(true);
			pauseButtons.SetActive(false);
			
		}

		 if(colornum == 3)
		{
			colornum = 0;
			ColorC(colornum);
		}
	}

	
	public void ColorC(int colornum)
	{
		switch(colornum)
		{
			case 0:
			colorText.color = new Color32(200,0,0,255);
			colorText.text = "RED";
			BottomcolorText.text = "RED";
			cubebottom.material.SetColor("_Color", new Color32(100,0,0,255));
			my.material.SetColor("_Color", new Color32(100,0,0,255));
			my.material.SetColor("_OutlineColor", new Color32(255,0,0,255));
			break;
			
			case 1: 
			colorText.color = new Color32(0,200,0,255);
			colorText.text = "GREEN";
			BottomcolorText.text = "GREEN";
			cubebottom.material.SetColor("_Color", new Color32(0,100,0,255));
			my.material.SetColor("_Color", new Color32(0,100,0,255));
			my.material.SetColor("_OutlineColor", new Color32(0,255,0,255));
			break;
			
			case 2: 
			colorText.color = new Color32(0,0,200,255);
			colorText.text = "BLUE";
			BottomcolorText.text = "BLUE";
			cubebottom.material.SetColor("_Color", new Color32(0,0,100,255));
			my.material.SetColor("_Color", new Color32(0,0,100,255));
			my.material.SetColor("_OutlineColor", new Color32(0,0,255,255));
			break;

		}
	}
	
}
