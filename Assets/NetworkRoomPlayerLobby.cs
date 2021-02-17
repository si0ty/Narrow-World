using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Mirror;

public class NetworkRoomPlayerLobby : NetworkBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject lobbyUI;
    [SerializeField] private TMP_Text[] playerNameTexts = new TMP_Text[4];
    [SerializeField] private TMP_Text[] playerReadyTexts = new TMP_Text[4];
    [SerializeField] private TMP_Text hostText = null;
    [SerializeField] private Button startGameButton = null;
    [SerializeField] private Button exitButton = null;

    public Player player;

    [SyncVar(hook = nameof(HandleDisplayNameChanged))]
    public string DisplayName = "Loading...";
    [SyncVar(hook = nameof(HandleReadyStatusChanged))]
    public bool IsReady = false;
    private bool isLeader;

    public ChatBehaviour chatUI;

    [SyncVar]
    public string playerName;
    [SyncVar]
    public int playerLevel;

    public bool demon;
 
    public int index;

    public bool IsLeader {
        set {
            isLeader = value;
            startGameButton.gameObject.SetActive(value);
        }
    }

    private NarrowNetwork room;

    private NarrowNetwork Room {
        get {
            if(room != null) { return room; }
            return room = NetworkManager.singleton as NarrowNetwork;
        }
    }

    [Command]
    public void GiveAuthority(NetworkIdentity identity) {

        identity.AssignClientAuthority(connectionToClient);

        Debug.LogError("Authority given");
    }


    public override void OnStartAuthority() {
       
        CmdSetDisplayName(playerName);
        lobbyUI.SetActive(true);
        GiveAuthority(chatUI.GetComponent<NetworkIdentity>());
    }



    public override void OnStartClient() {

        player = GameObject.Find("Player").GetComponent<Player>();
        playerName = player.playerName;
        playerLevel = player.level;


        if (Room.RoomPlayers.Count == 0) {
            index = 1;
       
            Room.RoomPlayers.Add(this);
        }
        else {
            index = 2;
          
                Room.RoomPlayers.Add(this);
         
        }


        exitButton.onClick.AddListener(() => {
            room.StopServer();
        });

        CmdSetDisplayName(playerName);
        UpdateDisplay();
    }

    public override void OnStopClient() {
        Room.RoomPlayers.Remove(this);
        UpdateDisplay();
    }

    public void HandleReadyStatusChanged(bool oldValue, bool newValue) => UpdateDisplay();

    public void HandleDisplayNameChanged(string oldValue, string newValue) => UpdateDisplay();

    private void UpdateDisplay() {
        if (!hasAuthority) {
            foreach(var player in Room.RoomPlayers) {
                if (player.hasAuthority) {
                    player.UpdateDisplay();
                    break;
                }
            }
            return;
        }
        for (int i = 0; i < playerNameTexts.Length; i++) {
            playerNameTexts[i].text = "Waiting For Player...";
            playerReadyTexts[i].text = string.Empty;
        }

        for (int i = 0; i < Room.RoomPlayers.Count; i++) {
            playerNameTexts[i].text = Room.RoomPlayers[i].DisplayName;
            playerReadyTexts[i].text = Room.RoomPlayers[i].IsReady ? "<color=green>Ready</color>" : "<color=red>Not Ready</color>";

        }
    }

    public void HandleReadyToStart(bool readyToStart) {
        if (!isLeader) {
            return;
        }
        startGameButton.interactable = readyToStart;
    }

    [Command]
    private void CmdSetDisplayName(string displayName) {
        DisplayName = displayName;
    }

    [Command]
    public void CmdReadyUp() {
        IsReady = !IsReady;
        Room.NotifyPlayersOfReadyState();
    }

    [Command] 
    public void CmdStartGame() {
        if(Room.RoomPlayers[0].connectionToClient != connectionToClient) { return; }
        
        Room.StartGame();
    }
}
