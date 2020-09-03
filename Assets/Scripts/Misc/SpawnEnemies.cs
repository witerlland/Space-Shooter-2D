using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject spawnObject;
    // public float spawnTime = 2f;
    // public float minTime = 2f;

    // private void Start() {
    //     // InvokeRepeating("nextObject", Random.Range(2f, 10.0f), Random.Range(2f, 10.0f));
    // }

    // void nextObject(){
    //     GameObject spawnClone = Instantiate(spawnObject, transform.position, transform.rotation);
    // }
    //  public GameObject spawnObject;
 
    public float maxTime = 8;
    public float minTime = 3;

    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;

    void Start(){
        time = minTime;
        SetRandomTime();
    }
    void FixedUpdate(){

        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if(time >= spawnTime){
            SpawnObject();
            SetRandomTime();
        }

    }

    void SpawnObject(){
        time = 0;
        Instantiate (spawnObject, transform.position, spawnObject.transform.rotation);
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime(){
        spawnTime = Random.Range(minTime, maxTime);
    }
}
