using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentControl : MonoBehaviour
{
    public Transform home, goal, follow;
    public NavMeshAgent agent;
    public GameObject[] SpawnPoints;
    private int random;
    public GameObject self;
    
    // Start is called before the first frame update
    void Start()
    {
        home.transform.position = new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f));
        SpawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
        random = Random.Range(0, SpawnPoints.Length);
        
        agent.transform.position = SpawnPoints[random].transform.position;
        if (follow != null)
        {
            agent.SetDestination(follow.transform.position);
        }
        else
        {
            agent.SetDestination(home.position);
            follow = SpawnManager.last;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.transform.position != follow.transform.position)
        {
            agent.SetDestination(home.position);
            random = Random.Range(0, SpawnPoints.Length);
            goal.transform.position = SpawnPoints[random].transform.position;
        }
        if (agent.transform.position == home.position)
        {
            SpawnManager.SpawnCount -= 1;
            Destroy(self);
            
        }
    }
}
