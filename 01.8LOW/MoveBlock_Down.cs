using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace RonnieJ.ObjectPool
{
    public class MoveBlock_Down : MonoBehaviour
    {
            
            public string poolItemName = "bullet";
            public string bulletName = "bullet";
            float moveSpeed;
            public float lifeTime = 3f;

            public float _elapsedTime = 0f;
            private bool _isInitialized = false;
            public float pos;

            void OnEnable()
            {
                if (!_isInitialized)
                    _isInitialized = true;
            }

            public void Start()
            {
                moveSpeed = Random.Range(18, 25);
            }

            void Update()
            {
                //transform.position += transform.up * moveSpeed * Time.deltaTime;
                transform.Translate(pos * moveSpeed * Time.deltaTime,0,0,Space.World);

                if (GetTimer() > lifeTime)
                {
                    SetTimer();
                    ObjectPool.Instance.PushToPool(poolItemName, gameObject);
                }
            }

            float GetTimer()
            {
                return (_elapsedTime += Time.deltaTime);
            }

            void SetTimer()
            {
                _elapsedTime = 0f;
            }
    }
}
    /*
    private float speed;

    public float pos;
    
    
   
    public void Update()
    {
        transform.Translate(pos * speed * Time.deltaTime,0,0,Space.World);

        if(BlockManager.gameEnd)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
            if(other.transform.tag == "wall")
            {
                Destroy(this.gameObject);
            }
      
    }
     */

