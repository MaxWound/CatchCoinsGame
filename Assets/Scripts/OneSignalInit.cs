using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OneSignalSDK;
public class OneSignalInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OneSignal.Default.Initialize("d61097c5-6a2e-48ac-a144-5aac92de87b9");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
