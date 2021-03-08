using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using NarrowWorld.Combat;


public class EnemyCloseCombat : NetworkBehaviour
{
    public bool caster, supercaster;

    public bool inRange;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

  
    public int attackDamage;

    private int actualDamage;


    public float attackRangeAddition1;
    public float attackRangeAddition2;
    public float attackRangeAddition3;
    public float attackRangeAddition4;

    [HideInInspector]
    public int critRate;
    [HideInInspector]
    public int critMin;
    [HideInInspector]
    public int critMax;

    public GameObject critEffect;

    public int normalCastDmg;
    public int superCastDmg;

    public float normalCastRange;
    public float superCastRange;


    [HideInInspector]
    public int combo;
    public int attackRow;

    public GameObject castPoint;
    
    
    public float maxBtwCast;
    private float castBtw = 0;

   
    public float maxBtwSuperCast;

    [HideInInspector]
    public float superCastBtw = 0;
  

    private EnemyRayCast enemyRayCast;
    private EnemyMeleeAnimations baseAnimation;
    private EnemyMeleeMovement enemyMeleeMovement;

    public float spellRange;
    private int critDamage;

    private void Start() {
        if (caster || supercaster) {
            enemyRayCast = GetComponent<EnemyRayCast>();
            superCastBtw = maxBtwSuperCast;
        }
        baseAnimation = GetComponent<EnemyMeleeAnimations>();
        enemyMeleeMovement = GetComponent<EnemyMeleeMovement>();

        baseAnimation.WalkingAnim();
    }

    void Awake() {
        timeBtwAttack = 0;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D)) {
            inRange = true;

        }

        if (other.gameObject.tag == "PlayerCastle" && other.GetType() == typeof(BoxCollider2D)) {
            inRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D)) {
            inRange = false;          
        }

        if (other.gameObject.tag == "PlayerCastle" && other.GetType() == typeof(BoxCollider2D)) {
            inRange = false;
        }
    }


    void Update() {



        if (inRange == true && timeBtwAttack <= 0) {

            baseAnimation.FightingAnim();

            if (attackRow >= 2) {
                baseAnimation.FightingAnim();
            }

            if (attackRow >= 3) {
                baseAnimation.FightingAnim();
            }

            timeBtwAttack = startTimeBtwAttack;
            baseAnimation.IdleAnim();
        }

        else {

            timeBtwAttack -= Time.deltaTime;
        }

        if (enemyRayCast != null) {

        

            if (enemyRayCast.enemySpotted == true && inRange == false ) {
                        
                               
                if (caster == true) {
                    if (castBtw <= 0 && superCastBtw > 0) {

                      
                        baseAnimation.NormalCastAnim();
                        castBtw = maxBtwCast;

                    } 
                    castBtw -= Time.deltaTime;
                }

                if (supercaster == true) {
                    if (superCastBtw <= 0) {

                      
                        baseAnimation.SuperCastAnim();
                        superCastBtw = maxBtwSuperCast;

                    }
                  
                    superCastBtw -= Time.deltaTime;
                }

                if(castBtw > 1 && castBtw < maxBtwCast - 2) {
                    baseAnimation.WalkingAnim();
                }
            }
        }
    }



    private int SetPercentage(int maxAmount, int percent) {
        int maxNormalized = percent / maxAmount;
        int setPercentage = maxNormalized * 100;
        return setPercentage;
    }

    [Command]
    public void Attack() {
        AttackEffect();
    }


    [ClientRpc]
    private void AttackEffect() {
        

       
        if (combo == 1) {

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRangeAddition1, enemyLayers);

            int mayCrit = new int();
            mayCrit = Random.Range(1, critRate + 1);
            Debug.Log(mayCrit.ToString());

            if (mayCrit == 1) {
                int critDamage = new int();
                critDamage = Random.Range(critMin, critMax);
                              
                actualDamage += critDamage + attackDamage;
               
                CinemachineShake.Instance.ShakeCamera(0.3f, 0.3f, false);

            }
            else {
               
                actualDamage = attackDamage;
             

            }

            foreach (Collider2D enemy in hitEnemies) {
                Debug.Log("we hit" + enemy.name);

                if (enemy.GetComponent<PlayerHealthSystem>() != null) {
                    enemy.GetComponent<PlayerHealthSystem>().CmdDealDamage(actualDamage);


                    if (critDamage < SetPercentage(critMax, 60)) {
                        enemy.GetComponent<PlayerHealthSystem>().NormalDmgEffect(actualDamage);
                    }


                    if (critDamage >= SetPercentage(critMax, 60)) {
                        enemy.GetComponent<PlayerHealthSystem>().MiddleDmgEffect(actualDamage);
                    }


                    if (critDamage >= SetPercentage(critMax, 80)) {
                        enemy.GetComponent<PlayerHealthSystem>().LargeDmgEffect(actualDamage);
                    }
                }
                else {
                    enemy.GetComponent<PlayerCastleHealthSystem>().TakeDamage(attackDamage);
                }

            }
        }


        if (combo == 2) {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRangeAddition2, enemyLayers);

            int mayCrit = new int();
            mayCrit = Random.Range(1, critRate + 1);
            Debug.Log(mayCrit.ToString());

            if (mayCrit == 1) {
                int critDamage = new int();
                critDamage = Random.Range(critMin, critMax);


              
                actualDamage += critDamage + attackDamage;
              

                foreach (Collider2D enemy in hitEnemies) {
                    Instantiate(critEffect, enemy.transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
                   
                }

                CinemachineShake.Instance.ShakeCamera(0.1f, 0.1f, false);
            }
            else {
            
                actualDamage = attackDamage;
             

            }

            foreach (Collider2D enemy in hitEnemies) {
                Debug.Log("we hit" + enemy.name);

                if (enemy.GetComponent<PlayerHealthSystem>() != null) {
                    enemy.GetComponent<PlayerHealthSystem>().CmdDealDamage(actualDamage);


                    if (critDamage < SetPercentage(critMax, 60)) {
                        enemy.GetComponent<PlayerHealthSystem>().NormalDmgEffect(actualDamage);
                    }


                    if (critDamage >= SetPercentage(critMax, 60)) {
                        enemy.GetComponent<PlayerHealthSystem>().MiddleDmgEffect(actualDamage);
                    }


                    if (critDamage >= SetPercentage(critMax, 80)) {
                        enemy.GetComponent<PlayerHealthSystem>().LargeDmgEffect(actualDamage);
                    }
                }
                else if (enemy.GetComponent<PlayerCastleHealthSystem>() != null) {
                    enemy.GetComponent<PlayerCastleHealthSystem>().TakeDamage(attackDamage);
                }


            }
        }

        if (combo == 3) {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRangeAddition3, enemyLayers);

            int mayCrit = new int();
            mayCrit = Random.Range(1, critRate + 1);
            Debug.Log(mayCrit.ToString());

            if (mayCrit == 1) {
                int critDamage = new int();
                critDamage = Random.Range(critMin, critMax);

                               
                actualDamage += critDamage + attackDamage;
              

                foreach (Collider2D enemy in hitEnemies) {
                    Instantiate(critEffect, enemy.transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
                   
                }

                CinemachineShake.Instance.ShakeCamera(0.1f, 0.1f, false);

            }
            else {
             
                actualDamage = attackDamage;
              
            }

            foreach (Collider2D enemy in hitEnemies) {
                Debug.Log("we hit" + enemy.name);

                if (enemy.GetComponent<PlayerHealthSystem>() != null) {
                    enemy.GetComponent<PlayerHealthSystem>().CmdDealDamage(actualDamage);


                    if (critDamage < SetPercentage(critMax, 60)) {
                        enemy.GetComponent<PlayerHealthSystem>().NormalDmgEffect(actualDamage);
                    }


                    if (critDamage >= SetPercentage(critMax, 60)) {
                        enemy.GetComponent<PlayerHealthSystem>().MiddleDmgEffect(actualDamage);
                    }


                    if (critDamage >= SetPercentage(critMax, 80)) {
                        enemy.GetComponent<PlayerHealthSystem>().LargeDmgEffect(actualDamage);
                    }
                }
                else {
                    enemy.GetComponent<PlayerCastleHealthSystem>().TakeDamage(attackDamage);
                }

            }
        }

        if (combo == 4) {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRangeAddition4, enemyLayers);

            int mayCrit = new int();
            mayCrit = Random.Range(1, critRate + 1);
            Debug.Log(mayCrit.ToString());

            if (mayCrit == 1) {
                int critDamage = new int();
                critDamage = Random.Range(critMin, critMax);
                              
                actualDamage += critDamage + attackDamage;
           
                foreach (Collider2D enemy in hitEnemies) {
                    Instantiate(critEffect, enemy.transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
                   
                }

                CinemachineShake.Instance.ShakeCamera(0.1f, 0.1f, false);

            }
            else {
             
                actualDamage = attackDamage;
             

            }

            foreach (Collider2D enemy in hitEnemies) {
                Debug.Log("we hit" + enemy.name);
                if (enemy.GetComponent<PlayerHealthSystem>() != null) {
                    enemy.GetComponent<PlayerHealthSystem>().CmdDealDamage(actualDamage);


                    if (critDamage < SetPercentage(critMax, 60)) {
                        enemy.GetComponent<PlayerHealthSystem>().NormalDmgEffect(actualDamage);
                    }


                    if (critDamage >= SetPercentage(critMax, 60)) {
                        enemy.GetComponent<PlayerHealthSystem>().MiddleDmgEffect(actualDamage);
                    }


                    if (critDamage >= SetPercentage(critMax, 80)) {
                        enemy.GetComponent<PlayerHealthSystem>().LargeDmgEffect(actualDamage);
                    }
                }
                else {
                    enemy.GetComponent<PlayerCastleHealthSystem>().TakeDamage(attackDamage);
                }

            }
        }

    }

    [Command]
    public void NormalCast() {
        NormalCastEffect();
    }

    [ClientRpc]
    public void NormalCastEffect() {

        castPoint.GetComponent<Animator>().SetTrigger("NormalCast");


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(castPoint.transform.position, normalCastRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("we hit" + enemy.name);

     
            if (enemy.GetComponent<PlayerHealthSystem>() != null) {
                enemy.GetComponent<PlayerHealthSystem>().CmdDealDamage((int)normalCastDmg);
                enemy.GetComponent<PlayerHealthSystem>().MagicDmgEffect(normalCastDmg);
            }
            else {
                enemy.GetComponent<PlayerCastleHealthSystem>().TakeDamage((int)normalCastDmg);
            }
        }
    }

    [Command]
    public void SuperCast() {
        SuperCastEffect();
    }

    [ClientRpc]
    public void SuperCastEffect() {

        castPoint.GetComponent<Animator>().SetTrigger("SuperCast");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(castPoint.transform.position, superCastRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("we hit" + enemy.name);
           
            if (enemy.GetComponent<PlayerHealthSystem>() != null) {
                enemy.GetComponent<PlayerHealthSystem>().CmdDealDamage((int)superCastDmg);
                enemy.GetComponent<PlayerHealthSystem>().MagicDmgEffect(superCastDmg);
            }
            else {
                enemy.GetComponent<PlayerCastleHealthSystem>().TakeDamage((int)superCastDmg);
            }

        }
    }


    void OnDrawGizmosSelected() {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRangeAddition1);
    }



}
