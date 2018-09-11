using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoundData
{
	// 퀴즈 라운드 이름
	public string name;

	// 라운드 시간 제한
	public int timeLimit;
	// 정답 하나당 점수
	public int scorePerAnswer;
	// 질문'들'
	public QuestionData[] Questions;

}
