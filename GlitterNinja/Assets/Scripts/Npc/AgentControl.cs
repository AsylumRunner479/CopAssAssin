using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentControl : MonoBehaviour
{
    public Transform[] home;
    public NavMeshAgent agent;
    public GameObject[] SpawnPoints;
    
    private int points;
    public GameObject self;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < home.Length; i++)
        {
            home[i].transform.position = new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f));
            //i++;
        }
        self.transform.position = home[points].position;
        
        GoToNextPoint();
        
    }
    void GoToNextPoint()
    {
        if (home.Length == 0)
            return;
        agent.SetDestination(home[points].position);
        points = (points + 1) % home.Length;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 4f)
        {
            GoToNextPoint();
        }
    }
}
