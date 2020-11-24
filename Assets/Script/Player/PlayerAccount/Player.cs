using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
using DTS;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public string username;
    public bool demon;
    public int level;

    public int logins;

    public static Player instance;

    //ingame 
    public int startMoney, startRedStone, startSkillPoints, startLevel ;


     //Ressource Storage
    public static int roundMoney, roundStones, roundSkillPoints, roundEp;
    public static  Dictionary<ResourceType, int> ingameResources, bankResources, resourceLimits;

    public static Dictionary<ResourceType, int> transferBook;

    private PlayerSkills playerSkills;
    private PlayerItems playerItems;
    private PlayerResourceManager resourceManager;
    public GameManager sceneLoader;
   

    public ResourceDisplay ingameDisplay;
    public ResourceDisplay menuDisplay;

    private GameObject enemyUI;
    private GameObject playerUI;

    public HUD hud;


  


     void Awake() {
        CheckSingleton();
      

        playerSkills = new PlayerSkills();
        playerItems = new PlayerItems();

        ingameResources = InitIngameResources();
        bankResources = InitBankResources();

        resourceManager = GetComponent<PlayerResourceManager>();
      
        // playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;


    }

    private void Start() {

      
        if (SaveSystem.LoadResources() == null) {
            resourceManager.SaveResources();
        }

        resourceManager.LoadResources();


        level = resourceManager.playerLevel;
        logins = resourceManager.logins;

         logins++;

        Debug.Log(logins.ToString());
        StartCoroutine(SetScripts());
       
    }



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
        yield return new WaitForSeconds(0.01f);


        if(GameObject.Find("IngameResourceDisplay") != null) {

            if (demon) {
                enemyUI.transform.Find("HUD").gameObject.SetActive(true);

            }
            else {
                playerUI.transform.Find("HUD").gameObject.SetActive(true);
            }

            enemyUI = GameObject.Find("EnemyUI");
            playerUI = GameObject.Find("PlayerUI");

            if (demon) {
                ingameDisplay = enemyUI.transform.Find("HUD").GetComponentInChildren<ResourceDisplay>();

            }
            else {
                ingameDisplay = playerUI.transform.Find("HUD").GetComponentInChildren<ResourceDisplay>();
            }

            
        } else if (GameObject.Find("MenuResourceDisplay") != null)  {
            menuDisplay = GameObject.Find("MenuResourceDisplay").GetComponent<ResourceDisplay>();
        }


        sceneLoader = GameObject.Find("GameManager").GetComponent<GameManager>();


        

      

      

        if (ingameDisplay) {
      
            StartCoroutine(AddingStartResources());
        }

        if (menuDisplay) {
    

         
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



    public static Dictionary<ResourceType, int> InitBankResources() {
        Dictionary<ResourceType, int> list = new Dictionary<ResourceType, int>();
        list.Add(ResourceType.BankMoney, 500);
        list.Add(ResourceType.BankStone, 400);
        list.Add(ResourceType.SkillPoints, 300);
        list.Add(ResourceType.EPPoints, 300);

        return list;
    }

    public static Dictionary<ResourceType, int> LoadBankResources() {
        Dictionary<ResourceType, int> list = bankResources;
        
        return list;
    }



    public void AddStartResources() {
        AddResource(ResourceType.Money, startMoney, ingameDisplay);
        AddResource(ResourceType.Knowledge, 0, ingameDisplay);
        AddResource(ResourceType.RedStone, startRedStone, ingameDisplay);

    
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
