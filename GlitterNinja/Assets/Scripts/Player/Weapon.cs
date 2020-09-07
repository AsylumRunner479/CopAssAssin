using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weapon : MonoBehaviour
{
    public int teamID;
    public bool isWeaponLocked = false;
    public bool isWeaponDropable = false;
    
    public GameObject worldWeaponsGameObject;
    public Vector3 originalLocation;
    public Renderer rend;
    public void SetUp(int teamID, GameObject worldGameObject, Vector3 originalLocation)
    {
        this.teamID = teamID;
        if (worldGameObject != null)
        {
            worldWeaponsGameObject = worldGameObject;
        }
        this.originalLocation = originalLocation;

    }
    public void DropWeapon(Rigidbody player, Vector3 dropLocation)
    {
        Vector3 directionToDrop = dropLocation - Camera.main.transform.position;
        

        Ray rayToDropLocation = new Ray(Camera.main.transform.position, directionToDrop);
        RaycastHit hit;
        if (Physics.Raycast(rayToDropLocation, out hit, directionToDrop.magnitude ))
        {
            dropLocation = hit.point;
        }
        worldWeaponsGameObject.transform.position = dropLocation;

        Renderer rend = worldWeaponsGameObject.GetComponent<Renderer>();
        if (rend != null)
        {
            Debug.Log("Dropping using render: " + rend.name);

            Vector3 topPoint = rend.bounds.center;
            topPoint.y += rend.bounds.extents.y;

            float height = rend.bounds.extents.y * 2;

            Ray rayDown = new Ray(topPoint, Vector3.down);
            RaycastHit downRayHit;
            if (Physics.Raycast(rayDown, out downRayHit, height * 1.1f))
            {
                dropLocation = downRayHit.point;
                dropLocation.y += rend.bounds.extents.y * 1.1f;
            }
            worldWeaponsGameObject.transform.position = dropLocation;
        }
        else
        {
            Debug.LogError("Renderer not found");
        }
        Rigidbody weaponRigidBody = worldWeaponsGameObject.GetComponent<Rigidbody>();
        if (weaponRigidBody != null && player != null)
        {
            weaponRigidBody.velocity = player.velocity;
        }
    }
}
