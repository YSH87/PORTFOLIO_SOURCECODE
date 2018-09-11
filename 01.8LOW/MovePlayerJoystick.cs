using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

public class MovePlayerJoystick : MonoBehaviour
{
	
    public AudioSource click;
	public AudioSource powerUpEnd;
	public float speed;
	public Slider slider;
	public GameObject sliderOBJ;
    
	public int count;
	public int revivalCount;
   
    public GameObject end;
	public GameObject end1;
	

	public ParticleSystem dieParticle;
	public GameObject dieParticlePrefabs;
	public AudioSource dieSound;
	public int powerUpCount;

	public Gold gold;
	public GameObject powerUpBuy;
	public GameObject powerUpOBJ;
	public GameObject powerUpBtn;
	public bool isBuy;
    
	private void Awake()
	{
		dieParticle = Instantiate(dieParticlePrefabs).GetComponent<ParticleSystem>();
		dieParticle.gameObject.SetActive(false);
	}
	private void Start()
	{
		isBuy = false;	
		powerUpCount = PlayerPrefs.GetInt("PowerUp");
		Debug.Log(powerUpCount+"+1");
		revivalCount =1;
	}
	private void Update()
	{
		if(gold.gold >= 100)
		{
			powerUpBuy.SetActive(true);
			
		}
		if(isBuy == true)
		{
			powerUpBuy.SetActive(false);
			powerUpBtn.SetActive(false);
		}
		if(powerUpCount == 1)
		{
			powerUpBuy.SetActive(false);
			powerUpBtn.SetActive(true);
		}
		else
		{
			powerUpBtn.SetActive(false);
		}
	}
    void FixedUpdate()
    {
        var v = CrossPlatformInputManager.GetAxis("Vertical");
        var h = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector3 movement = new Vector3(h,0f,v);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        transform.LookAt(transform.position + movement); // (내 위치 + 내가 상대적으로 더 이동할곳)을 바라보기
    }

	
    void OnCollisionEnter(Collision other)
    {
		
        if(other.transform.tag == "block")
        {
			if(revivalCount==1)
			{
				dieSound.Play();
				end.SetActive(true);
				dieParticle.transform.position = transform.position;
				dieParticle.gameObject.SetActive(true);
				dieParticle.Play();
				this.gameObject.SetActive(false);
				Time.timeScale = 0.3f;
				revivalCount = 2;
				return;
			}
			if(revivalCount == 2)
			{
				dieSound.Play();
				end1.SetActive(true);
				dieParticle.transform.position = transform.position;
				dieParticle.gameObject.SetActive(true);
				dieParticle.Play();
				this.gameObject.SetActive(false);
				Time.timeScale = 0.3f;
				revivalCount = 1;
				return;
			}
        }
    }

     private void OnTriggerEnter(Collider other)
	{
		
		

		if(other.transform.tag == "cube")
		{
			count += 1;
			if(count == 1)
			{
				transform.localScale = new Vector3(transform.localScale.x * 0.6f,transform.localScale.y * 0.6f,transform.localScale.z * 0.6f);
				Debug.Log(("enter"));
			}

		}
		 if(other.transform.tag == "block")
        {
			if(revivalCount==1)
			{
				dieSound.Play();
				end.SetActive(true);
				dieParticle.transform.position = transform.position;
				dieParticle.gameObject.SetActive(true);
				dieParticle.Play();
				this.gameObject.SetActive(false);
				Time.timeScale = 0.3f;
				revivalCount = 2;
				return;
			}
			if(revivalCount == 2)
			{
				dieSound.Play();
				end1.SetActive(true);
				dieParticle.transform.position = transform.position;
				dieParticle.gameObject.SetActive(true);
				dieParticle.Play();
				this.gameObject.SetActive(false);
				Time.timeScale = 0.3f;
				revivalCount = 1;
				return;
			}
        }
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.transform.tag == "cube")
		{
			count = 0;
			if(count == 0)
			{
				transform.localScale = new Vector3(transform.localScale.x / 0.6f, transform.localScale.y / 0.6f, transform.localScale.z / 0.6f);
			}
			Debug.Log(("exit"));
		}
	}
	
	public void PowerBuyUpClick()
	{
		click.Play();
		powerUpCount = 1;
		PlayerPrefs.SetInt("PowerUp",powerUpCount);
		gold.GoldMinus(100);
		powerUpBuy.SetActive(false);
		powerUpBtn.SetActive(true);
		
	}
    public void PowerUpClick()
	{
		isBuy = true;
		Debug.Log(powerUpCount);
		sliderOBJ.SetActive(true);
		powerUpBtn.SetActive(false);
		StartCoroutine(PowerUp());
		powerUpCount = 0;
		PlayerPrefs.SetInt("PowerUp",powerUpCount);
		
	}
	public IEnumerator PowerUp()
	{
		powerUpOBJ.SetActive(true);
		for (int i = 0; i < 100; i++)
		{
			slider.value -= 1;
			yield return new WaitForSeconds(0.05f);
		}
		//yield return new WaitForSeconds(5f);
		powerUpEnd.Play();
		sliderOBJ.SetActive(false);	
		powerUpOBJ.SetActive(false);
	}
}