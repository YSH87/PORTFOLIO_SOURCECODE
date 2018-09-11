using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public AudioSource click; 
	public static GameManager instance;
	public CoinSpawn coinSpawn;
	public GameObject[] scoreColliders;

	public Material block;
	public Material floor;
	public GameObject startCol;
	public CenterLine[] centerLine;

	public Text scoreText_Best;
	public Text scoreText_Best2;
	public Text scoreText_Playing;
	public Text floorText;
	

	private int score = 0;
	private int floorScore = 1;


	public bool nextFloor;
	public int nextFloorCount = 1;
	
    public Transform player;
	public GameObject[] players;
	public GameObject[] player_Sphere;
	public Sprite[] player_SphereSprites;
	public Image player_SphereSprite;
	public Sprite[] player_CubeSprites;
	public Image player_CubeSprite;
	public GameObject[] player_Cube;
	
	public int lastChoiceNum;
	public int player_SphereNum;
	public int player_CubeNum;
	public int randomColor;

    
	


    public void PlayerSelec(int a)
	{
		lastChoiceNum = a;
		PlayerPrefs.SetInt("Playerlastnum", lastChoiceNum);
		for (int i = 0; i < players.Length; i++)
		{
			players[i].SetActive(false);
		}
			click.Play();
			players[a].SetActive(true);

	}

	public void SphereSel(int b)
	{
		player_SphereNum = b;
		PlayerPrefs.SetInt("Player_SphereNum", player_SphereNum);
		for (int i = 0; i < player_Sphere.Length; i++)
		{
			player_Sphere[i].SetActive(false);
		}
			click.Play();
			player_Sphere[b].SetActive(true);
			player_SphereSprite.sprite = player_SphereSprites[b];
	}


	public void SphereCube(int d)
	{
		player_CubeNum = d;
		PlayerPrefs.SetInt("Player_CubeNum", player_CubeNum);
		for (int i = 0; i < player_Cube.Length; i++)
		{
			player_Cube[i].SetActive(false);
		}
			click.Play();
			player_Cube[d].SetActive(true);
			player_CubeSprite.sprite = player_CubeSprites[d];
	}


	// Use this for initialization
	public void Awake()
	{
		instance = this;
		UpdateUI();
		//PlayerPrefs.DeleteKey("BestScore"); // 초기화 나중에 풀어주어야 함.
	}
	void Start ()
	{
		Time.timeScale = 1;
		nextFloor = false;
		lastChoiceNum = PlayerPrefs.GetInt("Playerlastnum");
		player_SphereNum = PlayerPrefs.GetInt("Player_SphereNum");
		player_CubeNum = PlayerPrefs.GetInt("Player_CubeNum");
		randomColor = Random.Range(1,11);
		ColorChange(randomColor);
		ColorChangeFloor(randomColor);
	    PlayerSelec(lastChoiceNum);
		SphereSel(player_SphereNum);
		SphereCube(player_CubeNum);
	}
	

	public void ColorChangeFloor(int a)
	{
		switch (a)
		{
			case 1:
			floor.SetColor("_Color", new Color32(11,1,1, 255));
			break;
			case 2:
			floor.SetColor("_Color", new Color32(10,1,11, 255));
			break;
			case 3:
			floor.SetColor("_Color", new Color32(1,5,11, 255));
			break;
			case 4:
			floor.SetColor("_Color", new Color32(1,10,11, 255));
			break;
			case 5:
			floor.SetColor("_Color", new Color32(1,10,6, 255));
			break;
			case 6:
			floor.SetColor("_Color", new Color32(1,11,1, 255));
			break;
			case 7:
			floor.SetColor("_Color", new Color32(1,7,11, 255));
			break;
			case 8:
			floor.SetColor("_Color", new Color32(11,11,1, 255));
			break;
			case 9:
			floor.SetColor("_Color", new Color32(19,19,19, 255));
			break;
			case 10:
			floor.SetColor("_Color", new Color32(0,1,21, 255));
			break;

		}
		
		
	}
	
	public void ColorChange(int a)
	{
		switch (a)
		{
			case 1:
			block.SetColor("_Color", new Color32(100,100,100, 255));
			break;
			case 2:
			block.SetColor("_Color", new Color32(50,200,10, 255));
			break;
			case 3:
			block.SetColor("_Color", new Color32(25,210,200, 255));
			break;
			case 4:
			block.SetColor("_Color", new Color32(233,29,67, 255));
			break;
			case 5:
			block.SetColor("_Color", new Color32(100,25,230, 255));
			break;
			case 6:
			block.SetColor("_Color", new Color32(150,160,35, 255));
			break;
			case 7:
			block.SetColor("_Color", new Color32(215,100,0, 255));
			break;
			case 8:
			block.SetColor("_Color", new Color32(0,20,180, 255));
			break;
			case 9:
			block.SetColor("_Color", new Color32(170,170,185, 255));
			break;
			case 10:
			block.SetColor("_Color", new Color32(255,0,215, 255));
			break;

		}
	}
	
	public void AddScore(int newScore)
	{
		score += newScore;
		UpdateBestScore();
		UpdateUI();
	}

	public void AddFloorScore(int newFloorScore)
	{
		floorScore += newFloorScore;
		UpdateUI();
	}

	void UpdateBestScore()
	{
		if(GetBestScore() < score)
		{
			PlayerPrefs.SetInt("BestScore",score);
		}
		
	}

	int GetBestScore()
	{
		int bestScore = PlayerPrefs.GetInt("BestScore");
		PlayerPrefs.Save();
		return bestScore;
		UpdateUI();
		
	}

	void UpdateUI()
	{
		scoreText_Playing.text = "" + score;
		scoreText_Best.text = "" + GetBestScore();
		scoreText_Best2.text = "" + GetBestScore();
		floorText.text = floorScore + "F";

	}

	void Reset()
	{
		score = 0;
		UpdateUI();
	}

	public void BestScoreReset()
	{
		PlayerPrefs.DeleteKey("BestScore");
	}

	// Update is called once per frame

	 private void OnTriggerEnter(Collider other)
    {
        //SceneManager.LoadScene(0);
		coinSpawn.Coin(false);
		AddFloorScore(1);
		
		nextFloor = true;
		nextFloorCount += 1;
		Debug.Log(nextFloorCount);

		for (int i = 0; i < centerLine.Length; i++)
		{
			centerLine[i].NextFloor();
		}

		startCol.SetActive(true);
		player.transform.position = new Vector3(0,0.1f,-2.2f);
		Camera.main.transform.position = player.transform.position;
		for (int i = 0; i < scoreColliders.Length; i++)
		{
			scoreColliders[i].SetActive(true);
		}
    }
  
  
}
