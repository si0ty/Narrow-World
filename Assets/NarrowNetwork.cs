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
    [SerializeField] private IngamePlayer gamePlayerPrefab;

    public static event Action OnClientConnected;
    public static event Action OnClientDisconnected;

    private Player player;


    public List<NetworkRoomPlayerLobby> RoomPlayers { get; } = new List<NetworkRoomPlayerLobby>();
    public List<IngamePlayer> GamePlayers { get; } = new List<IngamePlayer>();

 

    public override void OnStartServer() {
      spawnPrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs").ToList();
        Debug.Log("Server started!");

    }

    public override void OnStartClient() {
     var spawnablePrefabs = Resources.LoadAll<GameObject>("SpawnablePrefabs").ToList();

        foreach (var prefab in spawnablePrefabs) {
            ClientScene.RegisterPrefab(prefab);
        } 
     
              }

    public override void OnStopServer() {
        Debug.Log("Server stopped!");
        RoomPlayers.Clear();
        GamePlayers.Clear();
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
        player = GameObject.Find("Player").GetComponent<Player>();
        if(RoomPlayers[0].demon && player.demon) {
            GameObject.Find("PopUpSystem").GetComponent<PopUpSystem>().SimplePopUp("There already is a demon in this lobby", 90f);
            conn.Disconnect();
            return;
        }

        if (!RoomPlayers[0].demon && !player.demon) {
            conn.Disconnect();
            GameObject.Find("PopUpSystem").GetComponent<PopUpSystem>().SimplePopUp("There already is a knight in this lobby", 90f);

            return;
        }

        if (numPlayers >= maxConnections) {
            conn.Disconnect();
            return;
        }

        
        if(SceneManager.GetActiveScene().path == Path.GetFileNameWithoutExtension(menuScene)) {
            conn.Disconnect();
            return;
        } 
    }

    public override void OnServerAddPlayer(NetworkConnection conn) {
        
            bool isLeader = RoomPlayers.Count == 0;
            NetworkRoomPlayerLobby roomPlayerInstance = Instantiate(roomPlayerPrefab);
            roomPlayerInstance.IsLeader = isLeader;
            NetworkServer.AddPlayerForConnection(conn, roomPlayerInstance.gameObject);
            Debug.Log("Player really added");
        
    }

    public override void OnServerDisconnect(NetworkConnection conn) {
        if(conn.identity != null) {
            var player = conn.identity.GetComponent<NetworkRoomPlayerLobby>();
            RoomPlayers.Remove(player);

            NotifyPlayersOfReadyState();
        }

        gamePlayerPrefab.InitializePlayer();

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
        yield return new WaitForSeconds(0.4f);

        gamePlayerPrefab.GetComponent<IngamePlayer>().InitializePlayer();
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
                var gameplayerPrefab = Instantiate(gamePlayerPrefab);
                gameplayerPrefab.SetDisplayName(RoomPlayers[i].DisplayName);

                Debug.Log("Ingame Player Instantiated");

                NetworkServer.Destroy(conn.identity.gameObject);

                NetworkServer.ReplacePlayerForConnection(conn, gameplayerPrefab.gameObject);

            }
        }
        base.ServerChangeScene(newSceneName);

    }

}
