using RTS;
using UnityEngine;
using Mirror;
using NarrowWorld.Combat;

public class EnemyValueSetter : NetworkBehaviour
{

    public bool t1, t2, t3, legend;

    public bool imp, shaman, skeletonBroadsword, skeletonArcher;

    public bool stoneDemon, clawDemon, axeDemon, ghostDemon;

    public bool redStoneDemon, heroMage, heroDemon;

   



    private PlayerHealthSystem playerHealthSystem;
    private EnemyHealthSystem enemyHealthSystem;

    private PlayerMeleeMovement playerMovement;
    private EnemyMeleeMovement enemyMovement;

    private PlayerCloseCombat playerCombat;
    private EnemyCloseCombat enemyCombat;

    private PlayerDistanceMovement playerDistanceMovement;
    private EnemyDistanceMovement enemyDistanceMovement;

    private PlayerDistanceCombat playerDistanceCombat;
    private EnemyDistanceCombat enemyDistanceCombat;

    public int epReward;

    //Set training time

    public int buildTime;
    public int unitPrice;

    public bool smallGold, mediumGold, largeGold, largerGold;

    public GameObject smallGoldDrop;
    public GameObject mediumGoldDrop;
    public GameObject largeGoldDrop;
    public GameObject largerGoldDrop;

    private PlayerResourceManager resourceManager;
    private Transform spawnStore;

    public ResourceDisplay display;
    public IngamePlayer ingamePlayer;

    private void Start() {

        spawnStore = GameObject.Find("Demons").transform;
        ingamePlayer = GameObject.FindGameObjectWithTag("DemonPlayer").GetComponent<IngamePlayer>();
        display = GameObject.Find("IngameResourceDisplay").GetComponent<ResourceDisplay>();

        transform.SetParent(spawnStore);
        Vector3 spawnPoint = new Vector3();
        spawnPoint = new Vector3(-0.73f, 0.18f, 0);
        transform.localPosition = spawnPoint;
    }

    void Awake() {

        enemyHealthSystem = GetComponent<EnemyHealthSystem>();
        resourceManager = GameObject.Find("Player").GetComponent<PlayerResourceManager>();

        if (enemyHealthSystem.melee == true) {
            enemyMovement = GetComponent<EnemyMeleeMovement>();
            enemyCombat = GetComponent<EnemyCloseCombat>();

            if (t1) {
                SetT1MeleeValues();
             }

            if (t2) {
                SetT2MeleeValues();
             }

            if (t3) {
                SetT3MeleeValues();
             }

            if (legend) {

            }
        }

        if (enemyHealthSystem.distance || enemyHealthSystem.mage) {

            enemyDistanceMovement = GetComponent<EnemyDistanceMovement>();
            enemyDistanceCombat = GetComponent<EnemyDistanceCombat>();

            if (t1) {
                SetT1DistanceValues();
               



            }

            if (t2) {
                SetT2DistanceValues();
              

            }

            if (t3) {
                SetT3DistanceValues();
                


            }
        }

    }

    [Command]
    public void DropGold(string amount) {
        if (amount == "small") {
            Vector3 dropPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject gold = Instantiate(smallGoldDrop, dropPosition, Quaternion.identity);
            NetworkServer.Spawn(gold, connectionToClient);
        }

        if (amount == "medium") {
            Vector3 dropPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject gold = Instantiate(mediumGoldDrop, dropPosition, Quaternion.identity);
            NetworkServer.Spawn(gold, connectionToClient);
        }

        if (amount == "large") {
            Vector3 dropPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject gold = Instantiate(largeGoldDrop, dropPosition, Quaternion.identity);
            NetworkServer.Spawn(gold, connectionToClient);
        }

        if (amount == "larger") {
            Vector3 dropPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject gold = Instantiate(largerGoldDrop, dropPosition, Quaternion.identity);
            NetworkServer.Spawn(gold, connectionToClient);
        }
    }

    [Command]
    public void GoldPickup(int amount) {
        ingamePlayer.AddResource(ResourceType.Money, amount, display);
        display.UpdateDisplay(amount, ResourceType.Money, false);
    }

    public void ExpPickUp(int amount) {
        ingamePlayer.AddResource(ResourceType.Knowledge, amount, display);
    }


    //Melee Damage

    public void SetT1MeleeValues() {

        if (imp && t1) {

            enemyHealthSystem.maxHealth = resourceManager.impHealth;
            enemyMovement.walkSpeed = resourceManager.impWalkSpeed;
        
            enemyCombat.attackDamage = resourceManager.impDamage;
       
            enemyCombat.critMin = resourceManager.impCritMin;
            enemyCombat.critMax = resourceManager.impCritMax;
            enemyCombat.critRate = resourceManager.impCritRate;
          
            enemyCombat.startTimeBtwAttack = resourceManager.impAttackSpeed;

            enemyCombat.attackRangeAddition1 = resourceManager.impRange;
            enemyCombat.attackRangeAddition2 = resourceManager.impRange;
            enemyCombat.attackRangeAddition3 = resourceManager.impRange;
            enemyCombat.attackRangeAddition4 = resourceManager.impRange;

            return;
        }

        if (skeletonBroadsword && t1) {

            enemyHealthSystem.maxHealth = resourceManager.skeletonBroadswordHealth;
            enemyMovement.walkSpeed = resourceManager.skeletonBroadswordWalkSpeed;
         
            enemyCombat.attackDamage = resourceManager.skeletonBroadswordDamage;
            enemyCombat.critMin = resourceManager.skeletonBroadswordCritMin;
            enemyCombat.critMax = resourceManager.skeletonBroadswordCritMax;
            enemyCombat.critRate = resourceManager.skeletonBroadswordCritRate;
          
            enemyCombat.startTimeBtwAttack = resourceManager.skeletonBroadswordAttackSpeed;

            enemyCombat.attackRangeAddition1 = resourceManager.skeletonBroadswordRange;
            enemyCombat.attackRangeAddition2 = resourceManager.skeletonBroadswordRange;
            enemyCombat.attackRangeAddition3 = resourceManager.skeletonBroadswordRange;
            enemyCombat.attackRangeAddition4 = resourceManager.skeletonBroadswordRange;

            return;
        }

     
    }

    public void SetT2MeleeValues() {

        if (stoneDemon && t2) {

            enemyHealthSystem.maxHealth = resourceManager.stoneDemonHealth;
            enemyMovement.walkSpeed = resourceManager.stoneDemonWalkSpeed;
          
            enemyCombat.attackDamage = resourceManager.stoneDemonDamage;
         
            enemyCombat.critMin = resourceManager.stoneDemonCritMin;
            enemyCombat.critMax = resourceManager.stoneDemonCritMax;
            enemyCombat.critRate = resourceManager.stoneDemonCritRate;
         
            enemyCombat.startTimeBtwAttack = resourceManager.stoneDemonAttackSpeed;

            enemyCombat.attackRangeAddition1 = resourceManager.stoneDemonRange;
            enemyCombat.attackRangeAddition2 = resourceManager.stoneDemonRange;
            enemyCombat.attackRangeAddition3 = resourceManager.stoneDemonRange;
            enemyCombat.attackRangeAddition4 = resourceManager.stoneDemonRange;

            return;
        }

        if (clawDemon && t2) {

            enemyHealthSystem.maxHealth = resourceManager.clawDemonHealth;
            enemyMovement.walkSpeed = resourceManager.clawDemonWalkSpeed;
         
            enemyCombat.attackDamage = resourceManager.clawDemonDamage;
          
            enemyCombat.critMin = resourceManager.clawDemonCritMin;
            enemyCombat.critMax = resourceManager.clawDemonCritMax;
            enemyCombat.critRate = resourceManager.clawDemonCritRate;
          
            enemyCombat.startTimeBtwAttack = resourceManager.clawDemonAttackSpeed;

            enemyCombat.attackRangeAddition1 = resourceManager.clawDemonRange;
            enemyCombat.attackRangeAddition2 = resourceManager.clawDemonRange;
            enemyCombat.attackRangeAddition3 = resourceManager.clawDemonRange;
            enemyCombat.attackRangeAddition4 = resourceManager.clawDemonRange;

            return;
        }

        if (axeDemon && t2) {
            enemyHealthSystem.maxHealth = resourceManager.axeDemonHealth;
            enemyMovement.walkSpeed = resourceManager.axeDemonWalkSpeed;

            enemyCombat.attackDamage = resourceManager.axeDemonDamage;

            enemyCombat.critMin = resourceManager.axeDemonCritMin;
            enemyCombat.critMax = resourceManager.axeDemonCritMax;
            enemyCombat.critRate = resourceManager.axeDemonCritRate;

            enemyCombat.startTimeBtwAttack = resourceManager.axeDemonAttackSpeed;

            enemyCombat.attackRangeAddition1 = resourceManager.axeDemonRange;
            enemyCombat.attackRangeAddition2 = resourceManager.axeDemonRange;
            enemyCombat.attackRangeAddition3 = resourceManager.axeDemonRange;
            enemyCombat.attackRangeAddition4 = resourceManager.axeDemonRange;

            return;
        }

        if (ghostDemon && t2) {
            enemyHealthSystem.maxHealth = resourceManager.ghostDemonHealth;
            enemyMovement.walkSpeed = resourceManager.ghostDemonWalkSpeed;

            enemyCombat.attackDamage = resourceManager.ghostDemonDamage;
          
            enemyCombat.critMin = resourceManager.ghostDemonCritMin;
            enemyCombat.critMax = resourceManager.ghostDemonCritMax;
            enemyCombat.critRate = resourceManager.ghostDemonCritRate;
         
            enemyCombat.startTimeBtwAttack = resourceManager.ghostDemonAttackSpeed;

            enemyCombat.attackRangeAddition1 = resourceManager.ghostDemonRange;
            enemyCombat.attackRangeAddition2 = resourceManager.ghostDemonRange;
            enemyCombat.attackRangeAddition3 = resourceManager.ghostDemonRange;
            enemyCombat.attackRangeAddition4 = resourceManager.ghostDemonRange;

            return;
        }

    }

    public void SetT3MeleeValues() {

        if (redStoneDemon && t3) {

            enemyHealthSystem.maxHealth = resourceManager.redStoneDemonHealth;
            enemyMovement.walkSpeed = resourceManager.redStoneDemonWalkSpeed;
           
            enemyCombat.attackDamage = resourceManager.redStoneDemonDamage;
          
            enemyCombat.critMin = resourceManager.redStoneDemonCritMin;
            enemyCombat.critMax = resourceManager.redStoneDemonCritMax;
            enemyCombat.critRate = resourceManager.redStoneDemonCritRate;
          
            enemyCombat.startTimeBtwAttack = resourceManager.redStoneDemonAttackSpeed;

            enemyCombat.attackRangeAddition1 = resourceManager.redStoneDemonRange;
            enemyCombat.attackRangeAddition2 = resourceManager.redStoneDemonRange;
            enemyCombat.attackRangeAddition3 = resourceManager.redStoneDemonRange;
            enemyCombat.attackRangeAddition4 = resourceManager.redStoneDemonRange;

            return;
        }

        if (heroDemon && t3) {

            enemyHealthSystem.maxHealth = resourceManager.heroDemonHealth;
            enemyMovement.walkSpeed = resourceManager.heroDemonWalkSpeed;
         
            enemyCombat.attackDamage = resourceManager.heroDemonDamage;
            enemyCombat.critMin = resourceManager.heroDemonCritMin;
            enemyCombat.critMax = resourceManager.heroDemonCritMax;
            enemyCombat.critRate = resourceManager.heroDemonCritRate;
         
            enemyCombat.startTimeBtwAttack = resourceManager.heroDemonAttackSpeed;

            enemyCombat.attackRangeAddition1 = resourceManager.heroDemonRange;
            enemyCombat.attackRangeAddition2 = resourceManager.heroDemonRange;
            enemyCombat.attackRangeAddition3 = resourceManager.heroDemonRange;
            enemyCombat.attackRangeAddition4 = resourceManager.heroDemonRange;

            return;
        }

 
    }



    public void SetT1DistanceValues() {
        if (skeletonArcher && t1) {
            //Combat
            enemyDistanceCombat.shootDamage = resourceManager.skeletonArcherShootDamage;
          
            enemyDistanceCombat.maxBtwShoot = resourceManager.skeletonArcherFireRate;
            enemyDistanceCombat.projectileSpeed = resourceManager.skeletonArcherTravelSpeed;
        
          
            enemyHealthSystem.maxHealth = resourceManager.skeletonArcherHealth;
          
            enemyDistanceMovement.walkSpeed = resourceManager.skeletonArcherWalkSpeed;
           
            buildTime = (int)resourceManager.skeletonArcherTrainSpeed;
            unitPrice = resourceManager.skeletonArcherTrainCost;

            return;
        }

        if (shaman && t2) {
            enemyHealthSystem.maxHealth = resourceManager.shamanHealth;
          
            enemyDistanceCombat.shootDamage = resourceManager.shamanShootDamage;
            enemyDistanceCombat.normalCastDmg = resourceManager.shamanNormalCastDamage;
            enemyDistanceCombat.superCastDmg = resourceManager.shamanSuperCastDamage;
         
            enemyDistanceCombat.shootRange = resourceManager.shamanRange;
            enemyDistanceCombat.critRate = resourceManager.shamanCritRate;
            enemyDistanceCombat.critMin = resourceManager.shamanCritMin;
            enemyDistanceCombat.critMax = resourceManager.shamanCritMax;
            enemyDistanceCombat.maxBtwShoot = resourceManager.shamanFireRate;
            enemyDistanceCombat.maxBtwSuperCast = resourceManager.shamanSuperCastRate;
          
            enemyDistanceMovement.walkSpeed = resourceManager.shamanWalkSpeed;

            buildTime = (int)resourceManager.shamanTrainSpeed;
            unitPrice = resourceManager.shamanTrainCost;

            return;
        }

    }



    public void SetT2DistanceValues() {
      
    }



    public void SetT3DistanceValues() {
   

        if (heroMage && t3) {
            enemyHealthSystem.maxHealth = resourceManager.heroMageDemonHealth;

            enemyDistanceCombat.shootDamage = resourceManager.heroMageDemonShootDamage;
            enemyDistanceCombat.normalCastDmg = resourceManager.heroMageDemonNormalCastDamage;
            enemyDistanceCombat.superCastDmg = resourceManager.heroMageDemonSuperCastDamage;
          
            enemyDistanceCombat.shootRange = resourceManager.heroMageDemonRange;
            enemyDistanceCombat.critRate = resourceManager.heroMageDemonCritRate;
            enemyDistanceCombat.critMin = resourceManager.heroMageDemonCritMin;
            enemyDistanceCombat.critMax = resourceManager.heroMageDemonCritMax;
            enemyDistanceCombat.maxBtwShoot = resourceManager.heroMageDemonFireRate;
            enemyDistanceCombat.maxBtwSuperCast = resourceManager.heroMageDemonSuperCastRate;
          
            enemyDistanceMovement.walkSpeed = resourceManager.heroMageDemonWalkSpeed;

            buildTime = (int)resourceManager.heroMageDemonTrainSpeed;
            unitPrice = resourceManager.heroMageDemonTrainCost;
            return;
        }


    }




}
