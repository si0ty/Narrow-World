using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JoinLobbyMenu : MonoBehaviour
{
    [SerializeField] private NarrowNetwork networkManager = null;

    [Header("UI")]
    [SerializeField] private GameObject landingPagePanel = null;
   
    [SerializeField] private Button joinButton = null;
    [SerializeField] private Button exitButton = null;
    [SerializeField] private TMP_InputField ipAdressInputField;

    private PopUpSystem popUpSystem;

    private void Start() {
        networkManager = GameObject.Find("NetworkManager").GetComponent<NarrowNetwork>();
        popUpSystem = GameObject.Find("PopUpSystem").GetComponent<PopUpSystem>();
    }

    private void OnEnable() {
        NarrowNetwork.OnClientConnected += HandleClientConnected;
        NarrowNetwork.OnClientConnected += HandleClientDisconnected;

    }


    private void OnDisable() {
        NarrowNetwork.OnClientConnected -= HandleClientConnected;
        NarrowNetwork.OnClientConnected -= HandleClientDisconnected;

    }

    public void JoinLobby() {
        string ipAdress = ipAdressInputField.text;

        networkManager.networkAddress = ipAdress;
        networkManager.StartClient();

        joinButton.interactable = false;
    }

 private void HandleClientConnected() {
        joinButton.interactable = true;

        gameObject.SetActive(false);
        landingPagePanel.SetActive(false);
      
    }

    private void HandleClientDisconnected() {
        landingPagePanel.SetActive(true);
        popUpSystem.SimplePopUp("Couldn't connect to server.", 90);
        joinButton.interactable = true;
    }

}
