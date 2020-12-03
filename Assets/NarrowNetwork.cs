using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Mirror;
using System;
using System.Linq;
using System.IO;
using RTS;

public class NarrowNetwork : NetworkManager
{
    
    private PlayerResourceManager resources;

    [SerializeField] private int minPlayers = 2;
    [Scene] [SerializeField] private string menuScene = string.Empty;

    [Header("Room")]
    [SerializeField] private NetworkRoomPlayerLobby roomPlayerPrefab = null;

    [Header("Game")]
    [SerializeField] private Player gamePlayerPrefab = null;

    public static event Action OnClientConnected;
    public static event Action OnClientDisconnected;


    public List<NetworkRoomPlayerLobby> RoomPlayers { get; } = new List<NetworkRoomPlayerLobby>();
    public List<Player> GamePlayers { get; } = new List<Player>();

    public override void OnStartServer() {
        spawnPrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs").ToList();
        Debug.Log("Server started!");

    }

    public override void OnStartClient() {
        var spawnablePrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs");

        foreach (var prefab in spawnablePrefabs) {
            ClientScene.RegisterPrefab(prefab);
        }
    }

    public override void OnStopServer() {
        Debug.Log("Server stopped!");
        RoomPlayers.Clear();
    }

    public override void OnClientConnect(NetworkConnection conn) {
        base.OnClientConnect(conn);
        OnClientConnected?.Invoke();
        Debug.Log("Conntected to server!");
    }

    public override void OnClientDisconnect(NetworkConnection conn) {
        base.OnClientDisconnect(conn);
        OnClientDisconnected?.Invoke();
        Debug.Log("Disconnected from Server!");
    }

    public override void OnServerConnect(NetworkConnection conn) {
        if(numPlayers >= maxConnections) {
            conn.Disconnect();
            return;
        }

        /*
        if(SceneManager.GetActiveScene().name == Path.GetFileNameWithoutExtension(menuScene)) {
            conn.Disconnect();
            return;
        } */
    }

    public override void OnServerAddPlayer(NetworkConnection conn) {
        if(SceneManager.GetActiveScene().name == Path.GetFileNameWithoutExtension(menuScene)) {
            bool isLeader = RoomPlayers.Count == 0;
            NetworkRoomPlayerLobby roomPlayerInstance = Instantiate(roomPlayerPrefab);
            roomPlayerInstance.IsLeader = isLeader;
            NetworkServer.AddPlayerForConnection(conn, roomPlayerInstance.gameObject);
        }
    }

    public override void OnServerDisconnect(NetworkConnection conn) {
        if(conn.identity != null) {
            var player = conn.identity.GetComponent<NetworkRoomPlayerLobby>();
            RoomPlayers.Remove(player);

            NotifyPlayersOfReadyState();
        }
        base.OnServerDisconnect(conn);
    }

    public void NotifyPlayersOfReadyState() {
        foreach(var player in RoomPlayers){
            player.HandleReadyToStart(IsReadyToStart());
        }
    }

    private bool IsReadyToStart() {
        if(numPlayers < minPlayers) { return false; }

        foreach(var player in RoomPlayers) {
            if (!player.IsReady) { return false; }
        }

        return true;
    }

    private IEnumerator Delay() {
        yield return new WaitForSeconds(0.6f);

        gamePlayerPrefab.InitializePlayer();
    }

    public void StartGame() {
       
            if(!IsReadyToStart()) {
                return;
            }
            resources =  GameObject.Find("Player").GetComponent<PlayerResourceManager>();
            
            resources.SaveResources();
            ServerChangeScene("War of Ages");
            StartCoroutine(Delay());

            Debug.Log("Game should start");
     
    }

    public override void ServerChangeScene(string newSceneName) {
        if (SceneManager.GetActiveScene().name == menuScene && newSceneName.StartsWith("War of Ages")) {
            for (int i = RoomPlayers.Count - 1; i >= 0; i--) {
                var conn = RoomPlayers[i].connectionToClient;
                var gameplayerInstance = Instantiate(gamePlayerPrefab);
                gameplayerInstance.SetDisplayName(RoomPlayers[i].DisplayName);

                NetworkServer.Destroy(conn.identity.gameObject);

                NetworkServer.ReplacePlayerForConnection(conn, gameplayerInstance.gameObject);

            }
        }
        base.ServerChangeScene(newSceneName);

    }

}
