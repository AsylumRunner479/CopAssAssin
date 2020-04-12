using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Ownership : NetworkBehaviour
{
    public GameObject Player;
    private bool playerDead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerDead = false;
        if (playerDead && base.hasAuthority && base.isClient)
        {
            CmdRequestRespawn();
        }
    }
    private void CmdRequestRespawn()
    {
        GameObject result = Instantiate(Player);
        NetworkServer.Spawn(result, base.connectionToClient);
    }
    private void RequestOwnershipOnClick()
    {
        if (!base.hasAuthority)
            return;
        if (!Input.GetMouseButtonDown(0))
            return;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            NetworkIdentity id = hit.collider.GetComponent<NetworkIdentity>();
            if (id != null && !id.hasAuthority)
            {
                Debug.Log("Sending request authority for " + hit.collider.gameObject.name);
                CmdRequestAuthority(id);
            }
        }
    }
    private void CmdRequestAuthority(NetworkIdentity otherId)
    {
        Debug.Log("Received request authority for " + otherId.gameObject.name);
        otherId.AssignClientAuthority(base.connectionToClient);
    }

}
