using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;

public class JoinLobbyMenu : NetworkBehaviour
{
    [SerializeField] private NarrowNetwork networkManager = null;

    [Header("UI")]
    [SerializeField] private GameObject landingPagePanel = null;
   
    [SerializeField] private Button joinButton = null;
   
    [SerializeField] private TMP_InputField ipAdressInputField;

    private PopUpSystem popUpSystem;

    private void Start() {
        networkManager = GameObject.Find("NarrowNetwork").GetComponent<NarrowNetwork>();
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
      
         //   Debug.Log("No Server active");
           // popUpSystem.SimplePopUp("No server active to join", 90);
               
      
      
    }

 private void HandleClientConnected() {
        joinButton.interactable = true;

        gameObject.SetActive(false);
        landingPagePanel.SetActive(false);
      
    }

    private void HandleClientDisconnected() {
       
        popUpSystem.SimplePopUp("Couldn't connect to server.", 90);
        joinButton.interactable = true;
    }

}
