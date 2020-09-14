using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCamera;
    private void Start()
    {
        if (fpsCamera == null)
        {
            fpsCamera = GetComponent<Camera>();
        }
        if (fpsCamera == null)
        {
            fpsCamera = Camera.main;
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position,
            fpsCamera.transform.forward,
            out hit,
            range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}