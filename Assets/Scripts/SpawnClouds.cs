using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    public GameObject cloudPrefab;
    private float randomRangeY;
    private float randomCloudSize;
    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("SpawnCloud", 0.5f, 13f);      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCloud()
    {
        randomRangeY = Random.Range(2, 5);
        randomCloudSize = Random.Range(0.5f, 1.1f);
        GameObject newObject = Instantiate (cloudPrefab, new Vector3(-12, randomRangeY, 0), Quaternion.identity) as GameObject;
        newObject.transform.localScale = new Vector3(randomCloudSize, randomCloudSize, 1);
    }
}
