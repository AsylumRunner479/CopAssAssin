using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


namespace MirrorMPlayer
{
    public class NetworkGamePlayerLobby : NetworkBehaviour
    {
        [SyncVar] private string displayName = "Loading....";
        private NetworkManagerLobby _room;
        private NetworkManagerLobby room
        {
            get
            {
                if (_room != null) return _room;
                return _room = NetworkManager.singleton as NetworkManagerLobby;

            }
        }
        public override void OnStartClient()
        {
            DontDestroyOnLoad(gameObject);
            //room.GamePlayers.Add(this);
        }
        public override void OnStopClient()
        {
            //room.GamePlayers.Remove(this);
        }
        [Server] public void SetDisplayName(string displayName)
        {
            this.displayName = displayName;
        }
    }
}
