using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textscale : MonoBehaviour
{
	public GameManager gametimesum;
	public Animator textScale;

	public Text text;
	void Update ()
	{
		if(gametimesum.isGamestart==true)
		{
			
			if(gametimesum.gameTimeSum <= 11f)
			{
				textScale.SetBool("scale",true);
				text.color = new Color32(255,0,0,255);
				if(gametimesum.gameTimeSum <= 0.5f)
				{
					Debug.Log("test");
					textScale.SetBool("scale", false);
					text.color = new Color32(0,0,0,255);
					
				}
			}
			
			
		}
	}
}
