using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pass : MonoBehaviour {
	public InputField m1Answer;
	public Animator chest1;
	public GameObject oCanvas;
	public GameObject xCanvas;
	public GameObject hintImageGameobject;
	public Text m1Text;
	public Text o1TextInput;
	public Image hintImageSprite;
	public Image buttomImageSprite;
	public GameObject buttomImagetext;
	
	public string answer;
	public string o1Text;
	
	// Use this for initialization
	
	// Update is called once per frame
	public void Start()
	{
		chest1.SetBool("chest",false);
	}
	void Update ()
		{
			if(m1Answer.text == answer)
			{
				chest1.SetBool("chest",true);
				oCanvas.SetActive(true);
				m1Text.text = o1Text;
				o1TextInput.text =o1Text;
				if(o1Text=="사진")
				{
					buttomImageSprite.sprite = hintImageSprite.sprite;
					hintImageGameobject.SetActive(true);
					buttomImagetext.SetActive(false);
				}

			}
			if(m1Answer.text == "pass")
			{
				xCanvas.SetActive(true);
				m1Text.text="X";
			}
		}
}
