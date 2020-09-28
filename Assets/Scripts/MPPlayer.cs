using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MPPlayer : NetworkBehaviour
{
    [SerializeField] private Vector3 movement = new Vector3();
    
    [Client]
    // Update is called once per frame
    void Update()
    {
        if (!Authority)
        {
            return;
        }

        if (Input.GetKeyDown(Keycode.Space))
        {
            CmdMove();
        }
    }
    [Command]
    private void CmdMove()
    {
        RpcMove();
    }
    [ClientRpc]
    private void RpcMove()
    {
        transform.Translate(movement);
    }
}
