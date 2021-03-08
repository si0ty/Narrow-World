using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using NarrowWorld.Combat;

public class EnemyDistanceCombat : NetworkBehaviour
{

    public bool shooter, caster, supercaster;

    public bool fireMage, boltMage, natureMage;

    public Transform firePoint;
    public GameObject projectilePrefab;
    public GameObject aimContraction;

    private EnemyRayCast enemyRayCast;
    public GameObject castPoint;

    public float shootDamage;

    public float normalCastRange;
    public float superCastRange;
    public float shootRange;

    public int normalCastDmg;
    public int superCastDmg;
 

    [HideInInspector]
    public float projectileSpeed;

    private EnemyDistanceAnimations enemyDistanceAnimations;
    private EnemyDistanceMovement enemyDistanceMovement;
    private Animator anim;

    public LayerMask enemyLayers;

    [HideInInspector]
    public float critMax;
    [HideInInspector]
    public float critMin;
    [HideInInspector]
    public float critRate;

  
    public float maxBtwShoot;
    private float shootBtw = 0;

    [HideInInspector]
    public float maxBtwCast;
    private float castBtw = 0;

    [HideInInspector]
    public float maxBtwSuperCast;
    private float superCastBtw = 0;

    private void Start() {
        superCastBtw = maxBtwSuperCast;
        anim = GetComponent<Animator>();

        enemyDistanceAnimations = GetComponent<EnemyDistanceAnimations>();
        enemyDistanceMovement = GetComponent<EnemyDistanceMovement>();

        enemyRayCast = GetComponent<EnemyRayCast>();
    }

    // Update is called once per frame
    void Update() {

        if (castPoint != null) {
            castPoint.transform.localPosition = new Vector3(enemyRayCast.onceEnemyPosition.x, castPoint.transform.localPosition.y, castPoint.transform.localPosition.z);

        }

        if (enemyRayCast.enemySpotted == true) {

         
          
            
            if (shooter == true) {
                if (shootBtw <= 0 && castBtw >= 0) {

                    enemyDistanceMovement.moveSpeed = 0;
                    enemyDistanceAnimations.ShootingAnim();
                    Debug.Log("Enemy Shooting");
                    shootBtw = maxBtwShoot;

                   
                   
                }
                shootBtw -= Time.deltaTime;
            } 

            if (caster == true) {
                if (castBtw <= 0) {
                    if( !supercaster || superCastBtw > 0) {
                        enemyDistanceMovement.moveSpeed = 0;
                        enemyDistanceAnimations.NormalCastAnim();
                        castBtw = maxBtwCast;

                    }              
                } 
                castBtw -= Time.deltaTime;
            } 

            if (supercaster == true) {
                if (superCastBtw <= 0) {

                    enemyDistanceMovement.moveSpeed = 0;
                    enemyDistanceAnimations.SuperCastAnim();
                    superCastBtw = maxBtwSuperCast;
                  

                }
                superCastBtw -= Time.deltaTime;
            }
          

        }
            else {

             enemyDistanceAnimations.WalkingAnim();
        }

       
    }

    [Command]
    public void Shoot() {
        ShootEffect();
    }

    [ClientRpc]
    public void ShootEffect() {

        GameObject newArrow = new GameObject();
        newArrow = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        newArrow.GetComponent<Projectile>().speed = projectileSpeed;
    }

    [Command]
    public void NormalCast() {
        NormalCastEffect();
    }

    [ClientRpc]
    public void NormalCastEffect() {

        castPoint.GetComponent<Animator>().SetTrigger("NormalCast");


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(castPoint.transform.localPosition, normalCastRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("we hit" + enemy.name);
            enemy.GetComponent<PlayerHealthSystem>().CmdDealDamage(normalCastDmg);
            enemy.GetComponent<PlayerHealthSystem>().MagicDmgEffect(normalCastDmg);
        }
    }

    [Command]
    public void SuperCast() {
        SuperCastEffect();
    }

    [ClientRpc]
    public void SuperCastEffect() {

        castPoint.GetComponent<Animator>().SetTrigger("SuperCast");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(castPoint.transform.localPosition, superCastRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("we hit" + enemy.name);
            enemy.GetComponent<PlayerHealthSystem>().CmdDealDamage(superCastDmg);
            enemy.GetComponent<PlayerHealthSystem>().MagicDmgEffect(superCastDmg);
        }
    }


    void OnDrawGizmosSelected() {
        if (castPoint == null) {
            return;
        } else {
            Gizmos.DrawWireSphere(castPoint.transform.localPosition, normalCastRange);
        }
           
       
    }
}
