using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
	public GameObject ob1;
	public GameObject ob2;

	public void NextClick()
	{
		ob2.SetActive(true);
		ob1.SetActive(false);
	}
	
}
