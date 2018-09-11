using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangebody : MonoBehaviour 
{
	 MeshRenderer my;
	 
	 public ColorChange cc;
	 int colornum = 0;

	// Use this for initialization
	void Start () 
	{
		my = GetComponent<MeshRenderer>();
		colornum = Random.Range(0,4);
		cc.ColorC(colornum);
	}

	public void OnMouseClick()
	{
		colornum += 1;
		cc.ColorC(colornum);
		if(colornum == 4)
		{
			colornum = 0;
			cc.ColorC(colornum);
		}
	}
	public void ColorC(int a)
	{
		switch(colornum)
		{
			case 0: 
			my.material.SetColor("_Color", new Color32(100,0,0,255));
			my.material.SetColor("_OutlineColor", new Color32(255,0,0,255));
			break;
			
			case 1: 
			my.material.SetColor("_Color", new Color32(0,100,0,255));
			my.material.SetColor("_OutlineColor", new Color32(0,255,0,255));
			break;
			
			case 2: 
			my.material.SetColor("_Color", new Color32(0,0,100,255));
			my.material.SetColor("_OutlineColor", new Color32(0,0,255,255));
			break;
			
			case 3: 
			my.material.SetColor("_Color", new Color32(120,120,0,255));
			my.material.SetColor("_OutlineColor", new Color32(255,255,0,255));
			break;
		}
	}
}
