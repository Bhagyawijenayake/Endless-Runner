using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject barrierPrefab;
    private Vector3 spawnPosition = new Vector3(30,0,0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlaayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(barrierPrefab,spawnPosition,transform.rotation);

        playerControllerScript = GameObject.Find("Player").GetComponent<PlaayerController>();

        InvokeRepeating("spawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnObstacle()
    {
        if(playerControllerScript.gameOver==false)
        {
            Instantiate(barrierPrefab, spawnPosition, transform.rotation);
        }
       
    }
}
