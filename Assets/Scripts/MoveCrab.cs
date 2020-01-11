using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCrab : MonoBehaviour
{
    private float speed = 1.5f;
    private float waitTime;
    private float startWaitTime = 1f;
    private Vector2 moveSpot;
    private bool flip = false;



    void Start()
    {
        moveSpot = new Vector2 (Random.Range(-6.5f, 8f), Random.Range(-2.43f, -4.5f));
        waitTime = startWaitTime;
        
        
    }

    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position,moveSpot)< 0.2f)
        {
            
            if (waitTime <= 0)
            {
                moveSpot = new Vector2 (Random.Range(-6.5f, 8f), Random.Range(-2.43f, -4.5f));
                waitTime = startWaitTime;
            } else
            {
                waitTime -= Time.deltaTime;
                if (flip) {
                moveSpot = new Vector2 (Random.Range(-6.5f, 8f), Random.Range(-2.43f, -4.5f));   
                Debug.Log("Flip!");
                flip = false;          
                }
            }
        }
    }


        void OnTriggerEnter2D(Collider2D other)
        {        
           if (other.CompareTag("Crab")) {
                flip = true;
            } else {
                flip = false;
            }
        }

    
}

