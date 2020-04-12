using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using UnityEngine;
using Mirror;

public class StartAndStopCallback : NetworkBehaviour
{
    public enum SyncMode { Observers, Owner}
    // Start is called before the first frame update
    [AddComponentMenu("")]
    //[RequireComponent(typeof(NetworkIdentity))]
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
