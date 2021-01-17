using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
using DG.Tweening;
using Mirror;

public class IngamePlayer : NetworkBehaviour
{
    public string username;
    public bool demon;
    public int level;
     

    public static IngamePlayer instance;

    //ingame 
    public int startMoney, startRedStone, startSkillPoints, startLevel;


    //Ressource Storage
    public static int roundMoney, roundStones, roundSkillPoints, roundEp;
    public static Dictionary<ResourceType, int> ingameResources, bankResources, resourceLimits;

    public static Dictionary<ResourceType, int> transferBook;

    private PlayerSkills playerSkills;
    private PlayerItems playerItems;
    private PlayerResourceManager resourceManager;
    public GameManager sceneLoader;
    public AudioManager audioManager;


    public ResourceDisplay ingameDisplay;
    public ResourceDisplay menuDisplay;

    public Transform enemyUI;
    public Transform playerUI;

    public HUD hud;

    private float playerBasePos = -6.37f;
    private float enemyBasePos = 27.15f;

    private Player player;


    /// <summary>
    /// NETWORK
    /// </summary>


    [SyncVar]
    private string playerName;
    [SyncVar]
    private int playerLevel;

    void Awake() {

        CheckSingleton();
        // DontDestroyOnLoad(gameObject);

        playerSkills = new PlayerSkills();
        playerItems = new PlayerItems();

        // playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
    }

    private void Start() {

        resourceManager = GetComponent<PlayerResourceManager>();

        ingameResources = InitIngameResources();

        StartCoroutine(SetScripts());

        playerName = resourceManager.name;
        playerLevel = resourceManager.playerLevel;

        player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    [SyncVar]
    private string displayName = "Loading...";


    private NarrowNetwork room;

    private NarrowNetwork Room {
        get {
            if (room != null) { return room; }
            return room = NetworkManager.singleton as NarrowNetwork;
        }
    }

    public override void OnStartClient() {
        DontDestroyOnLoad(gameObject);
        Room.GamePlayers.Add(this);

    }

    public override void OnStopClient() {
        Room.GamePlayers.Remove(this);

    }



    public void OnNetworkDestroy() {
        Room.GamePlayers.Remove(this);
    }

    [Server]
    public void SetDisplayName(string displayName) {
        this.displayName = displayName;
    }

    /// <summary>
    /// NETWORK
    /// </summary>

    private void CheckSingleton() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void InitializePlayer() {
        StartCoroutine(SetScripts());
    }

    IEnumerator SetScripts() {
        yield return new WaitForSeconds(0.2f);



        if (GameObject.Find("IngameResourceDisplay") != null) {

            enemyUI = GameObject.Find("EnemyUI").gameObject.transform;
            playerUI = GameObject.Find("PlayerUI").gameObject.transform;

            if (player.demon) {
                GameObject.Find("CameraFollow").gameObject.transform.DOMoveX(enemyBasePos, 0f);
                enemyUI.transform.Find("HUD").gameObject.SetActive(true);



            }
            else {
                GameObject.Find("CameraFollow").gameObject.transform.DOMoveX(playerBasePos, 0f);

                playerUI.transform.Find("HUD").gameObject.SetActive(true);

            }



            if (player.demon) {
                playerUI.gameObject.SetActive(false);
                ingameDisplay = GameObject.Find("IngameResourceDisplay").GetComponent<ResourceDisplay>();

            }
            else {
                enemyUI.gameObject.SetActive(false);
                ingameDisplay = GameObject.Find("IngameResourceDisplay").GetComponent<ResourceDisplay>();
            }


        }
      /*  else if (GameObject.Find("MenuResourceDisplay") != null) {
            menuDisplay = GameObject.Find("MenuResourceDisplay").GetComponent<ResourceDisplay>();
        }
      */

        sceneLoader = GameObject.Find("GameManager").GetComponent<GameManager>();


        if (ingameDisplay) {

            StartCoroutine(AddingStartResources());
        }
             
    }

    public IEnumerator AddingStartResources() {
        yield return new WaitForSeconds(0.2f);

        AddStartResources();

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
        AddResource(ResourceType.Knowledge, 0, ingameDisplay);
        AddResource(ResourceType.RedStone, startRedStone, ingameDisplay);


    }

    public static void AddResource(ResourceType type, int amount, ResourceDisplay display) {
        if (type == ResourceType.BankMoney || type == ResourceType.BankStone || type == ResourceType.EPPoints || type == ResourceType.SkillPoints) {
            bankResources[type] += amount;
        }
        else {
            ingameResources[type] += amount;
        }


        display.UpdateDisplay(amount, type, false);


        // ressourceUI.GetComponent<IngameResourceDisplay>().UpdateDisplay();
    }

    public static void SpendResource(ResourceType type, int amount, ResourceDisplay display) {
        if (type == ResourceType.BankMoney || type == ResourceType.BankStone || type == ResourceType.EPPoints || type == ResourceType.SkillPoints) {
            bankResources[type] -= amount;
        }
        else {
            ingameResources[type] -= amount;
        }


        display.UpdateDisplay(amount, type, true);

    }

    public static int ReturnResource(ResourceType resourceType) {

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
}
