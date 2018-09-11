using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour 
{
	public Text buttonText;
	private AnswerData answerData;

	// 자기가 담당하는 답변의 내용으로 채워준다.
	public void SetUp(AnswerData newData)
	{
		answerData = newData;
		buttonText.text = answerData.answerText;
	}
	public void OnClick()
	{
		//게임컨트롤러에게 자기 자신이 클릭 당했음을 알린다.
		// 자기 담당 답변정보가 정답인지 아닌지도 같이 알려줌
		
		// #싱글턴, 변경전
		// 씬상에 게임컨트롤러를 찾는다.
		// GameController gameController = FindObjectOfType<GameController>()
		// 컨트롤러안에 엔서온클릭의 데이터가 정답인지 가져온다.
		// gameController.OnAnswerClicked(answerData.isCorrect);

		// #싱글턴, 으로 변경해서 바로 사용 가능
		// 이제 찾을 필요 없이 바로 사용 가능하다.
		GameController.instance.OnAnswerClicked(answerData.isCorrect);
	}

}
