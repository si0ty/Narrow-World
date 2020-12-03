using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LobbyMenu : MonoBehaviour
{
    [SerializeField] private NarrowNetwork networkManager = null;

    private void Start() {
        networkManager = GameObject.Find("NetworkManager").GetComponent<NarrowNetwork>();
    }


   
    public void HostLobby() {
        networkManager.StartHost();
     
    }

    public void ClientReady() {
        if (NetworkClient.isConnected && !ClientScene.ready) {
           
                ClientScene.Ready(NetworkClient.connection);

                if (ClientScene.localPlayer == null) {
                    ClientScene.AddPlayer(NetworkClient.connection);
                }
            
        }
    }
}
