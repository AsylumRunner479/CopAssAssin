using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace MirrorMPlayer
{ 
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private NetworkManagerLobby networkManager = null;

        [Header("UI")]
        [SerializeField] private GameObject landingPagePanel = null;

        public void Start()
        {
            if (networkManager == null)
            {
                Debug.LogError("networkManager not attached to MainMenu");
            }

            if (landingPagePanel == null)
            {
                Debug.LogError("landingPagePanel not attached to MainMenu");
            }
        }

        public void HostLobby()
        {
            networkManager.StartHost();

            landingPagePanel.SetActive(false);
        }

    }
}
