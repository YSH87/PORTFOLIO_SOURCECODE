using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAdd : MonoBehaviour
{
	public ParticleSystem coinAdd;
	public GameObject coinAddPrefabs;
	public Gold glodAdd;
	public AudioSource coinAddSound;

	[HideInInspector]
	public float speed;
	private void Awake()
	{
		coinAdd = Instantiate(coinAddPrefabs).GetComponent<ParticleSystem>();
		coinAdd.transform.position = transform.position;
		coinAdd.gameObject.SetActive(false);
		speed = Random.Range(20,30);
	}

	private void Update()
	{
		transform.Rotate(0,speed*Time.deltaTime,0);	
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Player")
		{
			coinAddSound.Play();
			this.gameObject.SetActive(false);
			coinAdd.gameObject.SetActive(true);
			glodAdd.GoldAdd(1);
			
		}
		
	}
}
