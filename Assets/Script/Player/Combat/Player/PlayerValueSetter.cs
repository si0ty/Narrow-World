using RTS;
using UnityEngine;
using Mirror;
using NarrowWorld.Combat;


public class PlayerValueSetter : NetworkBehaviour
{

    public bool t1, t2, t3, legend;

    public bool archer, broadsword, shield, runner;

    public bool tier2Archer, tier2Broadsword, tier2Shield, tier2Runner, tier2Mage;

    public bool tier3Archer, tier3Broadsword, tier3Shield, tier3Runner, tier3Mage;

    public bool tjorbjörn, catharina, liss;



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
    private ResourceDisplay display;
    private IngamePlayer ingamePlayer;
    private NetworkIdentity identity;

    private Transform spawnStore;

    private void Start() {

        spawnStore = GameObject.Find("Knights").transform;
        transform.SetParent(spawnStore);
        transform.localPosition = spawnStore.localPosition;
    }

    void Awake() {

        playerHealthSystem = GetComponent<PlayerHealthSystem>();
        resourceManager = GameObject.Find("Player").GetComponent<PlayerResourceManager>();
        ingamePlayer = GameObject.FindGameObjectWithTag("KnightPlayer").GetComponent<IngamePlayer>();
        display = GameObject.Find("IngameResourceDisplay").GetComponent<ResourceDisplay>();
        identity = GetComponent<NetworkIdentity>();

       // ingamePlayer.GiveAuthority(identity);

        if (playerHealthSystem.melee == true) {
            playerMovement = GetComponent<PlayerMeleeMovement>();
            playerCombat = GetComponent<PlayerCloseCombat>();

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

        if (playerHealthSystem.distance || playerHealthSystem.mage) {

            playerDistanceMovement = GetComponent<PlayerDistanceMovement>();
            playerDistanceCombat = GetComponent<PlayerDistanceCombat>();

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

    [ClientRpc]
    public void GoldPickup(int amount) {
        ingamePlayer.AddResource(ResourceType.Money, amount, display);
        display.UpdateDisplay(amount, ResourceType.Money, false);
    }

    public void ExpPickUp(int amount) {
        ingamePlayer.AddResource(ResourceType.Knowledge, amount, display);
    }


    //Melee Damage

    public void SetT1MeleeValues() {

        if (broadsword && t1) {

            playerHealthSystem.maxHealth = resourceManager.broadswordHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerMovement.walkSpeed = resourceManager.broadswordWalkSpeed;

            playerCombat.attackDamage = resourceManager.broadswordDamage;

            playerCombat.critMin = resourceManager.broadswordCritMin;
            playerCombat.critMax = resourceManager.broadswordCritMax;
            playerCombat.critRate = resourceManager.broadswordCritRate;

            playerCombat.startTimeBtwAttack = resourceManager.broadswordAttackSpeed;
            buildTime = (int)resourceManager.broadswordTrainSpeed;
            unitPrice = resourceManager.broadswordTrainCost;

            playerCombat.attackRangeAddition1 = resourceManager.broadswordRange;
                  playerCombat.attackRangeAddition2 = resourceManager.broadswordRange;
            playerCombat.attackRangeAddition3 = resourceManager.broadswordRange;
            playerCombat.attackRangeAddition4 = resourceManager.broadswordRange;

            return;
        }

        if (runner && t1) {

            playerHealthSystem.maxHealth = resourceManager.runnerHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerMovement.walkSpeed = resourceManager.runnerWalkSpeed;



            playerCombat.attackDamage = resourceManager.runnerDamage;
            playerCombat.critMin = resourceManager.runnerCritMin;
            playerCombat.critMax = resourceManager.runnerCritMax;
            playerCombat.critRate = resourceManager.runnerCritRate;

            playerCombat.startTimeBtwAttack = resourceManager.runnerAttackSpeed;
            buildTime = (int)resourceManager.runnerTrainSpeed;
            unitPrice = resourceManager.runnerTrainCost;

            playerCombat.attackRangeAddition1 = resourceManager.runnerRange;
            playerCombat.attackRangeAddition2 = resourceManager.runnerRange;
            playerCombat.attackRangeAddition3 = resourceManager.runnerRange;
            playerCombat.attackRangeAddition4 = resourceManager.runnerRange;

            return;
        }

        if (shield && t1) {

            playerHealthSystem.maxHealth = resourceManager.shieldHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerMovement.walkSpeed = resourceManager.shieldWalkSpeed;

            playerCombat.attackDamage = resourceManager.shieldDamage;
            playerCombat.critMin = resourceManager.shieldCritMin;
            playerCombat.critMax = resourceManager.shieldCritMax;
            playerCombat.critRate = resourceManager.shieldCritRate;

            playerCombat.startTimeBtwAttack = resourceManager.shieldAttackSpeed;
            buildTime = (int)resourceManager.shieldTrainSpeed;
            unitPrice = resourceManager.shieldTrainCost;
            playerHealthSystem.pushback = (int)resourceManager.shieldPushback;


            playerCombat.attackRangeAddition1 = resourceManager.shieldRange;
            playerCombat.attackRangeAddition2 = resourceManager.shieldRange;
            playerCombat.attackRangeAddition3 = resourceManager.shieldRange;
            playerCombat.attackRangeAddition4 = resourceManager.shieldRange;
            return;
        }

    }

    public void SetT2MeleeValues() {

        if (tier2Broadsword && t2) {

            playerHealthSystem.maxHealth = resourceManager.broadswordCaptainHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerMovement.walkSpeed = resourceManager.broadswordCaptainWalkSpeed;

            playerCombat.attackDamage = resourceManager.broadswordCaptainDamage;

            playerCombat.critMin = resourceManager.broadswordCaptainCritMin;
            playerCombat.critMax = resourceManager.broadswordCaptainCritMax;
            playerCombat.critRate = resourceManager.broadswordCaptainCritRate;

            playerCombat.startTimeBtwAttack = resourceManager.broadswordCaptainAttackSpeed;
            buildTime = (int)resourceManager.broadswordCaptainTrainSpeed;
            unitPrice = resourceManager.broadswordCaptainTrainCost;

            playerCombat.attackRangeAddition1 = resourceManager.broadswordCaptainRange;
            playerCombat.attackRangeAddition2 = resourceManager.broadswordCaptainRange;
            playerCombat.attackRangeAddition3 = resourceManager.broadswordCaptainRange;
            playerCombat.attackRangeAddition4 = resourceManager.broadswordCaptainRange;

            return;
        }

        if (tier2Runner && t2) {

            playerHealthSystem.maxHealth = resourceManager.runnerCaptainHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerMovement.walkSpeed = resourceManager.runnerCaptainWalkSpeed;

            playerCombat.attackDamage = resourceManager.runnerCaptainDamage;

            playerCombat.critMin = resourceManager.runnerCaptainCritMin;
            playerCombat.critMax = resourceManager.runnerCaptainCritMax;
            playerCombat.critRate = resourceManager.runnerCaptainCritRate;

            playerCombat.startTimeBtwAttack = resourceManager.runnerCaptainAttackSpeed;
            buildTime = (int)resourceManager.runnerCaptainTrainSpeed;
            unitPrice = resourceManager.runnerCaptainTrainCost;

            playerCombat.attackRangeAddition1 = resourceManager.runnerCaptainRange;
            playerCombat.attackRangeAddition2 = resourceManager.runnerCaptainRange;
            playerCombat.attackRangeAddition3 = resourceManager.runnerCaptainRange;
            playerCombat.attackRangeAddition4 = resourceManager.runnerCaptainRange;

            return;
        }

        if (tier2Shield && t2) {
            playerHealthSystem.maxHealth = resourceManager.shieldCaptainHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerMovement.walkSpeed = resourceManager.shieldCaptainWalkSpeed;

            playerCombat.attackDamage = resourceManager.shieldCaptainDamage;

            playerCombat.critMin = resourceManager.shieldCaptainCritMin;
            playerCombat.critMax = resourceManager.shieldCaptainCritMax;
            playerCombat.critRate = resourceManager.shieldCaptainCritRate;

            playerCombat.startTimeBtwAttack = resourceManager.shieldCaptainAttackSpeed;

            buildTime = (int)resourceManager.shieldCaptainTrainSpeed;
            unitPrice = resourceManager.shieldCaptainTrainCost;

            playerCombat.attackRangeAddition1 = resourceManager.shieldCaptainRange;
            playerCombat.attackRangeAddition2 = resourceManager.shieldCaptainRange;
            playerCombat.attackRangeAddition3 = resourceManager.shieldCaptainRange;
            playerCombat.attackRangeAddition4 = resourceManager.shieldCaptainRange;

            return;
        }

    }

    public void SetT3MeleeValues() {

        if (tier3Broadsword && t3) {

            playerHealthSystem.maxHealth = resourceManager.broadswordHeroHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerMovement.walkSpeed = resourceManager.broadswordCaptainWalkSpeed;

            playerCombat.attackDamage = resourceManager.broadswordHeroDamage;

            playerCombat.critMin = resourceManager.broadswordHeroCritMin;
            playerCombat.critMax = resourceManager.broadswordHeroCritMax;
            playerCombat.critRate = resourceManager.broadswordHeroCritRate;

            playerCombat.startTimeBtwAttack = resourceManager.broadswordHeroAttackSpeed;

            buildTime = (int)resourceManager.broadswordHeroTrainSpeed;
            unitPrice = resourceManager.broadswordHeroTrainCost;

            playerCombat.attackRangeAddition1 = resourceManager.broadswordHeroRange;
            playerCombat.attackRangeAddition2 = resourceManager.broadswordHeroRange;
            playerCombat.attackRangeAddition3 = resourceManager.broadswordHeroRange;
            playerCombat.attackRangeAddition4 = resourceManager.broadswordHeroRange;

            return;
        }

        if (tier3Runner && t3) {

            playerHealthSystem.maxHealth = resourceManager.runnerHeroHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerMovement.walkSpeed = resourceManager.runnerCaptainWalkSpeed;
          

            playerCombat.attackDamage = resourceManager.runnerHeroDamage;
            playerCombat.critMin = resourceManager.runnerHeroCritMin;
            playerCombat.critMax = resourceManager.runnerHeroCritMax;
            playerCombat.critRate = resourceManager.runnerHeroCritRate;

            playerCombat.startTimeBtwAttack = resourceManager.runnerHeroAttackSpeed;
            buildTime = (int)resourceManager.runnerHeroTrainSpeed;
            unitPrice = resourceManager.runnerHeroTrainCost;

            playerCombat.attackRangeAddition1 = resourceManager.runnerHeroRange;
            playerCombat.attackRangeAddition2 = resourceManager.runnerHeroRange;
            playerCombat.attackRangeAddition3 = resourceManager.runnerHeroRange;
            playerCombat.attackRangeAddition4 = resourceManager.runnerHeroRange;
            return;
        }

        if (tier3Shield && t3) {

            playerHealthSystem.maxHealth = resourceManager.shieldHeroHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerMovement.walkSpeed = resourceManager.shieldCaptainWalkSpeed;

            playerCombat.attackDamage = resourceManager.shieldHeroDamage;
            playerCombat.critMin = resourceManager.shieldHeroCritMin;
            playerCombat.critMax = resourceManager.shieldHeroCritMax;
            playerCombat.critRate = resourceManager.shieldHeroCritRate;

            playerCombat.startTimeBtwAttack = resourceManager.shieldHeroAttackSpeed;
            buildTime = (int)resourceManager.shieldHeroTrainSpeed;
            unitPrice = resourceManager.shieldHeroTrainCost;

            playerCombat.attackRangeAddition1 = resourceManager.shieldHeroRange;
            playerCombat.attackRangeAddition2 = resourceManager.shieldHeroRange;
            playerCombat.attackRangeAddition3 = resourceManager.shieldHeroRange;
            playerCombat.attackRangeAddition4 = resourceManager.shieldHeroRange;

            return;
        }

    }



    public void SetT1DistanceValues() {
        if (archer && t1) {
            //Combat
            playerDistanceCombat.shootDamage = resourceManager.archerShootDamage;

            playerDistanceCombat.maxBtwShoot = resourceManager.archerFireRate;
            playerDistanceCombat.projectileSpeed = resourceManager.archerTravelSpeed;
            playerDistanceCombat.shootRange = resourceManager.archerFireRange;

            //Health
            playerHealthSystem.maxHealth = resourceManager.archerHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerDistanceMovement.walkSpeed = resourceManager.archerWalkSpeed;

            buildTime = (int)resourceManager.archerTrainSpeed;
            unitPrice = resourceManager.archerTrainCost;

            playerDistanceCombat.pushback = resourceManager.archerPushback;

            return;
        }
    }



    public void SetT2DistanceValues() {
        if (tier2Archer && t2) {
            playerDistanceCombat.shootDamage = resourceManager.archerCaptainShootDamage;

            playerDistanceCombat.maxBtwShoot = resourceManager.archerCaptainFireRate;
            playerDistanceCombat.projectileSpeed = resourceManager.archerCaptainTravelSpeed;
            playerDistanceCombat.shootRange = resourceManager.archerCaptainFireRange;

            //health
            playerHealthSystem.maxHealth = resourceManager.archerCaptainHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            //Movement
            playerDistanceMovement.walkSpeed = resourceManager.archerCaptainWalkSpeed;

            buildTime = (int)resourceManager.archerCaptainTrainSpeed;
            unitPrice = resourceManager.archerCaptainTrainCost;
            return;
        }

        if (tier2Mage && t2 && playerDistanceCombat.fireMage) {
            playerHealthSystem.maxHealth = resourceManager.fireMageHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerDistanceCombat.shootDamage = resourceManager.fireMageShootDamage;
            playerDistanceCombat.normalCastDmg = resourceManager.fireMageNormalCastDamage;
            playerDistanceCombat.superCastDmg = resourceManager.fireMageSuperCastDamage;
         
            playerDistanceCombat.shootRange = resourceManager.fireMageRange;
            playerDistanceCombat.critRate = resourceManager.fireMageCritRate;
            playerDistanceCombat.critMin = resourceManager.fireMageCritMin;
            playerDistanceCombat.critMax = resourceManager.fireMageCritMax;
            playerDistanceCombat.maxBtwShoot = resourceManager.fireMageFireRate;
            playerDistanceCombat.maxBtwCast = resourceManager.fireMageCastRate;
            playerDistanceCombat.maxBtwSuperCast = resourceManager.fireMageSuperCastRate;

            playerDistanceMovement.walkSpeed = resourceManager.fireMageWalkSpeed;

            buildTime = (int)resourceManager.fireMageTrainSpeed;
            unitPrice = resourceManager.fireMageTrainCost;
           
            return;
        }

        if (tier2Mage && t2 && playerDistanceCombat.boltMage) {
            playerHealthSystem.maxHealth = resourceManager.boltMageHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerDistanceCombat.shootDamage = resourceManager.boltMageShootDamage;
            playerDistanceCombat.normalCastDmg = resourceManager.boltMageNormalCastDamage;
            playerDistanceCombat.superCastDmg = resourceManager.boltMageSuperCastDamage;

            playerDistanceCombat.shootRange = resourceManager.boltMageRange;
            playerDistanceCombat.critRate = resourceManager.boltMageCritRate;
            playerDistanceCombat.critMin = resourceManager.boltMageCritMin;
            playerDistanceCombat.critMax = resourceManager.boltMageCritMax;
            playerDistanceCombat.maxBtwShoot = resourceManager.boltMageFireRate;
            playerDistanceCombat.maxBtwCast = resourceManager.boltMageCastRate;
            playerDistanceCombat.maxBtwSuperCast = resourceManager.boltMageSuperCastRate;

            playerDistanceMovement.walkSpeed = resourceManager.boltMageWalkSpeed;

            buildTime = (int)resourceManager.boltMageTrainSpeed;
            unitPrice = resourceManager.boltMageTrainCost;

            return;
        }

        if (tier2Mage && t2 && playerDistanceCombat.natureMage) {
            playerHealthSystem.maxHealth = resourceManager.natureMageHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerDistanceCombat.shootDamage = resourceManager.natureMageShootDamage;
            playerDistanceCombat.normalCastDmg = resourceManager.natureMageNormalCastDamage;
            playerDistanceCombat.superCastDmg = resourceManager.natureMageSuperCastDamage;

            playerDistanceCombat.shootRange = resourceManager.natureMageRange;
            playerDistanceCombat.critRate = resourceManager.natureMageCritRate;
            playerDistanceCombat.critMin = resourceManager.natureMageCritMin;
            playerDistanceCombat.critMax = resourceManager.natureMageCritMax;
            playerDistanceCombat.maxBtwShoot = resourceManager.natureMageFireRate;
            playerDistanceCombat.maxBtwCast = resourceManager.natureMageCastRate;
            playerDistanceCombat.maxBtwSuperCast = resourceManager.natureMageSuperCastRate;

            playerDistanceMovement.walkSpeed = resourceManager.natureMageWalkSpeed;

            buildTime = (int)resourceManager.natureMageTrainSpeed;
            unitPrice = resourceManager.natureMageTrainCost;

            return;
        }
    }



    public void SetT3DistanceValues() {
        if (tier3Archer && t3) {
            playerDistanceCombat.shootDamage = resourceManager.archerHeroShootDamage;
            playerDistanceCombat.maxBtwShoot = resourceManager.archerHeroFireRate;
            playerDistanceCombat.projectileSpeed = resourceManager.archerHeroTravelSpeed;
            playerDistanceCombat.shootRange = resourceManager.archerHeroFireRange;

            //Health
            playerHealthSystem.maxHealth = resourceManager.archerHeroHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            //Movement
            playerDistanceMovement.walkSpeed = resourceManager.archerHeroWalkSpeed;

            buildTime = (int)resourceManager.archerHeroTrainSpeed;
            unitPrice = resourceManager.archerHeroTrainCost;

            return;
        }

        if (tier3Mage && t3 && playerDistanceCombat.fireMage) {
            playerHealthSystem.maxHealth = resourceManager.fireMageHeroHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerDistanceCombat.shootDamage = resourceManager.fireMageHeroShootDamage;
            playerDistanceCombat.normalCastDmg = resourceManager.fireMageHeroNormalCastDamage;
            playerDistanceCombat.superCastDmg = resourceManager.fireMageHeroSuperCastDamage;

            playerDistanceCombat.shootRange = resourceManager.fireMageRange;
            playerDistanceCombat.critRate = resourceManager.fireMageHeroCritRate;
            playerDistanceCombat.critMin = resourceManager.fireMageHeroCritMin;
            playerDistanceCombat.critMax = resourceManager.fireMageHeroCritMax;
            playerDistanceCombat.maxBtwShoot = resourceManager.fireMageHeroFireRate;
            playerDistanceCombat.maxBtwCast = resourceManager.fireMageHeroCastRate;
            playerDistanceCombat.maxBtwSuperCast = resourceManager.fireMageHeroSuperCastRate;
            Debug.Log("FireMageSet");

            playerDistanceMovement.walkSpeed = resourceManager.fireMageHeroWalkSpeed;

            buildTime = (int)resourceManager.fireMageHeroTrainSpeed;
            unitPrice = resourceManager.fireMageHeroTrainCost;
            return;
        }


        if (tier3Mage && t3 && playerDistanceCombat.boltMage) {
            playerHealthSystem.maxHealth = resourceManager.fireMageHeroHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerDistanceCombat.shootDamage = resourceManager.boltMageHeroShootDamage;
            playerDistanceCombat.normalCastDmg = resourceManager.boltMageHeroNormalCastDamage;
            playerDistanceCombat.superCastDmg = resourceManager.boltMageHeroSuperCastDamage;

            playerDistanceCombat.shootRange = resourceManager.boltMageRange;
            playerDistanceCombat.critRate = resourceManager.boltMageHeroCritRate;
            playerDistanceCombat.critMin = resourceManager.boltMageHeroCritMin;
            playerDistanceCombat.critMax = resourceManager.boltMageHeroCritMax;
            playerDistanceCombat.maxBtwShoot = resourceManager.boltMageHeroFireRate;
            playerDistanceCombat.maxBtwCast = resourceManager.boltMageHeroCastRate;
            playerDistanceCombat.maxBtwSuperCast = resourceManager.boltMageHeroSuperCastRate;

            playerDistanceMovement.walkSpeed = resourceManager.boltMageHeroWalkSpeed;

            buildTime = (int)resourceManager.boltMageHeroTrainSpeed;
            unitPrice = resourceManager.boltMageHeroTrainCost;
            return;
        }


        if (tier3Mage && t3 && playerDistanceCombat.natureMage) {
            playerHealthSystem.maxHealth = resourceManager.natureMageHeroHealth;
            playerHealthSystem.currentHealth = playerHealthSystem.maxHealth;

            playerDistanceCombat.shootDamage = resourceManager.natureMageHeroShootDamage;
            playerDistanceCombat.normalCastDmg = resourceManager.natureMageHeroNormalCastDamage;
            playerDistanceCombat.superCastDmg = resourceManager.natureMageHeroSuperCastDamage;

            playerDistanceCombat.shootRange = resourceManager.natureMageRange;
            playerDistanceCombat.critRate = resourceManager.natureMageHeroCritRate;
            playerDistanceCombat.critMin = resourceManager.natureMageHeroCritMin;
            playerDistanceCombat.critMax = resourceManager.natureMageHeroCritMax;
            playerDistanceCombat.maxBtwShoot = resourceManager.natureMageHeroFireRate;
            playerDistanceCombat.maxBtwCast = resourceManager.natureMageHeroCastRate;
            playerDistanceCombat.maxBtwSuperCast = resourceManager.natureMageHeroSuperCastRate;

            playerDistanceMovement.walkSpeed = resourceManager.natureMageHeroWalkSpeed;

            buildTime = (int)resourceManager.natureMageHeroTrainSpeed;
            unitPrice = resourceManager.natureMageHeroTrainCost;
            return;
        }


    }




}
