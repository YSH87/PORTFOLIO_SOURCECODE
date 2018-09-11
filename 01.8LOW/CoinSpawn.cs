using UnityEngine;
using System.Collections;

    public class CoinSpawn : MonoBehaviour
    {
		public GameObject[] spawnPos;
        
		public int random;

        public void Coin(bool a)
        {
                
			if(a == true)
            {
                for (int i = 0; i < 25; i++)
                {
                    random = Random.Range(0,spawnPos.Length);
                    spawnPos[random].SetActive(true);		
                }
            }
            if(a != true)
            {
                for (int i = 0; i < spawnPos.Length; i++)
                {
                    spawnPos[i].SetActive(false);		
                }
            }
            

        }
    }