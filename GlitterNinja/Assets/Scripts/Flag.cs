using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] int teamID;
    public Vector3 originalLocation;
    const int weaponID = 1;
    private void Start()
    {
        originalLocation = transform.position;

    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            if (player.TeamID == teamID)
            {
                return;
            }
            Debug.Log("Capture Flag");
            player.PickUpWeapon(gameObject, originalLocation, teamID, weaponID);
            gameObject.SetActive(false);

        }
    }
}
