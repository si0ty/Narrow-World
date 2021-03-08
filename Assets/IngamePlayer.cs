using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
using DG.Tweening;
using Mirror;
using TMPro;

public class IngamePlayer : NetworkBehaviour
{


    public static IngamePlayer instance;

    //ingame 
    public int startMoney, startRedStone, startSkillPoints, startLevel;


    //Ressource Storage
    public static int roundMoney, roundStones, roundSkillPoints, roundEp;
    public  Dictionary<ResourceType, int> ingameResources, bankResources, resourceLimits;

    public  Dictionary<ResourceType, int> transferBook;

    private PlayerSkills playerSkills;
    private PlayerItems playerItems;
    private PlayerResourceManager resourceManager;
    public GameManager sceneLoader;
    public AudioManager audioManager;

    public ResourceDisplay ingameDisplay;
    public ResourceDisplay menuDisplay;

    public Transform enemyUI;
    public Transform playerUI;
    public NarrowNetwork network;

    [Header("StartScreenUI")]
    private StartScreen startUI;

    [SerializeField] public TMP_Text[] playerReadyTexts = new TMP_Text[4];
    [SyncVar(hook = nameof(HandleReadyStatusChanged))]
    public bool IsReady = false;

    public Vector3 pos;

    private Player player;
    private BuildQueue buildQueue;
    
    public Transform spawnPoint;

    private GameObject icon;
    /// <summary>
    /// NETWORK
    /// </summary>


    [SyncVar]
    public string playerName;
    [SyncVar]
    public int playerLevel;
  
    public bool demon;
  
    public int index;

    private NetworkIdentity thisid;

    private void Start() {

        playerSkills = new PlayerSkills();
        playerItems = new PlayerItems();

    }

    private NarrowNetwork room;

    private NarrowNetwork Room {
        get {
            if (room != null) { return room; }
            return room = NetworkManager.singleton as NarrowNetwork;
        }
    }

    public void HandleReadyStatusChanged(bool oldValue, bool newValue) => UpdateDisplay();

    public void UpdateDisplay() {
        if (!hasAuthority) {
            foreach (IngamePlayer player in Room.GamePlayers) {
                if (player.hasAuthority) {
                    player.UpdateDisplay();
                    break;
                }
            }
            return;
        }

        for (int i = 0; i < Room.GamePlayers.Count; i++) {
            
            playerReadyTexts[i].text = Room.GamePlayers[i].IsReady ? "<color=green>Ready</color>" : "<color=red>Not Ready</color>";

        }
    }

    [Command]
    public void CmdReadyUp() {
        IsReady = !IsReady;
        Room.NotifyPlayersOfReadyState();
      
            if (Room.GamePlayers[0].IsReady && Room.GamePlayers[1].IsReady) {
            startUI = GameObject.Find("Startscreen").GetComponent<StartScreen>();
          //  startUI.GetComponent<StartScreen>().Intro();
            ClientStartGame();
           
        }
    }

   [ClientRpc]
    public void ClientStartGame() {

        startUI = GameObject.Find("Startscreen").GetComponent<StartScreen>();
        startUI.GetComponent<StartScreen>().Intro();
    }

    public override void OnStartClient() {

        DontDestroyOnLoad(gameObject);
        thisid = GetComponent<NetworkIdentity>();

        player = GameObject.Find("Player").GetComponent<Player>();
        resourceManager = player.GetComponent<PlayerResourceManager>();
        playerName = player.playerName;
        playerLevel = player.level;

        resourceManager.LoadResources();

        network = GameObject.Find("NarrowNetwork").GetComponent<NarrowNetwork>();

        ingameResources = InitIngameResources();

        if (isLocalPlayer) {
            index = 1;

            demon = player.demon;

          
            if (demon == true) {
                gameObject.tag = "DemonPlayer";
                Room.GamePlayers.Add(this);

            }
            else {
                gameObject.tag = "KnightPlayer";
                Room.GamePlayers.Add(this);

            }

            if (isLocalPlayer) {
                Debug.Log("index: " + index.ToString() + "Is local Player");
            }
            else {
                Debug.Log("index: " + index.ToString() + "Is not local Player");

            }

            StartCoroutine(SetScripts());
            return;
        }
        else {
            index = 2;

            demon = player.demon;

            if (demon) {
                demon = false;

                gameObject.tag = "KnightPlayer";
                Room.GamePlayers.Add(this);
               

            }
            else  {
                demon = true;

                gameObject.tag = "DemonPlayer";

                Room.GamePlayers.Add(this);

            }

          
        }


    

    }

    /*

    public override void OnStopClient() {
        Room.GamePlayers.Remove(this);

    }



    public void OnNetworkDestroy() {
        Room.GamePlayers.Remove(this);
    }



    [Server]
    public void SetDisplayName(string displayName) {
        playerName = displayName;
    }
    */

    /// <summary>
    /// NETWORK
    /// </summary>

    /*
    private void CheckSingleton() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    } */

    public void InitializePlayer() {

        sceneLoader = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        buildQueue = FindObjectOfType<BuildQueue>().GetComponent<BuildQueue>();

     
        enemyUI = GameObject.Find("EnemyUI").gameObject.transform;
            playerUI = GameObject.Find("PlayerUI").gameObject.transform;

            if (player.demon) {
                // GameObject.Find("CameraFollow").gameObject.transform.DOMoveX(enemyBasePos, 0f);
                // enemyUI.transform.Find("HUD").gameObject.SetActive(true);

                playerUI.gameObject.SetActive(false);
                ingameDisplay = enemyUI.transform.Find("HUD").GetComponentInChildren<ResourceDisplay>();
            spawnPoint = enemyUI.transform.GetChild(7);
            
            Debug.Log("IngameDisplayFound");

            // StopCoroutine(SetScripts());
            return;
            }


            else if (!player.demon) {
                //  GameObject.Find("CameraFollow").gameObject.transform.DOMoveX(playerBasePos, 0f);

                // playerUI.transform.Find("HUD").gameObject.SetActive(true);
                enemyUI.gameObject.SetActive(false);
                ingameDisplay = playerUI.transform.Find("HUD").GetComponentInChildren<ResourceDisplay>();
            spawnPoint = playerUI.transform.GetChild(7);
            Debug.Log("IngameDisplayFound");

                // StopCoroutine(SetScripts());
            }

      
        //StartCoroutine(SetScripts());
    }

    IEnumerator SetScripts() {
        yield return new WaitForSeconds(0.8f);
       
        InitializePlayer();
      
      /*  else if (GameObject.Find("MenuResourceDisplay") != null) {
            menuDisplay = GameObject.Find("MenuResourceDisplay").GetComponent<ResourceDisplay>();
        }
      */


             
    }


    //Neue Methode bei der aktuelle Werte zurückgegeben werden.


    public static Dictionary<ResourceType, int> InitIngameResources() {
        Dictionary<ResourceType, int> list = new Dictionary<ResourceType, int>();
        list.Add(ResourceType.Money, 0);
        list.Add(ResourceType.Knowledge, 0);
        list.Add(ResourceType.RedStone, 0);


        return list;
    }


    public void AddStartResources() {
        AddResource(ResourceType.Money, startMoney, ingameDisplay);
      //  AddResource(ResourceType.Knowledge, 0, ingameDisplay);
      //  AddResource(ResourceType.RedStone, startRedStone, ingameDisplay);


    }

    public void AddResource(ResourceType type, int amount, ResourceDisplay display) {
        if (type == ResourceType.BankMoney || type == ResourceType.BankStone || type == ResourceType.EPPoints || type == ResourceType.SkillPoints) {
            bankResources[type] += amount;
        }
        else {
            ingameResources[type] += amount;
        }


        display.UpdateDisplay(amount, type, false);


        // ressourceUI.GetComponent<IngameResourceDisplay>().UpdateDisplay();
    }

    public  void SpendResource(ResourceType type, int amount, ResourceDisplay display) {
        if (type == ResourceType.BankMoney || type == ResourceType.BankStone || type == ResourceType.EPPoints || type == ResourceType.SkillPoints) {
            bankResources[type] -= amount;
        }
        else {
            ingameResources[type] -= amount;
        }


        display.UpdateDisplay(amount, type, true);

    }

    public int ReturnResource(ResourceType resourceType) {

        ingameResources.TryGetValue(resourceType, out int transfer);

        return transfer;
    }

    public void SendToBank() {
        roundMoney += ingameResources[ResourceType.Money];
        ingameResources[ResourceType.Money] = 0;

        roundStones += ingameResources[ResourceType.RedStone];
        ingameResources[ResourceType.RedStone] = 0;

        roundEp += ingameResources[ResourceType.Knowledge];
        ingameResources[ResourceType.Knowledge] = 0;

        roundSkillPoints += ingameResources[ResourceType.SkillPoints];
        ingameResources[ResourceType.SkillPoints] = 0;

        bankResources[ResourceType.BankMoney] += roundMoney;
        roundMoney = 0;


        bankResources[ResourceType.BankStone] += roundStones;
        roundStones = 0;

        bankResources[ResourceType.SkillPoints] += roundSkillPoints;
        roundSkillPoints = 0;

        bankResources[ResourceType.EPPoints] += roundEp;
        roundEp = 0;
    }


    public PlayerSkills GetPlayerSkills() {
        return playerSkills;
    }

    public PlayerItems GetPlayerItems() {
        return playerItems;
    }

    [Command]
    public void GiveAuthority(NetworkIdentity identity) {


        identity.AssignClientAuthority(connectionToClient);

        Debug.LogError("Authority given");
    }

    [Command]
    public void SpawnUnit(string name, Transform parent) {
      

      Debug.Log(  network.spawnablePrefabs.Count.ToString());

        foreach (GameObject prefab in network.spawnablePrefabs) {
           
            if (prefab.name == name) {
                GameObject unit = Instantiate(prefab, prefab.transform.position, Quaternion.identity);

              

                NetworkServer.Spawn(unit, connectionToClient);

                
                Debug.Log("Unit spawned");

            }

        }




    }


}
