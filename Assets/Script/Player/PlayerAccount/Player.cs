using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
using DG.Tweening;
using Mirror;



public class Player : MonoBehaviour
{
    public string playerName;
    public bool demon;
    public int level;

    public int logins;

    public static Player instance;

    //ingame 
    public int startLevel;


     //Ressource Storage
    public static int roundMoney, roundStones, roundSkillPoints, roundEp;
    public static  Dictionary<ResourceType, int> ingameResources, bankResources, resourceLimits;

    public static Dictionary<ResourceType, int> transferBook;

    private PlayerSkills playerSkills;
    private PlayerItems playerItems;
    private PlayerResourceManager resourceManager;
    public GameManager sceneLoader;
    public AudioManager audioManager;
   

    public ResourceDisplay ingameDisplay;
    public ResourceDisplay menuDisplay;

   

    public HUD hud;

    private float playerBasePos = -6.37f;
    private float enemyBasePos = 27.15f;


    /// <summary>
    /// NETWORK
    /// </summary>

     
    void Awake() {
       
       CheckSingleton();
    


        playerSkills = new PlayerSkills();
        playerItems = new PlayerItems();

              

        // playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
    }


    private void Start() {

        resourceManager = GetComponent<PlayerResourceManager>();
      

        if (SaveSystem.LoadResources() == null) {
         

            bankResources = InitBankResources();
            

            resourceManager.SaveResources();

        } else {
            resourceManager.LoadResources();

            bankResources = resourceManager.bankResources;
        }


        level = resourceManager.playerLevel;
        logins = resourceManager.logins;
        playerName = resourceManager.playerName;

        logins++;

        Debug.Log(logins.ToString());
        StartCoroutine(SetScripts());

    
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
        yield return new WaitForSeconds(0.1f);


            
        if (GameObject.Find("MenuResourceDisplay") != null)  {
            menuDisplay = GameObject.Find("MenuResourceDisplay").GetComponent<ResourceDisplay>();
        }

        sceneLoader = GameObject.Find("GameManager").GetComponent<GameManager>();

    }


    public static Dictionary<ResourceType, int> InitBankResources() {
        Dictionary<ResourceType, int> list = new Dictionary<ResourceType, int>();
        list.Add(ResourceType.BankMoney, 0);
        list.Add(ResourceType.BankStone, 0);
        list.Add(ResourceType.SkillPoints, 0);
        list.Add(ResourceType.EPPoints, 0);

        return list;
    }

    public static Dictionary<ResourceType, int> LoadBankResources() {
        Dictionary<ResourceType, int> list = bankResources;
        
        return list;
    }


    public static void AddResource(ResourceType type, int amount, ResourceDisplay display) {
       if(type == ResourceType.BankMoney || type == ResourceType.BankStone || type == ResourceType.EPPoints || type == ResourceType.SkillPoints) {
            bankResources[type] += amount;
        } else {
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

