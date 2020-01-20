using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCrabAnim : MonoBehaviour
{
    private float maxPositionY = -4f;
    private float minPositionY = -2.43f;
    private float maxPositionX = 8f;
    private float minPositionX = -6.5f;
    private float currentPositionY;
    public float currentScale;

    void Start()
    {
    }

    void Update()
    {         
        currentPositionY = transform.position.y;
        ChangeScale();
    }
        void ChangeScale()
        {
          currentScale = 1.5f  + ((currentPositionY / 100) * (100 - (100 / (maxPositionY / currentPositionY))));
          transform.localScale = new Vector3(currentScale, currentScale, currentScale);
        }
}

