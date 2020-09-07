using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float damage, range, attackSpeed, attackRate, totalAmmo, curAmmo;
    public Camera cam;
    public LayerMask enemy;
    public ParticleSystem bullets;
    public PlayerMovement player;
    
    // Update is called once per frame
    void Update()
    {
        player.totalAmmo = totalAmmo;
        player.ammoCount = curAmmo;
        attackSpeed += Time.deltaTime;
        curAmmo += Time.deltaTime * Time.deltaTime;
        if (Input.GetMouseButton(0) && attackSpeed > 0 && curAmmo >= 1)
        {
            curAmmo -= 1;
            
            attackSpeed = -3f/attackRate;
            Shoot();
            bullets.Emit(1);
            
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        AgentControl enemy = other.transform.GetComponent<AgentControl>();
       
        if (enemy != null)
        {
            enemy.DamageNPC(damage);
            
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, float.MaxValue, enemy))
        {
            AgentControl enemy = hit.transform.GetComponent<AgentControl>();

            if (enemy != null)
            {
                Debug.Log("Dying", hit.transform);
                enemy.DamageNPC(damage);

            }
        }
    }
}
