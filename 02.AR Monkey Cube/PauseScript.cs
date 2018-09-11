using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{

	public bool isPause = true;
    public GameObject restartButton;
    public AudioSource menuClick;

    public GameManager timeCountSound;
    

     
    public void OnMouseDown ()
    {
        menuClick.Play();

        if(isPause)
        {
            timeCountSound.boxCube.SetActive(true);
            timeCountSound.timeLimit.Stop();
            restartButton.SetActive(true);
            Time.timeScale = 0;
            isPause = false;
        }
        else
        {
            timeCountSound.boxCube.SetActive(false  );
            timeCountSound.timeLimit.Play();
            restartButton.SetActive(false);
            Time.timeScale = 1;
            isPause = true;
        }
        
    }

}
