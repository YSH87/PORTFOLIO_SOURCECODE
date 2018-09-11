using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour 
{
	 MeshRenderer my;
	 int colornum = 0;
	 public int winCount = 0;
	 

	// Use this for initialization
	void Start () 
	{
		my = GetComponent<MeshRenderer>();
		colornum = Random.Range(0,3);
		ColorC(colornum);
	}
	
	public void ColorC(int a)
	{
		my = GetComponent<MeshRenderer>();
		
		switch(colornum)
		{
			case 0: 
			winCount = 1;
			my.material.SetColor("_Color", new Color32(100,0,0,255));
			my.material.SetColor("_OutlineColor", new Color32(255,0,0,255));
			Debug.Log(winCount);

			break;
			
			case 1:
			winCount = 2; 
			my.material.SetColor("_Color", new Color32(0,100,0,255));
			my.material.SetColor("_OutlineColor", new Color32(0,255,0,255));
			Debug.Log(winCount);
			break;
			
			case 2:
			winCount = 3; 
			my.material.SetColor("_Color", new Color32(0,0,100,255));
			my.material.SetColor("_OutlineColor", new Color32(0,0,255,255));
			Debug.Log(winCount);
			break;
			
		}
	}
}
