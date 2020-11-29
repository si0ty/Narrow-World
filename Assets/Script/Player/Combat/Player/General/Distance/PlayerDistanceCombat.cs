using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerDistanceCombat : NetworkBehaviour
{

    public bool shooter, caster, supercaster;

    public bool fireMage, boltMage, natureMage;

    public Transform firePoint;
    public GameObject projectilePrefab;
    public GameObject aimContraction;

    [HideInInspector]
    public float projectileSpeed;



    private PlayerRayCast playerRayCast;
    public GameObject castPoint;


   

    public float shootDamage;

    public float normalCastRange;
    public float superCastRange;
    public float shootRange;


    public float normalCastDmg;
    public float superCastDmg;


    private PlayerDistanceAnimations playerDistanceAnimations;
    private PlayerDistanceMovement playerDistanceMovement;
    private Animator anim;
    private PlayerValueSetter valueSetter;

    public LayerMask enemyLayers;

    [HideInInspector]
    public float critMax;
    [HideInInspector]
    public float critMin;
    [HideInInspector]
    public float critRate;

    public float pushback;

 
    public float maxBtwShoot;
    private float shootBtw = 0;

  
    public float maxBtwCast;
    private float castBtw = 0;

    [HideInInspector]
    public float maxBtwSuperCast;
    private float superCastBtw = 0;

    private GameObject newArrow;

    private void Start() {
      

        anim = GetComponent<Animator>();
        playerDistanceAnimations = GetComponent<PlayerDistanceAnimations>();
        playerDistanceMovement = GetComponent<PlayerDistanceMovement>();
        valueSetter = GetComponent<PlayerValueSetter>();

        playerRayCast = GetComponent<PlayerRayCast>();
       
    }

    private void Awake() {
        superCastBtw = maxBtwSuperCast;
    }



    // Update is called once per frame
    void Update() {

        if (castPoint != null) {
            castPoint.transform.position = new Vector3(playerRayCast.onceEnemyPosition.x, castPoint.transform.position.y, castPoint.transform.position.z);

        }

        if (playerRayCast.enemySpotted == true) {

         


            if (shooter == true) {
                if (shootBtw <= 0 && castBtw >= 0) {

                    playerDistanceMovement.moveSpeed = 0;

                   
                    playerDistanceAnimations.ShootingAnim();
                    shootBtw = maxBtwShoot;
                    playerDistanceAnimations.IdleAnim();

                }
                shootBtw -= Time.deltaTime;
            }

            if (caster == true) {
                if (castBtw <= 0) {
                    if(superCastBtw > 0 || !supercaster ) {

                        playerDistanceMovement.moveSpeed = 0;
                        playerDistanceAnimations.NormalCastAnim();

                        castBtw = maxBtwCast;
                        playerDistanceAnimations.IdleAnim();
                       

                    }

                  

                }
                castBtw -= Time.deltaTime;
            }

            if (supercaster == true) {
                if (superCastBtw <= 0) {

                    playerDistanceMovement.moveSpeed = 0;
                    playerDistanceAnimations.SuperCastAnim();
                    superCastBtw = maxBtwSuperCast;

                    playerDistanceAnimations.IdleAnim();
                }
                superCastBtw -= Time.deltaTime;
            }

         
        }
        else {
            playerDistanceAnimations.WalkingAnim();
        }


    }


    public void Shoot() {

        if(valueSetter.archer == true) {
            projectilePrefab.GetComponent<Projectile>().playerPushback = (int)pushback;
        }
       
        newArrow = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);


       // newArrow.GetComponent<Projectile>().speed = projectileSpeed;


    }


    public void NormalCast() {

        castPoint.GetComponent<Animator>().SetTrigger("NormalCast");


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(castPoint.transform.position, normalCastRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("we hit" + enemy.name);
           
            enemy.GetComponent<EnemyHealthSystem>().TakeDamage((int)normalCastDmg);
            enemy.GetComponent<EnemyHealthSystem>().MagicDmgEffect((int)normalCastDmg);
        }
    }

    public void SuperCast() {

        castPoint.GetComponent<Animator>().SetTrigger("SuperCast");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(castPoint.transform.position, superCastRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("we hit" + enemy.name);
            enemy.GetComponent<EnemyHealthSystem>().TakeDamage((int)superCastDmg);
            enemy.GetComponent<EnemyHealthSystem>().MagicDmgEffect((int)superCastDmg);
        }
    }


    void OnDrawGizmosSelected() {
        if (castPoint == null)
            return;
        Gizmos.DrawWireSphere(castPoint.transform.position, normalCastRange);
    }
}
