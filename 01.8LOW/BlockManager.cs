using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour
{
	
	public GameManager gameManager;

	public Text centerlineCount;

	public int centerline;
	public int colline;
	public static bool gamestart;
	public static bool gamePlaying;
	public static bool gameEnd;
	
	public GameObject player;
	public GameObject end;
	public GameObject revivaltext;
	public GameObject nextFloorParticle;

	private void Update()
	{
		if(centerline == 4)
		{
			nextFloorParticle.SetActive(true);
		}	
		if(centerline != 4)
		{
			nextFloorParticle.SetActive(false);
		}

		centerlineCount.text =  gameManager.nextFloorCount + "F  " + (centerline + 1) + "/5";
	}

		public void GameRevivalClick(int revivalCount)
	{
		if(revivalCount == 0)
		{
			Time.timeScale = 1f;
            revivaltext.SetActive(false);
            end.SetActive(false);
			player.SetActive(true);
                switch(centerline)
            {
                case 0:
                player.transform.position = new Vector3(0,2f,-2.2f);
                Camera.main.transform.position  = new Vector3(0,2f,2f);
				for (int i = 1; i <= 10; i++)
				{
					gameManager.scoreColliders[i].SetActive(true);
				}
                break;
				
                case 1:
                player.transform.position = new Vector3(0,2f,120f);
                Camera.main.transform.position  = new Vector3(0,2f,120f);
				for (int i = 11; i <= 20; i++)
				{
					gameManager.scoreColliders[i].SetActive(true);
				}
                break;

                case 2:
                player.transform.position = new Vector3(0,2f,240f);
                Camera.main.transform.position  = new Vector3(0,2f,240f);
				for (int i = 21; i <= 29; i++)
				{
					gameManager.scoreColliders[i].SetActive(true);
				}
				
                break;

                case 3:
                player.transform.position = new Vector3(0,2f,360f);
                Camera.main.transform.position  = new Vector3(0,2f,360f);
				for (int i = 31; i <= 39; i++)
				{
					gameManager.scoreColliders[i].SetActive(true);
				}
                break;

                case 4:
                player.transform.position = new Vector3(0,2f,480f);
                Camera.main.transform.position  = new Vector3(0,2f,480f);
				for (int i = 41; i <= 49; i++)
				{
					gameManager.scoreColliders[i].SetActive(true);
				}
                break;
            }
		}
        
	}

	
	
	
}
