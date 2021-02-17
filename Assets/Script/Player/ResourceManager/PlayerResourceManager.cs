


using System;
using System.Collections.Generic;
using System.Collections;
using Mirror;

using UnityEngine;


namespace RTS {
    
    public enum ResourceType { SkillPoints, RedStone, Money, Knowledge
                               , BankStone, BankMoney, EPPoints,
    };

     
    
    public class PlayerResourceManager : MonoBehaviour
{
         
       //skillUnlockList muss noch  rein
        private Player player;
        private IngamePlayer ingamePlayer;
        public PlayerSkills playerSkills;
        public PlayerItems playerItems;

        public int requiredTier1 = 0;
        public int requiredTier2 = 250;
        public int requiredTier3 = 750;

        public DateTime timeStore;
        public bool goldReady;

        private void Start() {
          
           // DontDestroyOnLoad(gameObject);
            if(GetComponent<Player>() != null) {
                player = GetComponent<Player>();
            } else {
                ingamePlayer = GetComponent<IngamePlayer>();
            }
           

          
        }

        public string playerName;
        public int playerLevel = 1;
        public int logins = 0;
        //Camer
        public  float scrollWidth = 300;  
        public  float scrollHeight = 100; 
        public  float scrollSpeed = 2; 
        public  float rotateAmount = 10; 
        public  float rotateSpeed = 80; 
        public  float minCameraHeight =  10; 
        public  float maxCameraHeight =  40;  
     
        //Tier1
        //Shiel
        public  int shieldHealth  = 150; 
        public  int shieldDamage  = 20;
        public  int shieldCritRate = 6;
        public  int shieldCritMin = 5;
        public  int shieldCritMax = 15;
        public  float shieldRange = 0.3f;
        public  float shieldAttackSpeed = 3;
        public  float shieldWalkSpeed = 1;
        public  float shieldTrainSpeed = 10;
        public  int shieldTrainCost = 10;

        public float shieldPushback = -40f;


        //Broad
        public  int broadswordHealth   = 110; 
        public  int broadswordDamage   = 10;
        public  int broadswordCritRate = 1;
        public  int broadswordCritMin = 5;
        public  int broadswordCritMax = 15;
        public  float broadswordRange  = 0.3f;
        public  float broadswordAttackSpeed = 3;
        public  float broadswordWalkSpeed = 1;
        public  float broadswordTrainSpeed = 10;
        public  int broadswordTrainCost = 10;

        //Runne
        public  int runnerHealth  = 90; 
        public  int runnerDamage  = 50;
        public  int runnerCritRate = 1;
        public  int runnerCritMin = 5;
        public  int runnerCritMax = 15;
        public  float runnerRange = 20; 
        public  float runnerWalkSpeed = 1.1f;
        public  float runnerAttackSpeed = 3;
        public  float runnerRunningSpeed = 1.3f;
        public  float runnerTrainSpeed = 10;
        public  int runnerTrainCost = 10;

        //Arche
        public  int archerHealth = 60; 
        public  int archerShootDamage = 50;
        public  float archerFireRate = 1;
        public float archerFireRange = 1;
        public  float archerWalkSpeed = 1;
        public  float archerTravelSpeed = 10;
        public  float archerTrainSpeed = 10;
        public  int archerTrainCost = 10;
        public float archerPushback = 20;


        //Tier2

        //Shielin
        public  int shieldCaptainHealth  = 250; 
        public  int shieldCaptainDamage  = 40;
        public  int shieldCaptainCritRate = 1;
        public  int shieldCaptainCritMin = 5;
        public  int shieldCaptainCritMax = 15;
        public  float shieldCaptainRange = 0.5f;
        public  float shieldCaptainAttackSpeed = 2.5f;
        public  float shieldCaptainWalkSpeed = 1;
        public  float shieldCaptainTrainSpeed = 10;
        public  int shieldCaptainTrainCost = 10;

        //Broadunner
        public  int broadswordCaptainHealth  = 180;
        public  int broadswordCaptainDamage  = 65;
        public  int broadswordCaptainCritRate = 1;
        public  int broadswordCaptainCritMin = 5;
        public  int broadswordCaptainCritMax = 15;
        public  float broadswordCaptainRange = 0.6f;
        public  float broadswordCaptainAttackSpeed = 2.5f;
        public  float broadswordCaptainWalkSpeed = 1;
        public  float broadswordCaptainTrainSpeed = 10;
        public  int broadswordCaptainTrainCost = 10;

        //Runnein
        public  int runnerCaptainHealth = 120; 
        public  int runnerCaptainDamage = 100;
        public  int runnerCaptainCritRate = 1;
        public  int runnerCaptainCritMin = 5;
        public  int runnerCaptainCritMax = 15;
        public  float runnerCaptainRange  = 0.6f;
        public  float runnerCaptainWalkSpeed  = 1.1f;
        public  float runnerCaptainAttackSpeed = 2.5f;
        public  float runnerCaptainRunningSpeed = 1.4f;
        public  float runnerCaptainTrainSpeed = 10;
        public  int runnerCaptainTrainCost = 10;

        //Archein
        public  int archerCaptainHealth = 100; 
        public  int archerCaptainShootDamage = 80;
        public  float archerCaptainFireRate = 5;
        public float archerCaptainFireRange = 2;
        public  float archerCaptainWalkSpeed = 1.05f;
        public  float archerCaptainTravelSpeed = 10f;
        public  float archerCaptainTrainSpeed = 10;
        public  int archerCaptainTrainCost = 10;

        //Mage
          public  int fireMageHealth = 150; 
          public  int fireMageShootDamage = 120; 
          public  int fireMageNormalCastDamage = 150; 
          public  int fireMageSuperCastDamage = 200; 
        public  float fireMageRange = 1f; 
        public  float fireMageWalkSpeed = 1.1f;
        public  float fireMageTrainSpeed = 10;
        public  int fireMageTrainCost = 10;
        public  float fireMageCritRate = 6;
        public  float fireMageCritMin = 5;
        public  float fireMageCritMax = 15;                    
        public  float fireMageFireRate = 5;
        public  float fireMageCastRate = 10;
        public  float fireMageSuperCastRate = 15;

          public int boltMageHealth = 150;
          public int boltMageShootDamage = 120;
          public int boltMageNormalCastDamage = 150;
          public int boltMageSuperCastDamage = 200;
        public float boltMageRange = 1f;
        public float boltMageWalkSpeed = 1.1f;
        public float boltMageTrainSpeed = 10;
        public int boltMageTrainCost = 10;
        public float boltMageCritRate = 6;
        public float boltMageCritMin = 5;
        public float boltMageCritMax = 15;            
        public float boltMageFireRate = 5;
        public float boltMageCastRate = 10;
        public float boltMageSuperCastRate = 15;

          public int natureMageHealth = 150;
          public int natureMageShootDamage = 120;
          public int natureMageNormalCastDamage = 150;
          public int natureMageSuperCastDamage = 200;
        public float natureMageRange = 1f;
        public float natureMageWalkSpeed = 1.1f;
        public float natureMageTrainSpeed = 10;
        public int natureMageTrainCost = 10;
        public float natureMageCritRate = 6;
        public float natureMageCritMin = 5;
        public float natureMageCritMax = 15;                   
        public float natureMageFireRate = 5;
        public float natureMageCastRate = 10;
        public float natureMageSuperCastRate = 15;









        //Tier3

        //Shiel
        public  int shieldHeroHealth = 600; 
        public  int shieldHeroDamage = 80;
        public  int shieldHeroCritRate = 1;
        public  int shieldHeroCritMin = 5;
        public  int shieldHeroCritMax = 15;
        public  float shieldHeroRange = 0.5f;
        public  float shieldHeroAttackSpeed = 2.5f;
        public  float shieldHeroWalkSpeed = 1;
        public  float shieldHeroTrainSpeed = 10;
        public  int shieldHeroTrainCost = 10;

        //Broadero
        public  int broadswordHeroHealth = 300; 
        public  int broadswordHeroDamage = 100;
        public  int broadswordHeroCritRate = 1;
        public  int broadswordHeroCritMin = 5;
        public  int broadswordHeroCritMax = 15;
        public  float broadswordHeroRange = 0.6f;
        public  float broadswordHeroAttackSpeed = 2.5f;
        public  float broadswordHeroWalkSpeed = 1.1f; 
        public  float broadswordHeroRunningSpeed = 1.3f;
        public  float broadswordHeroTrainSpeed = 10;
        public  int broadswordHeroTrainCost = 10;

        //Runne
        public  int runnerHeroHealth = 180;
        public  int runnerHeroDamage = 150;
        public  int runnerHeroCritRate = 1;
        public  int runnerHeroCritMin = 5;
        public  int runnerHeroCritMax = 15;
        public  float runnerHeroRange = 0.6f;
        public  float runnerHeroAttackSpeed = 2.5f;
        public  float runnerHeroWalkSpeed = 1.2f;
        public  float runnerHeroRunningSpeed = 1.5f;
        public  float runnerHeroTrainSpeed = 10;
        public  int runnerHeroTrainCost = 10;


        //Arche
        public  int archerHeroHealth = 150; 
        public  int archerHeroShootDamage = 100;
        public  float archerHeroFireRate = 3;
        public float archerHeroFireRange = 3;
        public  float archerHeroWalkSpeed = 1.1f;
        public  float archerHeroTravelSpeed = 10f;
        public  float archerHeroTrainSpeed = 10;
        public  int archerHeroTrainCost = 10;

        //MageH
         public  int fireMageHeroHealth = 210;
         public  int fireMageHeroShootDamage = 150;
         public  int fireMageHeroNormalCastDamage = 200; 
         public  int fireMageHeroSuperCastDamage = 300; 
       public  float fireMageHeroRange = 1.2f;
       public  float fireMageHeroWalkSpeed = 1.1f;
       public  float fireMageHeroTrainSpeed = 10;
       public  float fireMageHeroCritRate = 6;
       public  float fireMageHeroCritMin = 5;
       public  float fireMageHeroCritMax = 15;
       public  int fireMageHeroTrainCost = 10;
       public  float fireMageHeroFireRate = 5;
       public  float fireMageHeroCastRate = 10;
       public  float fireMageHeroSuperCastRate = 15;

        
          public int boltMageHeroHealth = 150;
          public int boltMageHeroShootDamage = 120;
          public int boltMageHeroNormalCastDamage = 150;
          public int boltMageHeroSuperCastDamage = 200;
        public float boltMageHeroRange = 1.2f;
        public float boltMageHeroWalkSpeed = 1.1f;
        public float boltMageHeroTrainSpeed = 10;
        public int boltMageHeroTrainCost = 10;
        public float boltMageHeroCritRate = 6;
        public float boltMageHeroCritMin = 5;
        public float boltMageHeroCritMax = 15;
        public float boltMageHeroFireRate = 5;
        public float boltMageHeroCastRate = 10;
        public float boltMageHeroSuperCastRate = 15;

          public int natureMageHeroHealth = 500;
          public int natureMageHeroShootDamage = 120;
          public int natureMageHeroNormalCastDamage = 150;
          public int natureMageHeroSuperCastDamage = 200;
        public float natureMageHeroRange = 1.2f;
        public float natureMageHeroWalkSpeed = 1.1f;
        public float natureMageHeroTrainSpeed = 10;
        public int natureMageHeroTrainCost = 10;
        public float natureMageHeroCritRate = 6;
        public float natureMageHeroCritMin = 5;
        public float natureMageHeroCritMax = 15;
        public float natureMageHeroFireRate = 5;
        public float natureMageHeroCastRate = 10;
        public float natureMageHeroSuperCastRate = 15;

        //
        //DEMONS
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// 

        public int skeletonBroadswordHealth = 150;
        public int skeletonBroadswordDamage = 20;
        public int skeletonBroadswordCritRate = 6;
        public int skeletonBroadswordCritMin = 5;
        public int skeletonBroadswordCritMax = 15;
        public float skeletonBroadswordRange = 0.3f;
        public float skeletonBroadswordAttackSpeed = 3;
        public float skeletonBroadswordWalkSpeed = 1;
        public float skeletonBroadswordTrainSpeed = 10;
        public int skeletonBroadswordTrainCost = 10;


        //Broad
        public int impHealth = 110;
        public int impDamage = 10;
        public int impCritRate = 1;
        public int impCritMin = 5;
        public int impCritMax = 15;
        public float impRange = 0.3f;
        public float impAttackSpeed = 3;
        public float impWalkSpeed = 1;
        public float impTrainSpeed = 10;
        public int impTrainCost = 10;

        //Runne
        public int shamanHealth = 150;
        public int shamanShootDamage = 120;
        public int shamanNormalCastDamage = 150;
        public int shamanSuperCastDamage = 200;
        public float shamanRange = 1f;
        public float shamanWalkSpeed = 1.1f;
        public float shamanTrainSpeed = 10;
        public int shamanTrainCost = 10;
        public float shamanCritRate = 6;
        public float shamanCritMin = 5;
        public float shamanCritMax = 15;
        public float shamanFireRate = 15;
        public float shamanCastRate = 15;
        public float shamanSuperCastRate = 15;

        //Arche
        public int skeletonArcherHealth = 60;
        public int skeletonArcherShootDamage = 50;
        public float skeletonArcherFireRate = 4;
        public float skeletonArcherWalkSpeed = 1;
        public float skeletonArcherTravelSpeed = 1;
        public float skeletonArcherTrainSpeed = 10;
        public int skeletonArcherTrainCost = 10;


        //Tier2

        //Shielin
        public int clawDemonHealth = 250;
        public int clawDemonDamage = 40;
        public int clawDemonCritRate = 1;
        public int clawDemonCritMin = 5;
        public int clawDemonCritMax = 15;
        public float clawDemonRange = 0.5f;
        public float clawDemonAttackSpeed = 2.5f;
        public float clawDemonWalkSpeed = 1;
        public float clawDemonTrainSpeed = 10;
        public int clawDemonTrainCost = 10;

        //Broadunner
        public int stoneDemonHealth = 180;
        public int stoneDemonDamage = 65;
        public int stoneDemonCritRate = 1;
        public int stoneDemonCritMin = 5;
        public int stoneDemonCritMax = 15;
        public float stoneDemonRange = 0.6f;
        public float stoneDemonAttackSpeed = 2.5f;
        public float stoneDemonWalkSpeed = 1;
        public float stoneDemonTrainSpeed = 10;
        public int stoneDemonTrainCost = 10;

        //Runnein
        public int axeDemonHealth = 120;
        public int axeDemonDamage = 100;
        public int axeDemonCritRate = 1;
        public int axeDemonCritMin = 5;
        public int axeDemonCritMax = 15;
        public float axeDemonRange = 0.6f;
        public float axeDemonWalkSpeed = 1.1f;
        public float axeDemonAttackSpeed = 2.5f;
        public float axeDemonRunningSpeed = 1.4f;
        public float axeDemonTrainSpeed = 10;
        public int axeDemonTrainCost = 10;

        //Archein
        public int ghostDemonHealth = 120;
        public int ghostDemonDamage = 100;
        public int ghostDemonCritRate = 1;
        public int ghostDemonCritMin = 5;
        public int ghostDemonCritMax = 15;
        public float ghostDemonRange = 0.6f;
        public float ghostDemonWalkSpeed = 1.1f;
        public float ghostDemonAttackSpeed = 2.5f;
        public float ghostDemonRunningSpeed = 1.4f;
        public float ghostDemonTrainSpeed = 10;
        public int ghostDemonTrainCost = 10;

        //Tier3


        //Broadero
        public int redStoneDemonHealth = 300;
        public int redStoneDemonDamage = 100;
        public int redStoneDemonCritRate = 1;
        public int redStoneDemonCritMin = 5;
        public int redStoneDemonCritMax = 15;
        public float redStoneDemonRange = 0.6f;
        public float redStoneDemonAttackSpeed = 2.5f;
        public float redStoneDemonWalkSpeed = 1.1f;
        public float redStoneDemonRunningSpeed = 1.3f;
        public float redStoneDemonTrainSpeed = 10;
        public int redStoneDemonTrainCost = 10;


        public int heroDemonDamage = 100;
        public float heroDemonAttackSpeed = 2.5f;
        //MageH
        public int heroDemonHealth = 210;

        public int heroDemonShootDamage = 150;
        public int heroDemonNormalCastDamage = 200;
        public int heroDemonSuperCastDamage = 300;
        public float heroDemonRange = 1.2f;
        public float heroDemonWalkSpeed = 1.1f;
        public float heroDemonTrainSpeed = 10;
        public int heroDemonCritRate = 6;
        public int heroDemonCritMin = 5;
        public int heroDemonCritMax = 15;
        public int heroDemonTrainCost = 10;
        public float heroDemonFireRate = 15;
        public float heroDemonCastRate = 15;
        public float heroDemonSuperCastRate = 15;


        public int heroMageDemonHealth = 150;
        public int heroMageDemonShootDamage = 120;
        public int heroMageDemonNormalCastDamage = 150;
        public int heroMageDemonSuperCastDamage = 200;
        public float heroMageDemonRange = 1.2f;
        public float heroMageDemonWalkSpeed = 1.1f;
        public float heroMageDemonTrainSpeed = 10;
        public int heroMageDemonTrainCost = 10;
        public float heroMageDemonCritRate = 6;
        public float heroMageDemonCritMin = 5;
        public float heroMageDemonCritMax = 15;
        public float heroMageDemonFireRate = 15;
        public float heroMageDemonCastRate = 15;
        public float heroMageDemonSuperCastRate = 15;


        public List<PlayerSkills.SkillType> unlockedSkillList;
        public List<PlayerItems.ItemType> unlockedItemsList;
        public Dictionary<ResourceType, int> bankResources;

        public void SaveResources() {

            playerSkills = player.GetPlayerSkills();

            if (playerItems) {
                playerItems = ingamePlayer.GetPlayerItems();
                unlockedItemsList = playerItems.returnUnlockedItems();
            }

            bankResources = Player.LoadBankResources();
           
            unlockedSkillList = playerSkills.returnUnlockedSkills();
          
            logins = player.logins;
            playerLevel = player.level;
           


            SaveSystem.SaveResources(this);
        }


        public void LoadResources() {

          
            DTS.PlayerData data = SaveSystem.LoadResources();

            //new to synchronize
            unlockedSkillList = data.unlockedSkillList;
            unlockedItemsList = data.unlockedItemsList;
            PlayerSkills.SetUnlockedSkills(unlockedSkillList);
            if(playerItems) {
                playerItems.SetUnlockedList(unlockedItemsList);

            }

            logins = data.logins;

            timeStore = data.timeStore;
            goldReady = data.goldReady;

            playerName = data.playerName;
            playerLevel = data.playerLevel;

        bankResources = data.bankResources;

            archerFireRange = data.archerFireRange;
            archerCaptainFireRange = data.archerCaptainFireRange;
            archerHeroFireRange = data.archerHeroFireRange;



    
        shieldHealth = data.shieldHealth;
            shieldDamage = data.shieldDamage;
            shieldCritRate = data.shieldCritRate;
            shieldCritMin = data.shieldCritMin;
            shieldCritMax = data.shieldCritMax;
            shieldRange = data.shieldRange;
            shieldAttackSpeed = data.shieldAttackSpeed;
            shieldWalkSpeed = data.shieldWalkSpeed;
            shieldTrainSpeed = data.shieldTrainSpeed;
            shieldTrainCost = data.shieldTrainCost;

            broadswordHealth = data.broadswordHealth;
            broadswordDamage = data.broadswordDamage;
            broadswordCritRate = data.broadswordCritRate;
            broadswordCritMin = data.broadswordCritMin;
            broadswordCritMax = data.broadswordCritMax;
            broadswordRange = data.broadswordRange;
            broadswordAttackSpeed = data.broadswordAttackSpeed;
            broadswordWalkSpeed = data.broadswordWalkSpeed;
            broadswordTrainSpeed = data.broadswordTrainSpeed;
            broadswordTrainCost = data.broadswordTrainCost;

            runnerHealth = data.runnerHealth;
            runnerDamage = data.runnerDamage;
            runnerCritRate = data.runnerCritRate;
            runnerCritMin = data.runnerCritMin;
            runnerCritMax = data.runnerCritMax;
            runnerRange = data.runnerRange;
            runnerWalkSpeed = data.runnerWalkSpeed;
            runnerAttackSpeed = data.runnerAttackSpeed;
            runnerRunningSpeed = data.runnerRunningSpeed;
            runnerTrainSpeed = data.runnerTrainSpeed;
            runnerTrainCost = data.runnerTrainCost;

            archerHealth = data.archerHealth;
            archerShootDamage = data.archerShootDamage;
            archerFireRate = data.archerFireRate;
            archerWalkSpeed = data.archerWalkSpeed;
            archerTravelSpeed = data.archerTravelSpeed;
            archerTrainSpeed = data.archerTrainSpeed;
            archerTrainCost = data.archerTrainCost;

            shieldCaptainHealth = data.shieldCaptainHealth;
            shieldCaptainDamage = data.shieldCaptainDamage;
            shieldCaptainCritRate = data.shieldCaptainCritRate;
            shieldCaptainCritMin = data.shieldCaptainCritMin;
            shieldCaptainCritMax = data.shieldCaptainCritMax;
            shieldCaptainRange = data.shieldCaptainRange;
            shieldCaptainAttackSpeed = data.shieldCaptainAttackSpeed;
            shieldCaptainWalkSpeed = data.shieldCaptainWalkSpeed;
            shieldCaptainTrainSpeed = data.shieldCaptainTrainSpeed;
            shieldCaptainTrainCost = data.shieldCaptainTrainCost;

            broadswordCaptainHealth = data.broadswordCaptainHealth;
            broadswordCaptainDamage = data.broadswordCaptainDamage;
            broadswordCaptainCritRate = data.broadswordCaptainCritRate;
            broadswordCaptainCritMin = data.broadswordCaptainCritMin;
            broadswordCaptainCritMax = data.broadswordCaptainCritMax;
            broadswordCaptainRange = data.broadswordCaptainRange;
            broadswordCaptainAttackSpeed = data.broadswordCaptainAttackSpeed;
            broadswordCaptainWalkSpeed = data.broadswordCaptainWalkSpeed;
            broadswordCaptainTrainSpeed = data.broadswordCaptainTrainSpeed;
            broadswordCaptainTrainCost = data.broadswordCaptainTrainCost;

            runnerCaptainHealth = data.runnerCaptainHealth;
            runnerCaptainDamage = data.runnerCaptainDamage;
            runnerCaptainCritRate = data.runnerCaptainCritRate;
            runnerCaptainCritMin = data.runnerCaptainCritMin;
            runnerCaptainCritMax = data.runnerCaptainCritMax;
            runnerCaptainRange = data.runnerCaptainRange;
            runnerCaptainWalkSpeed = data.runnerCaptainWalkSpeed;
            runnerCaptainAttackSpeed = data.runnerCaptainAttackSpeed;
            runnerCaptainRunningSpeed = data.runnerCaptainRunningSpeed;
            runnerCaptainTrainSpeed = data.runnerCaptainTrainSpeed;
            runnerCaptainTrainCost = data.runnerCaptainTrainCost;

            archerCaptainHealth = data.archerCaptainHealth;
            archerCaptainShootDamage = data.archerCaptainShootDamage;
            archerCaptainFireRate = data.archerCaptainFireRate;
            archerCaptainWalkSpeed = data.archerCaptainWalkSpeed;
            archerCaptainTravelSpeed = data.archerCaptainTravelSpeed;
            archerCaptainTrainSpeed = data.archerCaptainTrainSpeed;
            archerCaptainTrainCost = data.archerCaptainTrainCost;

            fireMageHealth = data.fireMageHealth;
            fireMageShootDamage = data.fireMageShootDamage;
            fireMageNormalCastDamage = data.fireMageNormalCastDamage;
            fireMageSuperCastDamage = data.fireMageSuperCastDamage;
            fireMageRange = data.fireMageRange;
            fireMageWalkSpeed = data.fireMageWalkSpeed;
            fireMageTrainSpeed = data.fireMageTrainSpeed;
            fireMageTrainCost = data.fireMageTrainCost;
            fireMageCritRate = data.fireMageCritRate;
            fireMageCritMin = data.fireMageCritMin;
            fireMageCritMax = data.fireMageCritMax;
            fireMageFireRate = data.fireMageFireRate;
            fireMageSuperCastRate = data.fireMageSuperCastRate;
            fireMageCastRate = data.fireMageCastRate;


            boltMageHealth = data.boltMageHealth;
            boltMageShootDamage = data.boltMageShootDamage;
            boltMageNormalCastDamage = data.boltMageNormalCastDamage;
            boltMageSuperCastDamage = data.boltMageSuperCastDamage;
            boltMageRange = data.boltMageRange;
            boltMageWalkSpeed = data.boltMageWalkSpeed;
            boltMageTrainSpeed = data.boltMageTrainSpeed;
            boltMageTrainCost = data.boltMageTrainCost;
            boltMageCritRate = data.boltMageCritRate;
            boltMageCritMin = data.boltMageCritMin;
            boltMageCritMax = data.boltMageCritMax;
            boltMageFireRate = data.boltMageFireRate;
            boltMageSuperCastRate = data.boltMageSuperCastRate;
            boltMageCastRate = data.boltMageCastRate;

            natureMageHealth = data.natureMageHealth;
            natureMageShootDamage = data.natureMageShootDamage;
            natureMageNormalCastDamage = data.natureMageNormalCastDamage;
            natureMageSuperCastDamage = data.natureMageSuperCastDamage;
            natureMageRange = data.natureMageRange;
            natureMageWalkSpeed = data.natureMageWalkSpeed;
            natureMageTrainSpeed = data.natureMageTrainSpeed;
            natureMageTrainCost = data.natureMageTrainCost;
            natureMageCritRate = data.natureMageCritRate;
            natureMageCritMin = data.natureMageCritMin;
            natureMageCritMax = data.natureMageCritMax;
            natureMageFireRate = data.natureMageFireRate;
            natureMageSuperCastRate = data.natureMageSuperCastRate;
            natureMageCastRate = data.natureMageCastRate;

            //Tier3:

            //ShieldHero
            shieldHeroHealth = data.shieldHeroHealth;
            shieldHeroDamage = data.shieldHeroDamage;
            shieldHeroCritRate = data.shieldHeroCritRate;
            shieldHeroCritMin = data.shieldHeroCritMin;
            shieldHeroCritMax = data.shieldHeroCritMax;
            shieldHeroRange = data.shieldHeroRange;
            shieldHeroAttackSpeed = data.shieldHeroAttackSpeed;
            shieldHeroWalkSpeed = data.shieldHeroWalkSpeed;
            shieldHeroTrainSpeed = data.shieldHeroTrainSpeed;
            shieldHeroTrainCost = data.shieldHeroTrainCost;

            //BroadswordHero
            broadswordHeroHealth = data.broadswordHeroHealth;
            broadswordHeroDamage = data.broadswordHeroDamage;
            broadswordHeroCritRate = data.broadswordHeroCritRate;
            broadswordHeroCritMin = data.broadswordHeroCritMin;
            broadswordHeroCritMax = data.broadswordHeroCritMax;
            broadswordHeroRange = data.broadswordHeroRange;
            broadswordHeroAttackSpeed = data.broadswordHeroAttackSpeed;
            broadswordHeroWalkSpeed = data.broadswordHeroWalkSpeed;
            broadswordHeroRunningSpeed = data.broadswordHeroRunningSpeed;
            broadswordHeroTrainSpeed = data.broadswordHeroTrainSpeed;
            broadswordHeroTrainCost = data.broadswordHeroTrainCost;

            //RunnerHero
            runnerHeroHealth = data.runnerHeroHealth;
            runnerHeroDamage = data.runnerHeroDamage;
            runnerHeroCritRate = data.runnerHeroCritRate;
            runnerHeroCritMin = data.runnerHeroCritMin;
            runnerHeroCritMax = data.runnerHeroCritMax;
            runnerHeroRange = data.runnerHeroRange;
            runnerHeroAttackSpeed = data.runnerHeroAttackSpeed;
            runnerHeroWalkSpeed = data.runnerHeroWalkSpeed;
            runnerHeroRunningSpeed = data.runnerHeroRunningSpeed;
            runnerHeroTrainSpeed = data.runnerHeroTrainSpeed;
            runnerHeroTrainCost = data.runnerHeroTrainCost;


            //ArcherHero
            archerHeroHealth = data.archerHeroHealth;
            archerHeroShootDamage = data.archerHeroShootDamage;
            archerHeroFireRate = data.archerHeroFireRate;
            archerHeroWalkSpeed = data.archerHeroWalkSpeed;
            archerHeroTravelSpeed = data.archerHeroTravelSpeed;
            archerHeroTrainSpeed = data.archerHeroTrainSpeed;
            archerHeroTrainCost = data.archerHeroTrainCost;

            //MageHero
            fireMageHeroHealth = data.fireMageHeroHealth;
            fireMageHeroShootDamage = data.fireMageHeroShootDamage;
            fireMageHeroNormalCastDamage = data.fireMageHeroNormalCastDamage;
            fireMageHeroSuperCastDamage = data.fireMageHeroSuperCastDamage;
            fireMageHeroRange = data.fireMageHeroRange;
            fireMageHeroWalkSpeed = data.fireMageHeroWalkSpeed;
            fireMageHeroTrainSpeed = data.fireMageHeroTrainSpeed;
            fireMageHeroCritRate = data.fireMageHeroCritRate;
            fireMageHeroCritMin = data.fireMageHeroCritMin;
            fireMageHeroCritMax = data.fireMageHeroCritMax;
            fireMageHeroTrainCost = data.fireMageHeroTrainCost;
            fireMageHeroFireRate = data.fireMageHeroFireRate;
            fireMageHeroCastRate = data.fireMageHeroCastRate;
            fireMageHeroSuperCastRate = data.fireMageHeroSuperCastRate;
           

            boltMageHeroHealth = data.boltMageHeroHealth;
            boltMageHeroShootDamage = data.boltMageHeroShootDamage;
            boltMageHeroNormalCastDamage = data.boltMageHeroNormalCastDamage;
            boltMageHeroSuperCastDamage = data.boltMageHeroSuperCastDamage;
            boltMageHeroRange = data.boltMageHeroRange;
            boltMageHeroWalkSpeed = data.boltMageHeroWalkSpeed;
            boltMageHeroTrainSpeed = data.boltMageHeroTrainSpeed;
            boltMageHeroCritRate = data.boltMageHeroCritRate;
            boltMageHeroCritMin = data.boltMageHeroCritMin;
            boltMageHeroCritMax = data.boltMageHeroCritMax;
            boltMageHeroTrainCost = data.boltMageHeroTrainCost;
            boltMageHeroFireRate = data.boltMageHeroFireRate;
            boltMageHeroCastRate = data.boltMageHeroCastRate;
            boltMageHeroSuperCastRate = data.boltMageHeroSuperCastRate;
          

            natureMageHeroHealth = data.natureMageHeroHealth;
            natureMageHeroShootDamage = data.natureMageHeroShootDamage;
            natureMageHeroNormalCastDamage = data.natureMageHeroNormalCastDamage;
            natureMageHeroSuperCastDamage = data.natureMageHeroSuperCastDamage;
            natureMageHeroRange = data.natureMageHeroRange;
            natureMageHeroWalkSpeed = data.natureMageHeroWalkSpeed;
            natureMageHeroTrainSpeed = data.natureMageHeroTrainSpeed;
            natureMageHeroCritRate = data.natureMageHeroCritRate;
            natureMageHeroCritMin = data.natureMageHeroCritMin;
            natureMageHeroCritMax = data.natureMageHeroCritMax;
            natureMageHeroTrainCost = data.natureMageHeroTrainCost;
            natureMageHeroFireRate = data.natureMageHeroFireRate;
            natureMageHeroCastRate = data.natureMageHeroCastRate;
            natureMageHeroSuperCastRate = data.natureMageHeroSuperCastRate;
           





        }



    }
}