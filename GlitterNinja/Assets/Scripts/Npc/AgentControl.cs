using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentControl : MonoBehaviour
{
    public Transform[] home;
    public NavMeshAgent agent;
    public GameObject[] SpawnPoints;
    public float health = 100;
    private int points;
    public GameObject self;
    private float run;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < home.Length; i++)
        {
            home[i].transform.position = new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f));
            //i++;
        }
        self.transform.position = home[points].position;
        Ragdoll(true);
        Collider(false);
        GoToNextPoint();
        run = Random.Range(-100, 100);
    }
    void Ragdoll(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }
        GetComponent<Rigidbody>().isKinematic = !state;
    }
    void Collider(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }
        GetComponent<Collider>().enabled = !state;
    }
    void GoToNextPoint()
    {
        if (home.Length == 0)
            return;
        agent.SetDestination(home[points].position);
        points = (points + 1) % home.Length;
        
    }
    public void DamageNPC(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        Ragdoll(false);
        Collider(true);
    }
    // Update is called once per frame
    void Update()
    {
        run += Time.deltaTime / 10;
        if (run >= 100)
        {
            run = -100;
        }
        if (run >= 0)
        {
            anim.SetBool("walk", false);
            agent.speed = 7f;
        }
        else
        {
            anim.SetBool("walk", true);
            agent.speed = 3.5f;
        }
        if (health > 0)
        {


            if (!agent.pathPending && agent.remainingDistance < 4f)
            {
                GoToNextPoint();
            }
        }
    }
}
