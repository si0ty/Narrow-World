﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class PlayerCloseCombat : NetworkBehaviour
{
    public bool caster, supercaster;

    
    public bool inRange;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    private float timeBtwAttack;
    [HideInInspector]
    public float startTimeBtwAttack;

    [HideInInspector]
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

    [HideInInspector]
    public float maxBtwCast;
    private float castBtw = 0;
   
    [HideInInspector]
    public float maxBtwSuperCast;
    private float superCastBtw = 0;
        
    private PlayerRayCast playerRayCast;
    private PlayerMeleeAnimations baseAnimation;
    private PlayerMeleeMovement playerMeleeMovement;

    public float spellRange;
    private int critDamage;

    private void Start() {
        if(caster || supercaster) {
            playerRayCast = GetComponent<PlayerRayCast>();
            superCastBtw = maxBtwSuperCast;
        }
      
        baseAnimation = GetComponent<PlayerMeleeAnimations>();
        playerMeleeMovement = GetComponent<PlayerMeleeMovement>();
    }

    void Awake() {
        timeBtwAttack = 0;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            inRange = true;

        }

        if (other.gameObject.tag == "EnemyCastle") {
            inRange = true;

        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy") {
            inRange = false;
           
        }

        if (other.gameObject.tag == "EnemyCastle") {
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

        if (playerRayCast != null) {


            if (playerRayCast.enemySpotted == true && inRange == false) {

               
                    castPoint.transform.position = new Vector3(playerRayCast.onceEnemyPosition.x, castPoint.transform.position.y, castPoint.transform.position.z);
                    Debug.Log(castPoint.transform.position.ToString());
               
                if (caster == true) {
                    if (castBtw <= 0 && superCastBtw > 0) {

                        playerMeleeMovement.moveSpeed = 0;
                        baseAnimation.NormalCastAnim();
                        castBtw = maxBtwCast;

                    }
                    castBtw -= Time.deltaTime;
                }

                if (supercaster == true) {
                    if (superCastBtw <= 0) {

                        playerMeleeMovement.moveSpeed = 0;
                        baseAnimation.SuperCastAnim();
                        superCastBtw = maxBtwSuperCast;

                    }
                    superCastBtw -= Time.deltaTime;
                }

                if (castBtw > 1 && castBtw < maxBtwCast - 2) {
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


    private void Attack() {


       
       

        if (combo == 1) {

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRangeAddition1, enemyLayers);
            
            int mayCrit = new int();
            mayCrit = Random.Range(1, critRate + 1);
            Debug.Log(mayCrit.ToString());
           
            if (mayCrit == 1) {
                int critDamage = new int();
                critDamage = Random.Range(critMin, critMax);


               
                actualDamage = critDamage + attackDamage;
            

                foreach (Collider2D enemy in hitEnemies) {
                    Instantiate(critEffect, enemy.transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
                

                }

                CinemachineShake.Instance.ShakeCamera(0.1f, 0.1f, false);

            }
            else {
              
                actualDamage = attackDamage;
               

            }



            foreach (Collider2D enemy in hitEnemies) {
                Debug.Log("we hit" + enemy.name + "with " + actualDamage.ToString() + " damage");
                Debug.Log("actual Damage was: " +  actualDamage);

                if (enemy.GetComponent<EnemyHealthSystem>() != null) {
                    enemy.GetComponent<EnemyHealthSystem>().TakeDamage(actualDamage);


                    if (critDamage < SetPercentage(critMax, 60)) {
                        enemy.GetComponent<EnemyHealthSystem>().NormalDmgEffect(actualDamage);
                    }


                    if (critDamage >= SetPercentage(critMax, 60)) {
                        enemy.GetComponent<EnemyHealthSystem>().MiddleDmgEffect(actualDamage);
                    }


                    if (critDamage >= SetPercentage(critMax, 80)) {
                        enemy.GetComponent<EnemyHealthSystem>().LargeDmgEffect(actualDamage);
                    }

                }
                else {
                    enemy.GetComponent<EnemyCastleHealthSystem>().TakeDamage(attackDamage);
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
                actualDamage = critDamage + attackDamage;


                foreach (Collider2D enemy in hitEnemies) {
                    Instantiate(critEffect, enemy.transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
               

                }

                CinemachineShake.Instance.ShakeCamera(0.1f, 0.1f, false);
            }
            else {
               
                actualDamage = attackDamage;
               

            }



            foreach (Collider2D enemy in hitEnemies) {
                Debug.Log("we hit" + enemy.name + "with " + actualDamage.ToString() + " damage");

                if (enemy.GetComponent<EnemyHealthSystem>() != null) {
                    enemy.GetComponent<EnemyHealthSystem>().TakeDamage(actualDamage);


                    if (critDamage < SetPercentage(critMax, 60)) {
                        enemy.GetComponent<EnemyHealthSystem>().NormalDmgEffect(actualDamage);
                    }


                    if (critDamage >= SetPercentage(critMax, 60)) {
                        enemy.GetComponent<EnemyHealthSystem>().MiddleDmgEffect(actualDamage);
                    }


                    if (critDamage >= SetPercentage(critMax, 80)) {
                        enemy.GetComponent<EnemyHealthSystem>().LargeDmgEffect(actualDamage);
                    }

                }
                else {
                    enemy.GetComponent<EnemyCastleHealthSystem>().TakeDamage(attackDamage);
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

                actualDamage = critDamage + attackDamage;


                foreach (Collider2D enemy in hitEnemies) {
                    Instantiate(critEffect, enemy.transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
                 

                }

                CinemachineShake.Instance.ShakeCamera(0.3f, 0.3f, false);

            }
            else {
              
                actualDamage = attackDamage;
              

            }

            foreach (Collider2D enemy in hitEnemies) {
                Debug.Log("we hit" + enemy.name + "with " + actualDamage.ToString() + " damage");
              

                if (enemy.GetComponent<EnemyHealthSystem>() != null) {
                    enemy.GetComponent<EnemyHealthSystem>().TakeDamage(actualDamage);


                    if (critDamage < SetPercentage(critMax, 60)) {
                        enemy.GetComponent<EnemyHealthSystem>().NormalDmgEffect(actualDamage);
                    }


                    if (critDamage >= SetPercentage(critMax, 60)) {
                        enemy.GetComponent<EnemyHealthSystem>().MiddleDmgEffect(actualDamage);
                    }


                    if (critDamage >= SetPercentage(critMax, 80)) {
                        enemy.GetComponent<EnemyHealthSystem>().LargeDmgEffect(actualDamage);
                    }

                }
                else {
                    enemy.GetComponent<EnemyCastleHealthSystem>().TakeDamage(attackDamage);
                }
            }
        }

        if (combo == 4) {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRangeAddition4, enemyLayers);


          
            int mayCrit = Random.Range(1, critRate + 1);
            Debug.Log(mayCrit.ToString());

            if (mayCrit == 1) {
                int critDamage = new int();
                critDamage = Random.Range(critMin, critMax);
                actualDamage = critDamage + attackDamage;



                foreach (Collider2D enemy in hitEnemies) {
                    Instantiate(critEffect, enemy.transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
               

                }

                CinemachineShake.Instance.ShakeCamera(0.1f, 0.1f, false);

            }
            else {
               
                actualDamage = attackDamage;
               

            }

            foreach (Collider2D enemy in hitEnemies) {
                Debug.Log("we hit" + enemy.name + "with " + actualDamage.ToString() + " damage");
                enemy.GetComponent<EnemyHealthSystem>().TakeDamage(actualDamage);

                if (critDamage < SetPercentage(critMax, 60)) {
                    enemy.GetComponent<EnemyHealthSystem>().NormalDmgEffect(actualDamage);
                }


                if (critDamage >= SetPercentage(critMax, 60)) {
                    enemy.GetComponent<EnemyHealthSystem>().MiddleDmgEffect(actualDamage);
                }


                if (critDamage >= SetPercentage(critMax, 80)) {
                    enemy.GetComponent<EnemyHealthSystem>().LargeDmgEffect(actualDamage);
                }
            }
        }

    }

    public void NormalCast() {

        castPoint.GetComponent<Animator>().SetTrigger("NormalCast");


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(castPoint.transform.position, normalCastRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("we hit" + enemy.name);

            if (enemy.GetComponent<EnemyHealthSystem>() != null) {
                enemy.GetComponent<EnemyHealthSystem>().TakeDamage((int)normalCastDmg);
                enemy.GetComponent<EnemyHealthSystem>().MagicDmgEffect(normalCastDmg);
            }
            else {
                enemy.GetComponent<EnemyCastleHealthSystem>().TakeDamage((int)normalCastDmg);
            }

                


         
        }
    }

    public void SuperCast() {

        castPoint.GetComponent<Animator>().SetTrigger("SuperCast");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(castPoint.transform.position, superCastRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("we hit" + enemy.name);

            if (enemy.GetComponent<EnemyHealthSystem>() != null) {
                enemy.GetComponent<EnemyHealthSystem>().TakeDamage((int)superCastDmg);
                enemy.GetComponent<EnemyHealthSystem>().MagicDmgEffect(superCastDmg);
            }
            else {
                enemy.GetComponent<EnemyCastleHealthSystem>().TakeDamage((int)superCastDmg);
            }
           
        }
    }


    void OnDrawGizmosSelected() {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRangeAddition1);
    }
}


