﻿using System.Collections;
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
    [SerializeField] private Button startGameButton = null;
    [SerializeField] private Button exitButton = null;

    private Player player;

    [SyncVar(hook = nameof(HandleDisplayNameChanged))]
    public string DisplayName = "Loading...";
    [SyncVar(hook = nameof(HandleReadyStatusChanged))]
    public bool IsReady = false;
    private bool isLeader;

    [SyncVar]
    private string playerName;
    [SyncVar]
    private int playerLevel;
    [SyncVar]
    public bool demon;

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

    public override void OnStartAuthority() {
       
        CmdSetDisplayName(playerName);
        lobbyUI.SetActive(true);
    }

    public override void OnStartClient() {
      
        Room.RoomPlayers.Add(this);
        player = GameObject.Find("Player").GetComponent<Player>();
        playerName = player.username;
        playerLevel = player.level;
        if (player.demon) {
            demon = true;
        } else {
            demon = false;
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
        Debug.LogError("Game should start");
        Room.StartGame();
    }
}
