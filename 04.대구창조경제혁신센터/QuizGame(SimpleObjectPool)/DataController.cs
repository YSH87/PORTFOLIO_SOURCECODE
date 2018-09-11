using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour 
{
	public static DataController instance;

	void Awake()
	{
		instance = this;
	}
	// 퀴즈 라운드'들'
	public RoundData[] rounds;

	void Start()
	{
		// 씬을 전환해도 파괴되지 않도록 한다.
		DontDestroyOnLoad(gameObject);
		SceneManager.LoadScene("MainMenu");
	}

	// 외부에서 요청하면 현재 순번의 라운드를 가져다줌
	// 당장은 첫번째 라운드만 반복 사용
	public RoundData GetCurrentRoundData()
	{
		return rounds[0];
	}

}
