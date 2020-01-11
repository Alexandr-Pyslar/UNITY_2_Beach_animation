using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour

{
    private float randomSpeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        randomSpeed = Random.Range(0.3f, 0.8f);
    }

    void Update() {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.velocity = new Vector3(1, 0, 0) * randomSpeed;
        
        if (transform.position.x > 15) Destroy(gameObject);
    }
}
