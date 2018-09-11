using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBuy : MonoBehaviour
{
	public Gold gold;
	public GameObject powerUp;
	public GameObject powerUpBtn;
	public bool isBuy;
	public MovePlayerJoystick movePlayerJoystick;

	public void Start()
	{
		isBuy = false;	
	}
	
	void Update ()
	{
		if(gold.gold >= 100)
		{
			powerUp.SetActive(true);
			
		}
		if(isBuy)
		{
			powerUp.SetActive(false);
		}
	}

	public void PowerUpClick()
	{
		gold.GoldMinus(100);
		movePlayerJoystick.powerUpCount = 1;
		isBuy = true;
		powerUp.SetActive(false);
		powerUpBtn.SetActive(true);
		
	}
}
