using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour {

	
	public void PlayerResetClick()
	{
		PlayerPrefs.DeleteKey("count1");
		PlayerPrefs.DeleteKey("count2");
		PlayerPrefs.DeleteKey("count3");
		PlayerPrefs.DeleteKey("count4");
		PlayerPrefs.DeleteKey("count5");
		PlayerPrefs.DeleteKey("count6");
		PlayerPrefs.DeleteKey("count7");
		PlayerPrefs.DeleteKey("count8");
		PlayerPrefs.DeleteKey("count9");

		PlayerPrefs.DeleteKey("count11");
		PlayerPrefs.DeleteKey("count12");
		PlayerPrefs.DeleteKey("count13");
		PlayerPrefs.DeleteKey("count14");
		PlayerPrefs.DeleteKey("count15");
		PlayerPrefs.DeleteKey("count16");
		PlayerPrefs.DeleteKey("count17");
		PlayerPrefs.DeleteKey("count18");
		PlayerPrefs.DeleteKey("count19");

		PlayerPrefs.DeleteKey("Gold");
		PlayerPrefs.DeleteKey("Time");
		PlayerPrefs.DeleteKey("GameCount");
		PlayerPrefs.DeleteKey("BestScore");
		PlayerPrefs.DeleteKey("PowerUp");
		
	
	}
}
