using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureZone : MonoBehaviour
{
    [SerializeField] int teamID;

    CTF ctf;
    private void Start()
    {
        ctf = FindObjectOfType<CTF>();
        if (ctf == null)
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null && ctf != null)
        {
            if (player.GetWeaponTeamID() != teamID)
            {
                return;
            }
            if (player.IsHolding(1))
            {
                ctf.AddScore(player.TeamID, 1);
                player.ReturnWeapon(1);
            }
        }
    }
}
