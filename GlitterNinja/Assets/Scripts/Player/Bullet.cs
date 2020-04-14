using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject self;
    public PlayerHandler player;
    public Collider other;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnColliderEnter(Collider collision)
    {
        PlayerHandler enemy = other.transform.GetComponent<PlayerHandler>();
        
        if (enemy != null)
        {
            enemy.DamagePlayer(damage);
            Destroy(self);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
