using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCrab : MonoBehaviour {
    private float speed = 1.5f;
    private float waitTime;
    private float startWaitTime;
    private float maxPositionY = -4f;
    private float minPositionY = -2.43f;
    private float maxPositionX = 8f;
    private float minPositionX = -6.5f;
    private float currentPositionY;
    public float currentScale;
    public ParticleSystem stepParticle;
    private Vector2 moveSpot;
    private bool flip = false;
    private Animator anim;

    void Start () 
    {
        moveSpot = new Vector2 (Random.Range (minPositionX, maxPositionX), Random.Range (minPositionY, maxPositionY));
        startWaitTime = Random.Range (1f, 3f);
        waitTime = startWaitTime;
        anim = GetComponent<Animator> ();
    }

    void Update () 
    {
        transform.position = Vector2.MoveTowards (transform.position, moveSpot, speed * Time.deltaTime);

        currentPositionY = transform.position.y;

        if (Vector2.Distance (transform.position, moveSpot) < 0.2f) {
            if (waitTime <= 0) {
                moveSpot = new Vector2 (Random.Range (minPositionX, maxPositionX), Random.Range (minPositionY, maxPositionY));
                waitTime = startWaitTime;
                anim.SetBool ("isIdle", false);
                stepParticle.Play ();
            } else {
                waitTime -= Time.deltaTime;
                anim.SetBool ("isIdle", true);
                stepParticle.Stop ();
                if (flip) {
                }
            }
        }
        ChangeScale ();
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Crab")) {
            moveSpot = new Vector2 (Random.Range (minPositionX, maxPositionX), Random.Range (minPositionY, maxPositionY));
            flip = true;
        } else {
            flip = false;
        }
    }

    void ChangeScale () {
        currentScale = 1.5f + ((currentPositionY / 100) * (100 - (100 / (maxPositionY / currentPositionY))));
        transform.localScale = new Vector3 (currentScale, currentScale, currentScale);
    }
}