using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static int SpawnCount;
    //public float timer = 0;
    public GameObject agent;
    public static Transform last;
    public AgentControl control;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //timer -= Time.deltaTime * 25;
        if (SpawnCount <= 49)
        {
            
            
            Instantiate(agent);
            
            
            SpawnCount += 1;
            //timer = 1;
        }
    }
}
