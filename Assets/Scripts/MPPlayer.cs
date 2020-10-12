using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace MirrorMPlayer
{
    public class MPPlayer : NetworkBehaviour
    {
        [SerializeField] private Vector3 movement = new Vector3();

        [Client]
        // Update is called once per frame
        void Update()
        {
            if (!hasAuthority)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space))
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
}
