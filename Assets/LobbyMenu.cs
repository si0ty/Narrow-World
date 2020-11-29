using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LobbyMenu : MonoBehaviour
{
    [SerializeField] private NetworkRoomPlayerLobby networkManager = null;

    [Header("UI")]
    [SerializeField] private GameObject landingPagePanel = null;
   
    public void HostLobby() {
        networkManager.StartHost();
        landingPagePanel.SetActive(false);
    }
}
