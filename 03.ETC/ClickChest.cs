using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickChest : MonoBehaviour
{
	
    public Animator chest;
	
	// Update is called once per frame
	public void PasswordInput()
	{
		chest.SetBool("chest",true);	
	}

	public void Pass()
	{
		
	}
}
