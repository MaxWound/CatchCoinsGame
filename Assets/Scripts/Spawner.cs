using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
   private Transform LeftBorder;
    [SerializeField]
    private Transform RightBorder;

    [SerializeField]
    private GameObject ObjectToSpawn;

    [SerializeField]
    private float minDelay;
    [SerializeField]
    private float maxDelay;
    
    private float DelayTime;

    private float timerTime;

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        timerTime += Time.fixedDeltaTime;
        if(timerTime >= DelayTime)
        {

            ResetTime();
            Pool.instance.SpawnFromPool(transform,RandomPosition());
            //Instantiate(ObjectToSpawn,RandomPosition(),transform.rotation);
        }
    }
    private Vector3 RandomPosition()
    {
        Vector3 pos = new Vector3(Random.Range(LeftBorder.position.x, RightBorder.position.x), transform.position.y, transform.position.z);
        return pos;
    }
    private void ResetTime()
    {
        timerTime = 0;
        DelayTime = Random.Range(minDelay, maxDelay);
    }

}
