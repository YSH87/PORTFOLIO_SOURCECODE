﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Out : MonoBehaviour
{
	public GameObject end;
private void OnCollisionEnter(Collision other)
{
	end.SetActive(true);
}
}
