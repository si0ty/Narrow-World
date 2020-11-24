using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistanceCombat : MonoBehaviour
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
            castPoint.transform.position = new Vector3(enemyRayCast.onceEnemyPosition.x, castPoint.transform.position.y, castPoint.transform.position.z);

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


    public void Shoot() {

        GameObject newArrow = new GameObject();
        newArrow = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        newArrow.GetComponent<Projectile>().speed = projectileSpeed;
    }


    public void NormalCast() {

        castPoint.GetComponent<Animator>().SetTrigger("NormalCast");


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(castPoint.transform.position, normalCastRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("we hit" + enemy.name);
            enemy.GetComponent<PlayerHealthSystem>().TakeDamage(normalCastDmg);
            enemy.GetComponent<PlayerHealthSystem>().MagicDmgEffect(normalCastDmg);
        }
    }

    public void SuperCast() {

        castPoint.GetComponent<Animator>().SetTrigger("SuperCast");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(castPoint.transform.position, superCastRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("we hit" + enemy.name);
            enemy.GetComponent<PlayerHealthSystem>().TakeDamage(superCastDmg);
            enemy.GetComponent<PlayerHealthSystem>().MagicDmgEffect(superCastDmg);
        }
    }


    void OnDrawGizmosSelected() {
        if (castPoint == null) {
            return;
        } else {
            Gizmos.DrawWireSphere(castPoint.transform.position, normalCastRange);
        }
           
       
    }
}
