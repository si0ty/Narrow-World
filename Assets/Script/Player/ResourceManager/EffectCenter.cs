using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;

public class EffectCenter : MonoBehaviour
{
    public bool t1, t2, t3;


    public bool runnerDamage, broadswordDamage, shieldDamage, archerDamage, archerTrainSpeed, mageTrainSpeed, meleeTrainSpeed, archerFireRate, archerTravelSpeed, archerHealth, meleeMovement,
        meleeCritMax, meleeCritRate, archerMovement, archerTrainingCost, meleeTrainingCost, mageMovement, lifeSteal, meleeHealth, mageHealth, randomEffect, meleeAttackSpeed, longswordHealth, shieldHealth, longswordWalkspeed
        , shieldWalkspeed, runnerHealth, runnerMovement, archerPushbackIncrease, shieldPushbackDecrease, runnerTraincost, longswordCritRate, runnerCritRate, shieldCritRate, longswordCritMax, runnerCritMax, shieldTrainCost, longswordAttackspeed,
        runnerCritMin, longswordCritMin, shieldCritMin, iceSlow, redStone,


        broadswordRange, shieldRange, runnerRange,

        natureMageRange, fireMageRange, boltMageRange, 

        boltMageCritMax, natureMageCritMax, fireMageCritMax, 

        boltMageCritRate, natureMageCritRate, fireMageCritRate,
    
        boltMageSpellDamage, natureMageSpellDamage, fireMageSpellDamage,

         boltMageShootDamage, natureMageShootDamage, fireMageShootDamage,

        

          boltMageFireRate, natureMageFireRate, fireMageFireRate,

          boltMageCastRate, natureMageCastRate, fireMageCastRate,

         boltMageSuperCastRate, natureMageSuperCastRate, fireMageSuperCastRate


        ;



    public PlayerResourceManager resourceManager; 

    public enum SkillCategorie
    {
        Shortsword, 
        Broadsword,
        Shield,
        Archery,
        Fire,
        Bolt,
        Nature,
        Movement,
        Lifesteal

    }

    private void Start() {

        resourceManager = GameObject.Find("Player").GetComponent<PlayerResourceManager>();

    }

    public void UpgradeLevel1(int percentage) {


        if(shieldPushbackDecrease) {
            float value = GetFloatPercentage(resourceManager.shieldPushback, percentage);
            resourceManager.shieldPushback += value;
        }


        if (archerPushbackIncrease) {
            float value = GetFloatPercentage(resourceManager.archerPushback, percentage);
            resourceManager.archerPushback += value;
        }




        if (meleeAttackSpeed) {
            float value = GetFloatPercentage(resourceManager.runnerAttackSpeed, percentage);
            Debug.Log("Increased Runner Attack Speed from: " + resourceManager.runnerAttackSpeed.ToString() + " => " + resourceManager.runnerAttackSpeed.ToString() + " + " + value.ToString());
            resourceManager.runnerAttackSpeed += value;
           

            float value2 = GetFloatPercentage(resourceManager.shieldAttackSpeed, percentage);
            Debug.Log("Increased Shield Attack Speed from: " + resourceManager.shieldAttackSpeed.ToString() + " => " + resourceManager.shieldAttackSpeed.ToString() + " + " + value2.ToString());
            resourceManager.shieldAttackSpeed += value2;

            float value3 = GetFloatPercentage(resourceManager.broadswordAttackSpeed, percentage);
            Debug.Log("Increased Broadsword Attack Speed from: " + resourceManager.broadswordAttackSpeed.ToString() + " => " + resourceManager.broadswordAttackSpeed.ToString() + " + " + value3.ToString());
            resourceManager.broadswordAttackSpeed += value3;
        }

        if(broadswordRange) {
            float value = GetFloatPercentage(resourceManager.broadswordRange, percentage);
            resourceManager.broadswordRange += value;
        }

        if (shieldRange) {
            float value = GetFloatPercentage(resourceManager.shieldRange, percentage);
            resourceManager.shieldRange += value;
        }

        if (shieldRange) {
            float value = GetFloatPercentage(resourceManager.runnerRange, percentage);
            resourceManager.runnerRange += value;
        }


        if(archerTrainingCost) {
            int value = GetPercentage(resourceManager.archerTrainCost, percentage);
            resourceManager.archerTrainCost -= value;

        }


        if (meleeTrainingCost) {
            int value = GetPercentage(resourceManager.broadswordTrainCost, percentage);
            resourceManager.broadswordTrainCost -= value;

            int value2 = GetPercentage(resourceManager.shieldTrainCost, percentage);
            resourceManager.shieldTrainCost -= value2;

            int value3 = GetPercentage(resourceManager.runnerTrainCost, percentage);
            resourceManager.runnerTrainCost -= value3;

        }

        if(randomEffect) {

        }
        //More to add and then transfer to further upgrade levels

    

       if(archerTrainSpeed) {
            float value = GetFloatPercentage(resourceManager.archerTrainSpeed, percentage);
            Debug.Log("Increased Runner Trainspeed from: " + resourceManager.archerTrainSpeed.ToString() + " => " + resourceManager.archerTrainSpeed.ToString() + " + " + value.ToString());
            resourceManager.archerTrainSpeed += value;
        }

        if (mageTrainSpeed) {
            float value = GetFloatPercentage(resourceManager.fireMageTrainSpeed, percentage);
            resourceManager.fireMageTrainSpeed -= value;

            float value2 = GetFloatPercentage(resourceManager.boltMageTrainSpeed, percentage);
            resourceManager.boltMageTrainSpeed -= value2;

            float value3 = GetFloatPercentage(resourceManager.natureMageTrainSpeed, percentage);
            resourceManager.natureMageTrainSpeed -= value3;

        }

        if (meleeTrainSpeed) {
            float value = GetFloatPercentage(resourceManager.runnerTrainSpeed, percentage);
            Debug.Log("Increased Runner Trainspeed from: " + resourceManager.runnerTrainSpeed.ToString() + " => " + resourceManager.runnerTrainSpeed.ToString() + " + " + value.ToString());
            resourceManager.runnerTrainSpeed -= value;


            float value2 = GetFloatPercentage(resourceManager.shieldTrainSpeed, percentage);
            Debug.Log("Increased Shield Attack Speed from: " + resourceManager.shieldTrainSpeed.ToString() + " => " + resourceManager.shieldTrainSpeed.ToString() + " + " + value2.ToString());
            resourceManager.shieldTrainSpeed -= value2;

            float value3 = GetFloatPercentage(resourceManager.broadswordTrainSpeed, percentage);
            Debug.Log("Increased Broadsword Attack Speed from: " + resourceManager.broadswordTrainSpeed.ToString() + " => " + resourceManager.broadswordTrainSpeed.ToString() + " + " + value3.ToString());
            resourceManager.broadswordTrainSpeed -= value3;
        }


        if (runnerTraincost) {
            float value = GetFloatPercentage(resourceManager.runnerTrainCost, percentage);
            Debug.Log("Increased Runner Trainspeed from: " + resourceManager.runnerTrainCost.ToString() + " => " + resourceManager.runnerTrainCost.ToString() + " + " + value.ToString());
            resourceManager.runnerTrainCost -= (int)value;

        }

        if (shieldTrainCost) {
            float value = GetFloatPercentage(resourceManager.shieldTrainCost, percentage);
            resourceManager.shieldTrainCost -= (int)value;

        }

        if (runnerDamage) {
            int value = GetPercentage(resourceManager.runnerDamage, percentage);
            Debug.Log("Increased Runner Attack Damage from: " + resourceManager.runnerDamage.ToString() + " => " + resourceManager.runnerDamage.ToString() + " + " + value.ToString());
            resourceManager.runnerDamage -= value;
         
        }

        //Broadsword
        if(broadswordDamage) {
            int value = GetPercentage(resourceManager.broadswordDamage, percentage);
            Debug.Log("Increased Broadsword Attack Damage from: " + resourceManager.broadswordDamage.ToString() + " => " + resourceManager.broadswordDamage.ToString() + " + " + value.ToString());
            resourceManager.broadswordDamage += value;          
        }

        if (shieldDamage) {
            int value = GetPercentage(resourceManager.shieldDamage, percentage);
            Debug.Log("Increased Shield Attack Damage from: " + resourceManager.shieldDamage.ToString() + " => " + resourceManager.shieldDamage.ToString() + " + " + value.ToString());
            resourceManager.shieldDamage += value;
        }   



        if (archerDamage) {
            int value = GetPercentage(resourceManager.archerShootDamage, percentage);
            Debug.Log("Increased Archer Attack Damage from: " + resourceManager.archerShootDamage.ToString() + " => " + resourceManager.archerShootDamage.ToString() + " + " + value.ToString());
            resourceManager.archerShootDamage += value;
        }

        if (archerFireRate) {
            int value = GetPercentage(resourceManager.archerShootDamage, percentage);
            resourceManager.archerShootDamage -= value;
        }

        if (meleeCritRate) {
            int value = GetPercentage(resourceManager.runnerCritRate, percentage);
            resourceManager.runnerCritRate -= value;

            int value2 = GetPercentage(resourceManager.shieldCritRate, percentage);
            resourceManager.shieldCritRate -= value2;

            int value3 = GetPercentage(resourceManager.broadswordCritRate, percentage);
            resourceManager.broadswordCritRate -= value3;

        }

        if (longswordCritRate) {
            int value3 = GetPercentage(resourceManager.broadswordCritRate, percentage);
            resourceManager.broadswordCritRate -= value3;
        }


        if (longswordCritMax) {
            int value3 = GetPercentage(resourceManager.broadswordCritMax, percentage);
            resourceManager.broadswordCritMax += value3;
        }


        if (runnerCritRate) {
            int value3 = GetPercentage(resourceManager.runnerCritRate, percentage);
            resourceManager.runnerCritRate -= value3;
        }


        if (runnerCritMax) {
            int value3 = GetPercentage(resourceManager.runnerCritMax, percentage);
            resourceManager.runnerCritMax = value3;
        }



        if (meleeCritMax) {
            int value = GetPercentage(resourceManager.runnerCritMax, percentage);
            resourceManager.runnerCritMax += value;

            int value2 = GetPercentage(resourceManager.shieldCritMax, percentage);
            resourceManager.shieldCritMax += value2;

            int value3 = GetPercentage(resourceManager.broadswordCritMax, percentage);
            resourceManager.broadswordCritMax += value3;
        }




        if (mageHealth) {
            int value = GetPercentage(resourceManager.fireMageHealth, percentage);
            resourceManager.fireMageHealth += value;

            int value2 = GetPercentage(resourceManager.boltMageHealth, percentage);
            resourceManager.boltMageHealth += value2;

            int value3 = GetPercentage(resourceManager.natureMageHealth, percentage);
            resourceManager.natureMageHealth += value3;
        }


        if (archerHealth) {
            int value = GetPercentage(resourceManager.archerHealth, percentage);
            resourceManager.archerHealth += value;
        }


        if (meleeHealth) {
            int value = GetPercentage(resourceManager.broadswordHealth, percentage);
            resourceManager.broadswordHealth += value;

            int value2 = GetPercentage(resourceManager.runnerHealth, percentage);
            resourceManager.runnerHealth += value2;

            int value3 = GetPercentage(resourceManager.shieldHealth, percentage);
            resourceManager.shieldHealth += value3;
        }


        if (longswordHealth) {
            int value = GetPercentage(resourceManager.broadswordHealth, percentage);
            resourceManager.broadswordHealth += value;

       
        }





        if (shieldHealth) {
            int value = GetPercentage(resourceManager.shieldHealth, percentage);
            resourceManager.shieldHealth += value;


        }


        if (runnerHealth) {
            int value = GetPercentage(resourceManager.runnerHealth, percentage);
            resourceManager.runnerHealth += value;


        }




        if (meleeMovement) {
            float value = GetFloatPercentage(resourceManager.shieldWalkSpeed, percentage);
            resourceManager.shieldWalkSpeed += value;

            float value2 = GetFloatPercentage(resourceManager.broadswordWalkSpeed, percentage);
            resourceManager.broadswordWalkSpeed += value2;

            float value3 = GetFloatPercentage(resourceManager.runnerWalkSpeed, percentage);
            resourceManager.runnerWalkSpeed += value3;    
        }



        if (longswordWalkspeed) {
            float value = GetFloatPercentage(resourceManager.broadswordWalkSpeed, percentage);
            resourceManager.broadswordWalkSpeed += value;

  
        }


        if (shieldWalkspeed) {
            float value = GetFloatPercentage(resourceManager.shieldWalkSpeed, percentage);
            resourceManager.shieldWalkSpeed += value;


        }


        if (runnerMovement) {
            float value = GetFloatPercentage(resourceManager.runnerWalkSpeed, percentage);
            resourceManager.runnerWalkSpeed += value;


        }



        if (archerMovement) {
            float value = GetFloatPercentage(resourceManager.archerWalkSpeed, percentage);
            resourceManager.archerWalkSpeed += value;    
        }

        if(mageMovement) {
            float value = GetFloatPercentage(resourceManager.fireMageWalkSpeed, percentage);
            resourceManager.fireMageWalkSpeed += value;

            float value2 = GetFloatPercentage(resourceManager.boltMageWalkSpeed, percentage);
            resourceManager.boltMageWalkSpeed += value2;

            float value3 = GetFloatPercentage(resourceManager.natureMageWalkSpeed, percentage);
            resourceManager.natureMageWalkSpeed += value3;
        }

        if(archerTravelSpeed) {
            float value = GetFloatPercentage(resourceManager.archerTravelSpeed, percentage);
            resourceManager.shieldWalkSpeed += value;
        }

      
    }


   

    public void UpgradeLevel2(int percentage) {


        if (iceSlow) {

        }

        if (meleeAttackSpeed) {
            float value = GetFloatPercentage(resourceManager.runnerCaptainAttackSpeed, percentage);
            resourceManager.runnerCaptainAttackSpeed += value;
            float value2 = GetFloatPercentage(resourceManager.shieldCaptainAttackSpeed, percentage);
            resourceManager.shieldCaptainAttackSpeed += value2;
            float value3 = GetFloatPercentage(resourceManager.broadswordCaptainAttackSpeed, percentage);
            resourceManager.broadswordCaptainAttackSpeed += value3;
        }

        if(longswordAttackspeed) {
            float value3 = GetFloatPercentage(resourceManager.broadswordCaptainAttackSpeed, percentage);
            resourceManager.broadswordCaptainAttackSpeed += value3;
        }

        if (broadswordRange) {
            float value = GetFloatPercentage(resourceManager.broadswordCaptainRange, percentage);
            resourceManager.broadswordCaptainRange += value;
        }

        if (shieldRange) {
            float value = GetFloatPercentage(resourceManager.shieldCaptainRange, percentage);
            resourceManager.shieldCaptainRange += value;
        }

        if (shieldRange) {
            float value = GetFloatPercentage(resourceManager.runnerCaptainRange, percentage);
            resourceManager.runnerCaptainRange += value;
        }




        if (fireMageFireRate) {
            float value = GetFloatPercentage(resourceManager.fireMageFireRate, percentage);
            resourceManager.fireMageFireRate -= value;
        }

        if (natureMageFireRate) {
            float value = GetFloatPercentage(resourceManager.natureMageFireRate, percentage);
            resourceManager.natureMageFireRate -= value;
        }

        if (boltMageFireRate) {
            float value = GetFloatPercentage(resourceManager.boltMageFireRate, percentage);
            resourceManager.boltMageFireRate -= value;
        }


        if (fireMageCastRate) {
            float value = GetFloatPercentage(resourceManager.fireMageCastRate, percentage);
            resourceManager.fireMageCastRate -= value;
        }

        if (natureMageCastRate) {
            float value = GetFloatPercentage(resourceManager.natureMageCastRate, percentage);
            resourceManager.natureMageCastRate -= value;
        }

        if (boltMageCastRate) {
            float value = GetFloatPercentage(resourceManager.boltMageCastRate, percentage);
            resourceManager.boltMageCastRate -= value;
        }

        if (fireMageSuperCastRate) {
            float value = GetFloatPercentage(resourceManager.fireMageSuperCastRate, percentage);
            resourceManager.fireMageSuperCastRate -= value;
        }

        if (natureMageSuperCastRate) {
            float value = GetFloatPercentage(resourceManager.natureMageSuperCastRate, percentage);
            resourceManager.natureMageSuperCastRate -= value;
        }

        if (boltMageSuperCastRate) {
            float value = GetFloatPercentage(resourceManager.boltMageSuperCastRate, percentage);
            resourceManager.boltMageSuperCastRate -= value;
        }





        if (fireMageCritMax) {
            float value = GetFloatPercentage(resourceManager.fireMageCritMax, percentage);
            resourceManager.fireMageCritMax += value;
        }

        if (boltMageCritMax) {
            float value = GetFloatPercentage(resourceManager.boltMageCritMax, percentage);
            resourceManager.boltMageCritMax += value;
        }

        if (natureMageCritMax) {
            float value = GetFloatPercentage(resourceManager.natureMageCritMax, percentage);
            resourceManager.natureMageCritMax += value;
        }

        if (fireMageCritRate) {
            float value = GetFloatPercentage(resourceManager.fireMageCritRate, percentage);
            resourceManager.fireMageCritRate -= value;
        }

        if (boltMageCritRate) {
            float value = GetFloatPercentage(resourceManager.boltMageCritRate, percentage);
            resourceManager.boltMageCritRate -= value;
        }

        if (natureMageCritRate) {
            float value = GetFloatPercentage(resourceManager.natureMageCritRate, percentage);
            resourceManager.natureMageCritRate -= value;
        }



        if (longswordCritRate) {
            int value3 = GetPercentage(resourceManager.broadswordCaptainCritRate, percentage);
            resourceManager.broadswordCaptainCritRate -= value3;
        }


        if (longswordCritMax) {
            int value3 = GetPercentage(resourceManager.broadswordCaptainCritMax, percentage);
            resourceManager.broadswordCaptainCritMax += value3;
        }


        if (runnerCritRate) {
            int value3 = GetPercentage(resourceManager.runnerCaptainCritRate, percentage);
            resourceManager.runnerCaptainCritRate -= value3;
        }


        if (runnerCritMax) {
            int value3 = GetPercentage(resourceManager.runnerCaptainCritMax, percentage);
            resourceManager.runnerCaptainCritMax += value3;
        }


        if (shieldCritRate) {
            int value3 = GetPercentage(resourceManager.shieldCritRate, percentage);
            resourceManager.shieldCritRate -= value3;
        }

        if(longswordCritMin){
            int value3 = GetPercentage(resourceManager.broadswordCaptainCritMin, percentage);
            resourceManager.broadswordCaptainCritMin += value3;
        }

        if (runnerCritMin) {
            int value3 = GetPercentage(resourceManager.runnerCaptainCritMin, percentage);
            resourceManager.runnerCaptainCritMin += value3;
        }

        if (shieldCritMin) {
            int value3 = GetPercentage(resourceManager.shieldCaptainCritMin, percentage);
            resourceManager.shieldCaptainCritMin += value3;
        }





        if (natureMageRange) {
            float value = GetFloatPercentage(resourceManager.natureMageRange, percentage);
            resourceManager.natureMageRange += value;

        }

        if (fireMageRange) {
            float value = GetFloatPercentage(resourceManager.fireMageRange, percentage);
            resourceManager.fireMageRange += value;

        }

        if (boltMageRange) {
            float value = GetFloatPercentage(resourceManager.boltMageRange, percentage);
            resourceManager.boltMageRange += value;

        }


        if (archerTrainingCost) {
            int value = GetPercentage(resourceManager.archerCaptainTrainCost, percentage);
            resourceManager.archerCaptainTrainCost -= value;

        }


        if (meleeTrainingCost) {
            int value = GetPercentage(resourceManager.broadswordCaptainTrainCost, percentage);
            resourceManager.broadswordCaptainTrainCost -= value;
            int value2 = GetPercentage(resourceManager.shieldCaptainTrainCost, percentage); resourceManager.shieldCaptainTrainCost -= value2;
            int value3 = GetPercentage(resourceManager.runnerCaptainTrainCost, percentage); resourceManager.runnerCaptainTrainCost -= value3;

        }

        if (randomEffect) {

        }
        //More to add and then transfer to further upgrade levels
        if (archerTrainSpeed) {
            float value = GetFloatPercentage(resourceManager.archerCaptainTrainSpeed, percentage);
            resourceManager.archerCaptainTrainSpeed -= value;
        }

        if (mageTrainSpeed) {
            float value = GetFloatPercentage(resourceManager.fireMageTrainSpeed, percentage);
            resourceManager.fireMageTrainSpeed -= value;
            float value2 = GetFloatPercentage(resourceManager.boltMageTrainSpeed, percentage); resourceManager.boltMageTrainSpeed -= value2;
            float value3 = GetFloatPercentage(resourceManager.natureMageTrainSpeed, percentage); resourceManager.natureMageTrainSpeed -= value3;

        }

        if (meleeTrainSpeed) {
            float value = GetFloatPercentage(resourceManager.runnerCaptainTrainSpeed, percentage);
            resourceManager.runnerCaptainTrainSpeed -= value;
            float value2 = GetFloatPercentage(resourceManager.shieldCaptainTrainSpeed, percentage);
            resourceManager.shieldCaptainTrainSpeed -= value2;
            float value3 = GetFloatPercentage(resourceManager.broadswordCaptainTrainSpeed, percentage);
            resourceManager.broadswordCaptainTrainSpeed -= value3;
        }


        if (runnerDamage) {
            int value = GetPercentage(resourceManager.runnerCaptainDamage, percentage);
            resourceManager.runnerCaptainDamage += value;
        
        }

        //BroadswordCaptain
        if (broadswordDamage) {
            int value = GetPercentage(resourceManager.broadswordCaptainDamage, percentage);
            resourceManager.broadswordCaptainDamage += value;
        }

        if (shieldDamage) {
            int value = GetPercentage(resourceManager.shieldCaptainDamage, percentage);
            resourceManager.shieldCaptainDamage += value;
        }



        if (archerDamage) {
            int value = GetPercentage(resourceManager.archerCaptainShootDamage, percentage);
            resourceManager.archerCaptainShootDamage -= value;
        }

        if (archerFireRate) {
            int value = GetPercentage(resourceManager.archerCaptainShootDamage, percentage);
            resourceManager.archerCaptainShootDamage -= value;
        }

        if (meleeCritRate) {
            int value = GetPercentage(resourceManager.runnerCaptainCritRate, percentage);
            resourceManager.runnerCaptainCritRate -= value;
            int value2 = GetPercentage(resourceManager.shieldCaptainCritRate, percentage); resourceManager.shieldCaptainCritRate -= value2;
            int value3 = GetPercentage(resourceManager.broadswordCaptainCritRate, percentage); resourceManager.broadswordCaptainCritRate -= value3;

        }

        if (meleeCritMax) {
            int value = GetPercentage(resourceManager.runnerCaptainCritMax, percentage);
            resourceManager.runnerCaptainCritMax += value;
            int value2 = GetPercentage(resourceManager.shieldCaptainCritMax, percentage); resourceManager.shieldCaptainCritMax += value2;
            int value3 = GetPercentage(resourceManager.broadswordCaptainCritMax, percentage); resourceManager.broadswordCaptainCritMax += value3;
        }



        if (mageHealth) {
            int value = GetPercentage(resourceManager.fireMageHealth, percentage);
            resourceManager.fireMageHealth += value;
            int value2 = GetPercentage(resourceManager.boltMageHealth, percentage); resourceManager.boltMageHealth += value2;
            int value3 = GetPercentage(resourceManager.natureMageHealth, percentage); resourceManager.natureMageHealth += value3;
        }


        if (archerHealth) {
            int value = GetPercentage(resourceManager.archerCaptainHealth, percentage);
            resourceManager.archerCaptainHealth += value;
        }


        if (meleeHealth) {
            int value = GetPercentage(resourceManager.broadswordCaptainHealth, percentage);
            resourceManager.broadswordCaptainHealth += value;
            int value2 = GetPercentage(resourceManager.runnerCaptainHealth, percentage); resourceManager.runnerCaptainHealth += value2;
            int value3 = GetPercentage(resourceManager.shieldCaptainHealth, percentage); resourceManager.shieldCaptainHealth += value3;
        }




        if (longswordHealth) {
            int value = GetPercentage(resourceManager.broadswordCaptainHealth, percentage);
            resourceManager.broadswordCaptainHealth += value;


        }





        if (shieldHealth) {
            int value = GetPercentage(resourceManager.shieldCaptainHealth, percentage);
            resourceManager.shieldCaptainHealth += value;


        }


        if (runnerHealth) {
            int value = GetPercentage(resourceManager.runnerCaptainHealth, percentage);
            resourceManager.runnerCaptainHealth += value;


        }


        if (meleeMovement) {
            float value = GetFloatPercentage(resourceManager.shieldCaptainWalkSpeed, percentage);
            resourceManager.shieldCaptainWalkSpeed += value;
            float value2 = GetFloatPercentage(resourceManager.broadswordCaptainWalkSpeed, percentage); resourceManager.broadswordCaptainWalkSpeed += value2;
            float value3 = GetFloatPercentage(resourceManager.runnerCaptainWalkSpeed, percentage); resourceManager.runnerCaptainWalkSpeed += value3;
        }

        if (longswordWalkspeed) {
            float value = GetFloatPercentage(resourceManager.broadswordCaptainWalkSpeed, percentage);
            resourceManager.broadswordCaptainWalkSpeed += value;


        }


        if (shieldWalkspeed) {
            float value = GetFloatPercentage(resourceManager.shieldCaptainWalkSpeed, percentage);
            resourceManager.shieldCaptainWalkSpeed += value;


        }


        if (runnerMovement) {
            float value = GetFloatPercentage(resourceManager.runnerCaptainWalkSpeed, percentage);
            resourceManager.runnerCaptainWalkSpeed += value;


        }




        if (archerMovement) {
            float value = GetFloatPercentage(resourceManager.archerCaptainWalkSpeed, percentage);
            resourceManager.archerCaptainWalkSpeed += value;
        }

        if (mageMovement) {
            float value = GetFloatPercentage(resourceManager.fireMageWalkSpeed, percentage);
            resourceManager.fireMageWalkSpeed += value;
            float value2 = GetFloatPercentage(resourceManager.boltMageWalkSpeed, percentage); resourceManager.boltMageWalkSpeed += value2;
            float value3 = GetFloatPercentage(resourceManager.natureMageWalkSpeed, percentage); resourceManager.natureMageWalkSpeed += value3;
        }

        if (archerTravelSpeed) {
            float value = GetFloatPercentage(resourceManager.archerCaptainTravelSpeed, percentage);
            resourceManager.shieldCaptainWalkSpeed += value;
        }



        if (natureMageSpellDamage) {
            int value = GetPercentage(resourceManager.natureMageNormalCastDamage, percentage);
            resourceManager.natureMageNormalCastDamage += value;
            int value2 = GetPercentage(resourceManager.natureMageSuperCastDamage, percentage); resourceManager.natureMageNormalCastDamage += value2;
            int value3 = GetPercentage(resourceManager.natureMageShootDamage, percentage); resourceManager.natureMageNormalCastDamage += value3;
        }

        if (boltMageSpellDamage) {
            int value = GetPercentage(resourceManager.boltMageNormalCastDamage, percentage);
            resourceManager.boltMageNormalCastDamage += value;
            int value2 = GetPercentage(resourceManager.boltMageSuperCastDamage, percentage); resourceManager.boltMageNormalCastDamage += value2;
            int value3 = GetPercentage(resourceManager.boltMageShootDamage, percentage); resourceManager.boltMageNormalCastDamage += value3;

        }

        if (fireMageSpellDamage) {
            int value = GetPercentage(resourceManager.fireMageNormalCastDamage, percentage);
            resourceManager.fireMageNormalCastDamage += value;
            int value2 = GetPercentage(resourceManager.fireMageSuperCastDamage, percentage); resourceManager.fireMageNormalCastDamage += value2;
            int value3 = GetPercentage(resourceManager.fireMageShootDamage, percentage); resourceManager.fireMageNormalCastDamage += value3;
        }


    }


    public void UpgradeLevel3(int percentage) {

        if (redStone) {

        }


        if (meleeAttackSpeed) {
            float value = GetFloatPercentage(resourceManager.runnerHeroAttackSpeed, percentage);
            resourceManager.runnerHeroAttackSpeed += value;
            float value2 = GetFloatPercentage(resourceManager.shieldHeroAttackSpeed, percentage);
            resourceManager.shieldHeroAttackSpeed += value2;
            float value3 = GetFloatPercentage(resourceManager.broadswordHeroAttackSpeed, percentage);
            resourceManager.broadswordHeroAttackSpeed += value3;
        }

        if (broadswordRange) {
            float value = GetFloatPercentage(resourceManager.broadswordHeroRange, percentage);
            resourceManager.broadswordHeroRange += value;
        }

        if (shieldRange) {
            float value = GetFloatPercentage(resourceManager.shieldHeroRange, percentage);
            resourceManager.shieldHeroRange += value;
        }

        if (shieldRange) {
            float value = GetFloatPercentage(resourceManager.runnerHeroRange, percentage);
            resourceManager.runnerHeroRange += value;
        }




        if (fireMageFireRate) {
            float value = GetFloatPercentage(resourceManager.fireMageHeroFireRate, percentage);
            resourceManager.fireMageHeroTrainSpeed -= value;
        }

        if (natureMageFireRate) {
            float value = GetFloatPercentage(resourceManager.natureMageHeroFireRate, percentage);
            resourceManager.natureMageHeroFireRate -= value;
        }

        if (boltMageFireRate) {
            float value = GetFloatPercentage(resourceManager.boltMageHeroFireRate, percentage);
            resourceManager.boltMageHeroFireRate -= value;
        }


        if (fireMageCastRate) {
            float value = GetFloatPercentage(resourceManager.fireMageHeroCastRate, percentage);
            resourceManager.fireMageHeroCastRate -= value;
        }

        if (natureMageCastRate) {
            float value = GetFloatPercentage(resourceManager.natureMageHeroCastRate, percentage);
            resourceManager.natureMageHeroCastRate -= value;
        }

        if (boltMageCastRate) {
            float value = GetFloatPercentage(resourceManager.boltMageHeroCastRate, percentage);
            resourceManager.boltMageHeroCastRate -= value;
        }

        if (fireMageSuperCastRate) {
            float value = GetFloatPercentage(resourceManager.fireMageHeroSuperCastRate, percentage);
            resourceManager.fireMageHeroSuperCastRate -= value;
        }

        if (natureMageSuperCastRate) {
            float value = GetFloatPercentage(resourceManager.natureMageHeroSuperCastRate, percentage);
            resourceManager.natureMageHeroSuperCastRate -= value;
        }

        if (boltMageSuperCastRate) {
            float value = GetFloatPercentage(resourceManager.boltMageHeroSuperCastRate, percentage);
            resourceManager.boltMageHeroSuperCastRate -= value;
        }





        if (fireMageCritMax) {
            float value = GetFloatPercentage(resourceManager.fireMageHeroCritMax, percentage);
            resourceManager.fireMageHeroCritMax += value;
        }

        if (boltMageCritMax) {
            float value = GetFloatPercentage(resourceManager.boltMageHeroCritMax, percentage);
            resourceManager.boltMageHeroCritMax += value;
        }

        if (natureMageCritMax) {
            float value = GetFloatPercentage(resourceManager.natureMageHeroCritMax, percentage);
            resourceManager.natureMageHeroCritMax += value;
        }

        if (fireMageCritRate) {
            float value = GetFloatPercentage(resourceManager.fireMageHeroCritRate, percentage);
            resourceManager.fireMageHeroCritRate -= value;
        }

        if (boltMageCritRate) {
            float value = GetFloatPercentage(resourceManager.boltMageHeroCritRate, percentage);
            resourceManager.boltMageHeroCritRate -= value;
        }

        if (natureMageCritRate) {
            float value = GetFloatPercentage(resourceManager.natureMageHeroCritRate, percentage);
            resourceManager.natureMageHeroCritRate -= value;
        }





        if (natureMageRange) {
            float value = GetFloatPercentage(resourceManager.natureMageHeroRange, percentage);
            resourceManager.natureMageHeroRange += value;

        }

        if (fireMageRange) {
            float value = GetFloatPercentage(resourceManager.fireMageHeroRange, percentage);
            resourceManager.fireMageHeroRange += value;

        }

        if (boltMageRange) {
            float value = GetFloatPercentage(resourceManager.boltMageHeroRange, percentage);
            resourceManager.boltMageHeroRange += value;

        }


        if (archerTrainingCost) {
            int value = GetPercentage(resourceManager.archerHeroTrainCost, percentage);
            resourceManager.archerHeroTrainCost -= value;

        }


        if (meleeTrainingCost) {
            int value = GetPercentage(resourceManager.broadswordHeroTrainCost, percentage);
            resourceManager.broadswordHeroTrainCost -= value;
            int value2 = GetPercentage(resourceManager.shieldHeroTrainCost, percentage); resourceManager.shieldHeroTrainCost -= value2;
            int value3 = GetPercentage(resourceManager.runnerHeroTrainCost, percentage); resourceManager.runnerHeroTrainCost -= value3;

        }

        if (randomEffect) {

        }
        //More to add and then transfer to further upgrade levels
        if (archerTrainSpeed) {
            float value = GetFloatPercentage(resourceManager.archerHeroTrainSpeed, percentage);
            resourceManager.archerHeroTrainSpeed -= value;
        }

        if (mageTrainSpeed) {
            float value = GetFloatPercentage(resourceManager.fireMageHeroTrainSpeed, percentage);
            resourceManager.fireMageHeroTrainSpeed -= value;
            float value2 = GetFloatPercentage(resourceManager.boltMageHeroTrainSpeed, percentage); resourceManager.boltMageHeroTrainSpeed -= value2;
            float value3 = GetFloatPercentage(resourceManager.natureMageHeroTrainSpeed, percentage); resourceManager.natureMageHeroTrainSpeed -= value3;

        }

        if (meleeTrainSpeed) {
            float value = GetFloatPercentage(resourceManager.runnerHeroTrainSpeed, percentage);
            resourceManager.runnerHeroTrainSpeed -= value;
            float value2 = GetFloatPercentage(resourceManager.shieldHeroTrainSpeed, percentage);
            resourceManager.shieldHeroTrainSpeed -= value2;
            float value3 = GetFloatPercentage(resourceManager.broadswordHeroTrainSpeed, percentage);
            resourceManager.broadswordHeroTrainSpeed -= value3;
        }


        if (runnerDamage) {
            int value = GetPercentage(resourceManager.runnerHeroDamage, percentage);
            resourceManager.runnerHeroDamage += value;
        
        }

        //BroadswordHero
        if (broadswordDamage) {
            int value = GetPercentage(resourceManager.broadswordHeroDamage, percentage);
            resourceManager.broadswordHeroDamage += value;
        }

        if (shieldDamage) {
            int value = GetPercentage(resourceManager.shieldHeroDamage, percentage);
            resourceManager.shieldHeroDamage += value;
        }



        if (archerDamage) {
            int value = GetPercentage(resourceManager.archerHeroShootDamage, percentage);
            resourceManager.archerHeroShootDamage += value;
        }

        if (archerFireRate) {
            int value = GetPercentage(resourceManager.archerHeroShootDamage, percentage);
            resourceManager.archerHeroShootDamage += value;
        }

        if (meleeCritRate) {
            int value = GetPercentage(resourceManager.runnerHeroCritRate, percentage);
            resourceManager.runnerHeroCritRate -= value;
            int value2 = GetPercentage(resourceManager.shieldHeroCritRate, percentage); resourceManager.shieldHeroCritRate -= value2;
            int value3 = GetPercentage(resourceManager.broadswordHeroCritRate, percentage); resourceManager.broadswordHeroCritRate -= value3;

        }

        if (meleeCritMax) {
            int value = GetPercentage(resourceManager.runnerHeroCritMax, percentage);
            resourceManager.runnerHeroCritMax += value;
            int value2 = GetPercentage(resourceManager.shieldHeroCritMax, percentage); resourceManager.shieldHeroCritMax += value2;
            int value3 = GetPercentage(resourceManager.broadswordHeroCritMax, percentage); resourceManager.broadswordHeroCritMax += value3;
        }



        if (longswordCritRate) {
            int value3 = GetPercentage(resourceManager.broadswordHeroCritRate, percentage);
            resourceManager.broadswordHeroCritRate -= value3;
        }


        if (longswordCritMax) {
            int value3 = GetPercentage(resourceManager.broadswordHeroCritMax, percentage);
            resourceManager.broadswordHeroCritMax += value3;
        }


        if (runnerCritRate) {
            int value3 = GetPercentage(resourceManager.runnerHeroCritRate, percentage);
            resourceManager.runnerHeroCritRate -= value3;
        }


        if (runnerCritMax) {
            int value3 = GetPercentage(resourceManager.runnerHeroCritMax, percentage);
            resourceManager.runnerHeroCritMax += value3;
        }



        if (longswordCritMin) {
            int value3 = GetPercentage(resourceManager.broadswordHeroCritMin, percentage);
            resourceManager.broadswordHeroCritMin += value3;
        }

        if (runnerCritMin) {
            int value3 = GetPercentage(resourceManager.runnerHeroCritMin, percentage);
            resourceManager.runnerCaptainCritMin += value3;
        }

        if (shieldCritMin) {
            int value3 = GetPercentage(resourceManager.shieldHeroCritMin, percentage);
            resourceManager.shieldHeroCritMin += value3;
        }


        if (mageHealth) {
            int value = GetPercentage(resourceManager.fireMageHeroHealth, percentage);
            resourceManager.fireMageHeroHealth += value;
            int value2 = GetPercentage(resourceManager.boltMageHeroHealth, percentage); resourceManager.boltMageHeroHealth += value2;
            int value3 = GetPercentage(resourceManager.natureMageHeroHealth, percentage); resourceManager.natureMageHeroHealth += value3;
        }


        if (archerHealth) {
            int value = GetPercentage(resourceManager.archerHeroHealth, percentage);
            resourceManager.archerHeroHealth += value;
        }


        if (meleeHealth) {
            int value = GetPercentage(resourceManager.broadswordHeroHealth, percentage);
            resourceManager.broadswordHeroHealth += value;
            int value2 = GetPercentage(resourceManager.runnerHeroHealth, percentage); resourceManager.runnerHeroHealth += value2;
            int value3 = GetPercentage(resourceManager.shieldHeroHealth, percentage); resourceManager.shieldHeroHealth += value3;
        }



        if (longswordHealth) {
            int value = GetPercentage(resourceManager.broadswordHeroHealth, percentage);
            resourceManager.broadswordHeroHealth += value;
            

        }


        if (runnerHealth) {
            int value = GetPercentage(resourceManager.runnerHeroHealth, percentage);
            resourceManager.runnerHeroHealth += value;


        }





        if (shieldHealth) {
            int value = GetPercentage(resourceManager.shieldHeroHealth, percentage);
            resourceManager.shieldHeroHealth += value;


        }


        if (meleeMovement) {
            float value = GetFloatPercentage(resourceManager.shieldHeroWalkSpeed, percentage);
            resourceManager.shieldHeroWalkSpeed += value;
            float value2 = GetFloatPercentage(resourceManager.broadswordHeroWalkSpeed, percentage); resourceManager.broadswordHeroWalkSpeed += value2;
            float value3 = GetFloatPercentage(resourceManager.runnerHeroWalkSpeed, percentage); resourceManager.runnerHeroWalkSpeed += value3;
        }


        if (longswordWalkspeed) {
            float value = GetFloatPercentage(resourceManager.broadswordHeroWalkSpeed, percentage);
            resourceManager.broadswordHeroWalkSpeed += value;


        }


        if (shieldWalkspeed) {
            float value = GetFloatPercentage(resourceManager.shieldHeroWalkSpeed, percentage);
            resourceManager.shieldHeroWalkSpeed += value;


        }


        if (runnerMovement) {
            float value = GetFloatPercentage(resourceManager.runnerHeroWalkSpeed, percentage);
            resourceManager.runnerHeroWalkSpeed += value;


        }


        if (archerMovement) {
            float value = GetFloatPercentage(resourceManager.archerHeroWalkSpeed, percentage);
            resourceManager.archerHeroWalkSpeed += value;
        }

        if (mageMovement) {
            float value = GetFloatPercentage(resourceManager.fireMageHeroWalkSpeed, percentage);
            resourceManager.fireMageHeroWalkSpeed += value;
            float value2 = GetFloatPercentage(resourceManager.boltMageHeroWalkSpeed, percentage); resourceManager.boltMageHeroWalkSpeed += value2;
            float value3 = GetFloatPercentage(resourceManager.natureMageHeroWalkSpeed, percentage); resourceManager.natureMageHeroWalkSpeed += value3;
        }

        if (archerTravelSpeed) {
            float value = GetFloatPercentage(resourceManager.archerHeroTravelSpeed, percentage);
            resourceManager.shieldHeroWalkSpeed += value;
        }



        if (natureMageSpellDamage) {
            int value = GetPercentage(resourceManager.natureMageHeroNormalCastDamage, percentage);
            resourceManager.natureMageHeroNormalCastDamage += value;
            int value2 = GetPercentage(resourceManager.natureMageHeroSuperCastDamage, percentage); resourceManager.natureMageHeroNormalCastDamage += value2;
            int value3 = GetPercentage(resourceManager.natureMageHeroShootDamage, percentage); resourceManager.natureMageHeroNormalCastDamage += value3;
        }

        if (boltMageSpellDamage) {
            int value = GetPercentage(resourceManager.boltMageHeroNormalCastDamage, percentage);
            resourceManager.boltMageHeroNormalCastDamage += value;
            int value2 = GetPercentage(resourceManager.boltMageHeroSuperCastDamage, percentage); resourceManager.boltMageHeroNormalCastDamage += value2;
            int value3 = GetPercentage(resourceManager.boltMageHeroShootDamage, percentage); resourceManager.boltMageHeroNormalCastDamage += value3;

        }

        if (fireMageSpellDamage) {
            int value = GetPercentage(resourceManager.fireMageHeroNormalCastDamage, percentage);
            resourceManager.fireMageHeroNormalCastDamage += value;
            int value2 = GetPercentage(resourceManager.fireMageHeroSuperCastDamage, percentage); resourceManager.fireMageHeroNormalCastDamage += value2;
            int value3 = GetPercentage(resourceManager.fireMageHeroShootDamage, percentage); resourceManager.fireMageHeroNormalCastDamage += value3;
        }


    }


    private int SetPercentage(int maxAmount, int change) {
      
        int changeNormalized = change * 100;
        int percentChange = changeNormalized / maxAmount;
        return percentChange;
    }

    private int GetPercentage(int maxAmount, int desiredChange) {
        int maxNormalized = maxAmount / 100;
        int getPercentage = maxNormalized * desiredChange;
        return getPercentage;
    }

    private float GetFloatPercentage(float maxAmount, float desiredChange) {
        float maxNormalized = maxAmount / 100;
        float getPercentage = maxNormalized * desiredChange;
        return getPercentage;
    }


    public void SendToDisplay(int percentage) {

    }


    public EffectCenter() {

    }


}
