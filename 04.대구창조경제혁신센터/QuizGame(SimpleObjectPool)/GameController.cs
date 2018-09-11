using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
 {
	 public GameObject gameOverFrame;

	// #싱글턴, 단하나만 존재하도록 만들어준다.
	public static GameController instance;
	
	// #싱글턴, start 보다 몇프레임 빠르다. 단순히 스타트와 꼬이지 않도록 써준다.
	void Awake()
	{
		instance = this;
	} 

	public Transform buttonHolder;

	public List<GameObject> buttons = new List<GameObject>();

	 // 보튼을 풀장애서 가져오기 위한 오브젝트
	 public SimpleObjectPool buttonPool;
	// 질문 텍스트
	public Text questionText;

	// 점수 테스트
	public Text scoreText;

	// 시간제한 텍스트
	public Text timeText;

	// 남은 시간 기록
	private float timeRemain;

	// 게임 종료
	private bool isGameOver = false;

	// #싱글턴, 으로 변경해서 필요없음
	// public DataController dataController;
	
	private RoundData currentRoundData;

	private QuestionData[] questions;

	private int questionIndex = 0;

	private int score = 0;

	void Start ()
	{
		// Find 오브젝트는 데이터를 많이 먹는다. 한번만 써주는 것이 좋다.
		// 싱글톤, 변경후 불필요
		// dataController = FindObjectOfType<DataController>();
		// 현재 라운드 데이터를 가져온다. 이름과 시간제한을 가져온다.
		// currentRoundData = dataController.GetCurrentRoundData();

		// 싱글톤,으로 변경하면 간단하다.
		currentRoundData = DataController.instance.GetCurrentRoundData();
		
		questions = currentRoundData.Questions;

		// 시간제한 가져오기
		timeRemain = currentRoundData.timeLimit;

		isGameOver = false;

		ShowQuestion();
	}
	
	void Update()
	{
		if(!isGameOver)
		{
			timeRemain = timeRemain - Time.deltaTime;

			UpdateTimeText();

			if(timeRemain <= 0)
			{
				EndRound();
			}
		}
	}

	void EndRound()
	{
		isGameOver = true;
		gameOverFrame.SetActive(true);
	}

	void UpdateTimeText()
	{
		// (int)처리를 해줌으로 강제로 시간이 소숫점으로 나오는 것을 없애준다.
		timeText.text = "TIME: " + (int)timeRemain;
	}

	// 질문을 시작하기 전에 이전 답변버튼들을 지워준다.
	private void ClearAnswerButtons()
	{
		while(buttons.Count > 0)
		{
			GameObject returnButton = buttons[0];
			buttons.RemoveAt(0);
			buttonPool.ReturnObject(returnButton);
		}
	}

	private void ShowQuestion()
	{
		// 질문을 시작하기 전에 이전 답변버튼들을 지워준다.
		ClearAnswerButtons();

		// 질문 배열의 현재 인덱스를 가져온다.
		QuestionData questionData = questions[questionIndex];	

		// 질문 ui = 질문 데이터의 질문
		questionText.text = questionData.questionText;

		// 답변들을 가지고 온다.
		AnswerData[] answers = questionData.answers;

		// 배열의 순번대로 넘겨준다.
		for (int i = 0; i < answers.Length; i++)
		{
			// 버튼을 풀장에서 하나 가지고 온다.
			GameObject answerButton = buttonPool.GetObject();

			// 가져온 게임오브젝트의 버튼을 찾는다. 
			answerButton.GetComponent<AnswerButton>().SetUp(answers[i]); 

			buttons.Add(answerButton); // 리스트에 버튼 추가해줘서 나중에 사용하도록 만들어 준다.

			answerButton.transform.SetParent(buttonHolder); // 엔서버튼이 생성될 틀의 위치를 지정. 부모를 지정해 준다.

			// 버그수정코드, 유니티가 가져올때 유아이 크기를 잘 못 출력하는 버그가 있어서. 다시 크기를 조절하는 코드이다.
			answerButton.transform.localScale = new Vector3(1,1,1);
		}

	}

	// answer을 발동시키는 함수
	public void OnAnswerClicked(bool isCorrect)
	{
		if(isCorrect)
		{
			score = score + currentRoundData.scorePerAnswer;

			scoreText.text = "Score: " + score;
		}
		questionIndex++;

		// 총 질문의 갯수를 넘어가면 게임 종료
		if(questions.Length <= questionIndex)
		{
			EndRound();
		}
		else
		{
			ShowQuestion();
		}
	}

}
