using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float damage, range, attackSpeed, attackRate;
    public Camera cam;
    public LayerMask enemy;
    public ParticleSystem bullets;
    
    // Update is called once per frame
    void Update()
    {
        attackSpeed += Time.deltaTime;
        if (Input.GetMouseButton(0) && attackSpeed > 0)
        {
            attackSpeed = -3f/attackRate;
            Shoot();
            bullets.Emit(1);
            
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        PlayerHandler enemy = other.transform.GetComponent<PlayerHandler>();
        Material skin = other.transform.GetComponent<Material>();
        if (enemy != null)
        {
            enemy.DamagePlayer(damage);
            skin.SetFloat("Damaged", enemy.curHealth);
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            PlayerHandler enemy = hit.transform.GetComponent<PlayerHandler>();
            Material skin = hit.transform.GetComponent<Material>();
            if (enemy != null)
            {
                enemy.DamagePlayer(damage);
                skin.SetFloat("Damaged", enemy.curHealth);
            }
        }
    }
}
