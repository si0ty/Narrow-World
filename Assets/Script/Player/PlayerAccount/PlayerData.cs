
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
using System;

namespace DTS { 

[System.Serializable]
public class PlayerData 
{


    public  string playerName;
    public  int playerLevel;

    public  int bankGold;
    public  int bankStones;
    public  int skillPoints;
    public  int epPoints;

        public DateTime timeStore;
        public bool goldReady;

        public int logins;
    public List<PlayerSkills.SkillType> unlockedSkillList;
     public List<PlayerItems.ItemType>  unlockedItemsList;
        public Dictionary<ResourceType, int> bankResources;


        //Tier1
        //Shiel
        public  int shieldHealth;
    public  int shieldDamage;
    public  int shieldCritRate;
    public  int shieldCritMin;
    public  int shieldCritMax;
    public  float shieldRange;
    public  float shieldAttackSpeed;
    public  float shieldWalkSpeed;
    public  float shieldTrainSpeed;
    public  int shieldTrainCost;


    //Broad
    public  int broadswordHealth;
    public  int broadswordDamage;
    public  int broadswordCritRate;
    public  int broadswordCritMin;
    public  int broadswordCritMax;
    public  float broadswordRange;
    public  float broadswordAttackSpeed;
    public  float broadswordWalkSpeed;
    public  float broadswordTrainSpeed;
    public  int broadswordTrainCost;

    //Runne
    public  int runnerHealth;
    public  int runnerDamage;
    public  int runnerCritRate;
    public  int runnerCritMin;
    public  int runnerCritMax;
    public  float runnerRange;
    public  float runnerWalkSpeed;
    public  float runnerAttackSpeed;
    public  float runnerRunningSpeed;
    public  float runnerTrainSpeed;
    public int runnerTrainCost;

    //Arche
    public  int archerHealth;
    public  int archerShootDamage;
    public  float archerFireRate;
        public int archerFireRange;
    public  float archerWalkSpeed;
    public  float archerTravelSpeed;
    public  float archerTrainSpeed;
    public int archerTrainCost;


    //Tier2

    //Shielin
    public  int shieldCaptainHealth;
    public  int shieldCaptainDamage;
    public  int shieldCaptainCritRate;
    public  int shieldCaptainCritMin;
    public  int shieldCaptainCritMax;
    public  float shieldCaptainRange;
    public  float shieldCaptainAttackSpeed;
    public  float shieldCaptainWalkSpeed;
    public  float shieldCaptainTrainSpeed;
    public int shieldCaptainTrainCost;

    //Broadunner
    public  int broadswordCaptainHealth;
    public  int broadswordCaptainDamage;
    public  int broadswordCaptainCritRate;
    public  int broadswordCaptainCritMin;
    public  int broadswordCaptainCritMax;
    public  float broadswordCaptainRange;
    public  float broadswordCaptainAttackSpeed;
    public  float broadswordCaptainWalkSpeed;
    public  float broadswordCaptainTrainSpeed;
    public int broadswordCaptainTrainCost;

    //Runnein
    public  int runnerCaptainHealth;
    public  int runnerCaptainDamage;
    public  int runnerCaptainCritRate;
    public  int runnerCaptainCritMin;
    public  int runnerCaptainCritMax;
    public  float runnerCaptainRange;
    public  float runnerCaptainWalkSpeed;
    public  float runnerCaptainAttackSpeed;
    public  float runnerCaptainRunningSpeed;
    public  float runnerCaptainTrainSpeed;
    public int runnerCaptainTrainCost;

    //Archein
    public  int archerCaptainHealth;
    public  int archerCaptainShootDamage;
    public  float archerCaptainFireRate;
        public int archerCaptainFireRange;
        public  float archerCaptainWalkSpeed;
    public  float archerCaptainTravelSpeed;
    public  float archerCaptainTrainSpeed;
    public int archerCaptainTrainCost;

        //Mage
        public int fireMageHealth;
        public int fireMageShootDamage;
        public int fireMageNormalCastDamage;
        public int fireMageSuperCastDamage;
        public float fireMageRange;
        public float fireMageWalkSpeed;
        public float fireMageTrainSpeed;
        public int fireMageTrainCost;
        public float fireMageCritRate;
        public float fireMageCritMin;
        public float fireMageCritMax;
        public float fireMageFireRate;
        public float fireMageCastRate;
        public float fireMageSuperCastRate;

        public int boltMageHealth;
        public int boltMageShootDamage;
        public int boltMageNormalCastDamage;
        public int boltMageSuperCastDamage;
        public float boltMageRange;
        public float boltMageWalkSpeed;
        public float boltMageTrainSpeed;
        public int boltMageTrainCost;
        public float boltMageCritRate;
        public float boltMageCritMin;
        public float boltMageCritMax;
        public float boltMageFireRate;
        public float boltMageCastRate;
        public float boltMageSuperCastRate;

        public int natureMageHealth;
        public int natureMageShootDamage;
        public int natureMageNormalCastDamage;
        public int natureMageSuperCastDamage;
        public float natureMageRange;
        public float natureMageWalkSpeed;
        public float natureMageTrainSpeed;
        public int natureMageTrainCost;
        public float natureMageCritRate;
        public float natureMageCritMin;
        public float natureMageCritMax;
        public float natureMageFireRate;
        public float natureMageCastRate;
        public float natureMageSuperCastRate;






        //Tier3

        //Shiel
        public  int shieldHeroHealth;
    public  int shieldHeroDamage;
    public  int shieldHeroCritRate;
    public  int shieldHeroCritMin;
    public  int shieldHeroCritMax;
    public  float shieldHeroRange;
    public  float shieldHeroAttackSpeed;
    public  float shieldHeroWalkSpeed;
    public  float shieldHeroTrainSpeed;
    public int shieldHeroTrainCost;

    //Broadero
    public  int broadswordHeroHealth;
    public  int broadswordHeroDamage;
    public  int broadswordHeroCritRate;
    public  int broadswordHeroCritMin;
    public  int broadswordHeroCritMax;
    public  float broadswordHeroRange;
    public  float broadswordHeroAttackSpeed;
    public  float broadswordHeroWalkSpeed;
    public  float broadswordHeroRunningSpeed;
    public  float broadswordHeroTrainSpeed;
    public int broadswordHeroTrainCost;

    //Runne
    public  int runnerHeroHealth;
    public  int runnerHeroDamage;
    public  int runnerHeroCritRate;
    public  int runnerHeroCritMin;
    public  int runnerHeroCritMax;
    public  float runnerHeroRange;
    public  float runnerHeroAttackSpeed;
    public  float runnerHeroWalkSpeed;
    public  float runnerHeroRunningSpeed;
    public  float runnerHeroTrainSpeed;
    public int runnerHeroTrainCost;


    //Arche
    public  int archerHeroHealth;
    public  int archerHeroShootDamage;
    public  float archerHeroFireRate;
        public int archerHeroFireRange;
        public  float archerHeroWalkSpeed;
    public  float archerHeroTravelSpeed;
    public  float archerHeroTrainSpeed;
    public int archerHeroTrainCost;

        //MageH
        public int fireMageHeroHealth;
        public int fireMageHeroShootDamage;
        public int fireMageHeroNormalCastDamage;
        public int fireMageHeroSuperCastDamage;
        public float fireMageHeroRange;
        public float fireMageHeroWalkSpeed;
        public float fireMageHeroTrainSpeed;
        public float fireMageHeroCritRate;
        public float fireMageHeroCritMin;
        public float fireMageHeroCritMax;
        public int fireMageHeroTrainCost;
        public float fireMageHeroFireRate;
        public float fireMageHeroCastRate;
        public float fireMageHeroSuperCastRate;


        public int boltMageHeroHealth;
        public int boltMageHeroShootDamage;
        public int boltMageHeroNormalCastDamage;
        public int boltMageHeroSuperCastDamage;
        public float boltMageHeroRange;
        public float boltMageHeroWalkSpeed;
        public float boltMageHeroTrainSpeed;
        public int boltMageHeroTrainCost;
        public float boltMageHeroCritRate;
        public float boltMageHeroCritMin;
        public float boltMageHeroCritMax;
        public float boltMageHeroFireRate;
        public float boltMageHeroCastRate;
        public float boltMageHeroSuperCastRate;

        public int natureMageHeroHealth;
        public int natureMageHeroShootDamage;
        public int natureMageHeroNormalCastDamage;
        public int natureMageHeroSuperCastDamage;
        public float natureMageHeroRange;
        public float natureMageHeroWalkSpeed;
        public float natureMageHeroTrainSpeed;
        public int natureMageHeroTrainCost;
        public float natureMageHeroCritRate;
        public float natureMageHeroCritMin;
        public float natureMageHeroCritMax;
        public float natureMageHeroFireRate;
        public float natureMageHeroCastRate;
        public float natureMageHeroSuperCastRate;








        public PlayerData(PlayerResourceManager resourceManager) {

            unlockedSkillList = resourceManager.unlockedSkillList;
            unlockedItemsList = resourceManager.unlockedItemsList;

            bankResources = resourceManager.bankResources;

           playerName = resourceManager.playerName;
           playerLevel = resourceManager.playerLevel;
            logins = resourceManager.logins;
            timeStore = resourceManager.timeStore;
            goldReady = resourceManager.goldReady;

         shieldHealth = resourceManager.  shieldHealth;
        shieldDamage = resourceManager.  shieldDamage;
          shieldCritRate = resourceManager.  shieldCritRate;
        shieldCritMin = resourceManager.  shieldCritMin;
        shieldCritMax = resourceManager.  shieldCritMax;
        shieldRange = resourceManager.  shieldRange;
         shieldAttackSpeed = resourceManager.  shieldAttackSpeed;
        shieldWalkSpeed = resourceManager.  shieldWalkSpeed;
        shieldTrainSpeed = resourceManager.  shieldTrainSpeed;
        shieldTrainCost = resourceManager.  shieldTrainCost;

        broadswordHealth = resourceManager.  broadswordHealth;
        broadswordDamage = resourceManager.  broadswordDamage;
        broadswordCritRate = resourceManager.  broadswordCritRate;
        broadswordCritMin =  resourceManager.  broadswordCritMin;
        broadswordCritMax = resourceManager.  broadswordCritMax;
        broadswordRange =  resourceManager.  broadswordRange;
        broadswordAttackSpeed = resourceManager.  broadswordAttackSpeed;
        broadswordWalkSpeed = resourceManager.  broadswordWalkSpeed;
        broadswordTrainSpeed = resourceManager.  broadswordTrainSpeed;
        broadswordTrainCost = resourceManager.  broadswordTrainCost;

        runnerHealth = resourceManager.  runnerHealth;
        runnerDamage = resourceManager.  runnerDamage;
        runnerCritRate = resourceManager.  runnerCritRate;
        runnerCritMin = resourceManager.  runnerCritMin;
        runnerCritMax = resourceManager.  runnerCritMax;
        runnerRange = resourceManager.  runnerRange;
        runnerWalkSpeed = resourceManager.  runnerWalkSpeed;
        runnerAttackSpeed = resourceManager.  runnerAttackSpeed;
        runnerRunningSpeed = resourceManager.  runnerRunningSpeed;
        runnerTrainSpeed = resourceManager.  runnerTrainSpeed;
        runnerTrainCost = resourceManager.  runnerTrainCost;

        archerHealth = resourceManager.  archerHealth;
        archerShootDamage = resourceManager.  archerShootDamage;
        archerFireRate = resourceManager.  archerFireRate;
        archerWalkSpeed = resourceManager.  archerWalkSpeed;
        archerTravelSpeed = resourceManager.  archerTravelSpeed;
        archerTrainSpeed = resourceManager.  archerTrainSpeed;
        archerTrainCost = resourceManager.  archerTrainCost;

        shieldCaptainHealth = resourceManager.  shieldCaptainHealth;
        shieldCaptainDamage = resourceManager.  shieldCaptainDamage;
        shieldCaptainCritRate = resourceManager.  shieldCaptainCritRate;
        shieldCaptainCritMin = resourceManager.  shieldCaptainCritMin;
        shieldCaptainCritMax = resourceManager.  shieldCaptainCritMax;
        shieldCaptainRange = resourceManager.  shieldCaptainRange;
        shieldCaptainAttackSpeed = resourceManager.  shieldCaptainAttackSpeed;
        shieldCaptainWalkSpeed = resourceManager.  shieldCaptainWalkSpeed;
        shieldCaptainTrainSpeed = resourceManager.  shieldCaptainTrainSpeed;
        shieldCaptainTrainCost = resourceManager.  shieldCaptainTrainCost;

        broadswordCaptainHealth = resourceManager.  broadswordCaptainHealth;
        broadswordCaptainDamage = resourceManager.  broadswordCaptainDamage;
        broadswordCaptainCritRate = resourceManager.  broadswordCaptainCritRate;
        broadswordCaptainCritMin = resourceManager.  broadswordCaptainCritMin;
        broadswordCaptainCritMax = resourceManager.  broadswordCaptainCritMax;
        broadswordCaptainRange = resourceManager.  broadswordCaptainRange;
        broadswordCaptainAttackSpeed = resourceManager.  broadswordCaptainAttackSpeed;
        broadswordCaptainWalkSpeed = resourceManager.  broadswordCaptainWalkSpeed;
        broadswordCaptainTrainSpeed = resourceManager.  broadswordCaptainTrainSpeed;
        broadswordCaptainTrainCost = resourceManager.  broadswordCaptainTrainCost;

        runnerCaptainHealth = resourceManager.  runnerCaptainHealth;
        runnerCaptainDamage = resourceManager.  runnerCaptainDamage;
        runnerCaptainCritRate = resourceManager.  runnerCaptainCritRate;
        runnerCaptainCritMin = resourceManager.  runnerCaptainCritMin;
        runnerCaptainCritMax = resourceManager.  runnerCaptainCritMax;
        runnerCaptainRange = resourceManager.  runnerCaptainRange;
        runnerCaptainWalkSpeed = resourceManager.  runnerCaptainWalkSpeed;
        runnerCaptainAttackSpeed = resourceManager.  runnerCaptainAttackSpeed;
        runnerCaptainRunningSpeed = resourceManager.  runnerCaptainRunningSpeed;
        runnerCaptainTrainSpeed = resourceManager.  runnerCaptainTrainSpeed;
        runnerCaptainTrainCost =  resourceManager.  runnerCaptainTrainCost;

        archerCaptainHealth = resourceManager.  archerCaptainHealth;
        archerCaptainShootDamage = resourceManager.  archerCaptainShootDamage;
        archerCaptainFireRate =  resourceManager.  archerCaptainFireRate;
        archerCaptainWalkSpeed = resourceManager.  archerCaptainWalkSpeed;
        archerCaptainTravelSpeed =  resourceManager.  archerCaptainTravelSpeed;
        archerCaptainTrainSpeed = resourceManager.  archerCaptainTrainSpeed;
        archerCaptainTrainCost = resourceManager.  archerCaptainTrainCost;

        fireMageHealth = resourceManager.fireMageHealth;
        fireMageShootDamage = resourceManager.fireMageShootDamage;
        fireMageNormalCastDamage = resourceManager.fireMageNormalCastDamage;
        fireMageSuperCastDamage = resourceManager.fireMageSuperCastDamage;
        fireMageRange = resourceManager.fireMageRange;
        fireMageWalkSpeed = resourceManager.fireMageWalkSpeed;
        fireMageTrainSpeed = resourceManager.fireMageTrainSpeed;
        fireMageTrainCost = resourceManager.fireMageTrainCost;
        fireMageCritRate = resourceManager.fireMageCritRate;
        fireMageCritMin = resourceManager.fireMageCritMin;
        fireMageCritMax = resourceManager.fireMageCritMax;
        fireMageFireRate = resourceManager.fireMageFireRate;
        fireMageSuperCastRate = resourceManager.fireMageSuperCastRate;

            boltMageHealth = resourceManager.boltMageHealth;
            boltMageShootDamage = resourceManager.boltMageShootDamage;
            boltMageNormalCastDamage = resourceManager.boltMageNormalCastDamage;
            boltMageSuperCastDamage = resourceManager.boltMageSuperCastDamage;
            boltMageRange = resourceManager.boltMageRange;
            boltMageWalkSpeed = resourceManager.boltMageWalkSpeed;
            boltMageTrainSpeed = resourceManager.boltMageTrainSpeed;
            boltMageTrainCost = resourceManager.boltMageTrainCost;
            boltMageCritRate = resourceManager.boltMageCritRate;
            boltMageCritMin = resourceManager.boltMageCritMin;
            boltMageCritMax = resourceManager.boltMageCritMax;
            boltMageFireRate = resourceManager.boltMageFireRate;
            boltMageSuperCastRate = resourceManager.boltMageSuperCastRate;

            natureMageHealth = resourceManager.natureMageHealth;
            natureMageShootDamage = resourceManager.natureMageShootDamage;
            natureMageNormalCastDamage = resourceManager.natureMageNormalCastDamage;
            natureMageSuperCastDamage = resourceManager.natureMageSuperCastDamage;
            natureMageRange = resourceManager.natureMageRange;
            natureMageWalkSpeed = resourceManager.natureMageWalkSpeed;
            natureMageTrainSpeed = resourceManager.natureMageTrainSpeed;
            natureMageTrainCost = resourceManager.natureMageTrainCost;
            natureMageCritRate = resourceManager.natureMageCritRate;
            natureMageCritMin = resourceManager.natureMageCritMin;
            natureMageCritMax = resourceManager.natureMageCritMax;
            natureMageFireRate = resourceManager.natureMageFireRate;
            natureMageSuperCastRate = resourceManager.natureMageSuperCastRate;
            





            //Tier3:

            //ShieldHero
            shieldHeroHealth = resourceManager.shieldHeroHealth;
        shieldHeroDamage = resourceManager.shieldHeroDamage;
        shieldHeroCritRate = resourceManager.shieldHeroCritRate;
        shieldHeroCritMin = resourceManager.shieldHeroCritMin;
        shieldHeroCritMax = resourceManager.shieldHeroCritMax;
        shieldHeroRange = resourceManager.shieldHeroRange;
        shieldHeroAttackSpeed = resourceManager.shieldHeroAttackSpeed;
        shieldHeroWalkSpeed = resourceManager.shieldHeroWalkSpeed;
        shieldHeroTrainSpeed = resourceManager.shieldHeroTrainSpeed;
        shieldHeroTrainCost = resourceManager.shieldHeroTrainCost;

        //BroadswordHero
        broadswordHeroHealth = resourceManager.broadswordHeroHealth;
        broadswordHeroDamage = resourceManager.broadswordHeroDamage;
        broadswordHeroCritRate = resourceManager.broadswordHeroCritRate;
        broadswordHeroCritMin = resourceManager.broadswordHeroCritMin;
        broadswordHeroCritMax = resourceManager.broadswordHeroCritMax;
        broadswordHeroRange = resourceManager.broadswordHeroRange;
        broadswordHeroAttackSpeed = resourceManager.broadswordHeroAttackSpeed;
        broadswordHeroWalkSpeed = resourceManager.broadswordHeroWalkSpeed;
        broadswordHeroRunningSpeed = resourceManager.broadswordHeroRunningSpeed;
        broadswordHeroTrainSpeed = resourceManager.broadswordHeroTrainSpeed;
        broadswordHeroTrainCost = resourceManager.broadswordHeroTrainCost;

          //RunnerHero
        runnerHeroHealth = resourceManager.runnerHeroHealth;
        runnerHeroDamage = resourceManager.runnerHeroDamage;
        runnerHeroCritRate = resourceManager.runnerHeroCritRate;
        runnerHeroCritMin = resourceManager.runnerHeroCritMin;
        runnerHeroCritMax = resourceManager.runnerHeroCritMax;
        runnerHeroRange = resourceManager.runnerHeroRange;
        runnerHeroAttackSpeed = resourceManager.runnerHeroAttackSpeed;
        runnerHeroWalkSpeed = resourceManager.runnerHeroWalkSpeed;
        runnerHeroRunningSpeed = resourceManager.runnerHeroRunningSpeed;
        runnerHeroTrainSpeed = resourceManager.runnerHeroTrainSpeed;
        runnerHeroTrainCost = resourceManager.runnerHeroTrainCost;


        //ArcherHero
        archerHeroHealth = resourceManager.archerHeroHealth;
        archerHeroShootDamage = resourceManager.archerHeroShootDamage;
        archerHeroFireRate = resourceManager.archerHeroFireRate;
        archerHeroWalkSpeed = resourceManager.archerHeroWalkSpeed;
        archerHeroTravelSpeed = resourceManager.archerHeroTravelSpeed;
        archerHeroTrainSpeed = resourceManager.archerHeroTrainSpeed;
        archerHeroTrainCost = resourceManager.archerHeroTrainCost;

        //MageHero
               fireMageHeroHealth = resourceManager.fireMageHeroHealth;
          fireMageHeroShootDamage = resourceManager.fireMageHeroShootDamage;
        fireMageHeroNormalCastDamage = resourceManager.fireMageHeroNormalCastDamage;
        fireMageHeroSuperCastDamage = resourceManager.fireMageHeroSuperCastDamage;
        fireMageHeroRange =         resourceManager.fireMageHeroRange;
        fireMageHeroWalkSpeed =     resourceManager.fireMageHeroWalkSpeed;
        fireMageHeroTrainSpeed =    resourceManager.fireMageHeroTrainSpeed;
        fireMageHeroCritRate =      resourceManager.fireMageHeroCritRate;
        fireMageHeroCritMin =       resourceManager.fireMageHeroCritMin;
        fireMageHeroCritMax =       resourceManager.fireMageHeroCritMax;
        fireMageHeroTrainCost =     resourceManager.fireMageHeroTrainCost;
        fireMageHeroFireRate =      resourceManager.fireMageHeroFireRate;
        fireMageHeroCastRate =      resourceManager.fireMageHeroCastRate;
        fireMageHeroSuperCastRate = resourceManager.fireMageHeroSuperCastRate;

            boltMageHeroHealth = resourceManager.boltMageHeroHealth;
            boltMageHeroShootDamage = resourceManager.boltMageHeroShootDamage;
            boltMageHeroNormalCastDamage = resourceManager.boltMageHeroNormalCastDamage;
            boltMageHeroSuperCastDamage = resourceManager.boltMageHeroSuperCastDamage;
            boltMageHeroRange = resourceManager.boltMageHeroRange;
            boltMageHeroWalkSpeed = resourceManager.boltMageHeroWalkSpeed;
            boltMageHeroTrainSpeed = resourceManager.boltMageHeroTrainSpeed;
            boltMageHeroCritRate = resourceManager.boltMageHeroCritRate;
            boltMageHeroCritMin = resourceManager.boltMageHeroCritMin;
            boltMageHeroCritMax = resourceManager.boltMageHeroCritMax;
            boltMageHeroTrainCost = resourceManager.boltMageHeroTrainCost;
            boltMageHeroFireRate = resourceManager.boltMageHeroFireRate;
            boltMageHeroCastRate = resourceManager.boltMageHeroCastRate;
            boltMageHeroSuperCastRate = resourceManager.boltMageHeroSuperCastRate;

            natureMageHeroHealth = resourceManager.natureMageHeroHealth;
            natureMageHeroShootDamage = resourceManager.natureMageHeroShootDamage;
            natureMageHeroNormalCastDamage = resourceManager.natureMageHeroNormalCastDamage;
            natureMageHeroSuperCastDamage = resourceManager.natureMageHeroSuperCastDamage;
            natureMageHeroRange = resourceManager.natureMageHeroRange;
            natureMageHeroWalkSpeed = resourceManager.natureMageHeroWalkSpeed;
            natureMageHeroTrainSpeed = resourceManager.natureMageHeroTrainSpeed;
            natureMageHeroCritRate = resourceManager.natureMageHeroCritRate;
            natureMageHeroCritMin = resourceManager.natureMageHeroCritMin;
            natureMageHeroCritMax = resourceManager.natureMageHeroCritMax;
            natureMageHeroTrainCost = resourceManager.natureMageHeroTrainCost;
            natureMageHeroFireRate = resourceManager.natureMageHeroFireRate;
            natureMageHeroCastRate = resourceManager.natureMageHeroCastRate;
            natureMageHeroSuperCastRate = resourceManager.natureMageHeroSuperCastRate;
        }     


}

}
