using UnityEngine;

[System.Serializable]
public class QuestionData
{
	// 질문 문장
	public string questionText;
	// 질문에 대한 답변'들'
	public AnswerData[] answers;
}
