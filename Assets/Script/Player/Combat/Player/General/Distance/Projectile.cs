using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{

    public string projectileName;
    public bool enemyProjectile;

    public float speed;
    public int damage;
    public bool hitSomething = false;
    public Rigidbody2D rBody;
    public Collider2D boxCollider;
    public float stunTime = 2;


    private float timer;
    public float timerLength;
    public int playerPushback;
    public int enemyPushback;


    void Awake() {
        rBody.velocity = transform.right * speed;

        timer = timerLength;
    }

    public void OnTriggerEnter2D(Collider2D arrowcollider) {
        if (!enemyProjectile) {
            if (arrowcollider.gameObject.tag == "Enemy") {

                hitSomething = true;
                arrowcollider.GetComponent<EnemyHealthSystem>().NormalDmgEffect(damage);
                arrowcollider.GetComponent<EnemyHealthSystem>().TakeDamage(damage);



                if (arrowcollider.GetComponent<EnemyMeleeMovement>() != null) {
                arrowcollider.GetComponent<EnemyMeleeMovement>().PushBack(playerPushback);


                }



                if (arrowcollider.GetComponent<EnemyMeleeMovement>() != null) {
                    arrowcollider.GetComponent<EnemyMeleeMovement>().PushBack(playerPushback);

                }
                else if (arrowcollider.GetComponent<EnemyDistanceMovement>() != null) {
                    arrowcollider.GetComponent<EnemyDistanceMovement>().PushBack(playerPushback);
                }

                rBody.isKinematic = true;
                transform.parent = arrowcollider.transform;

                Destroy(rBody);
                Destroy(boxCollider);

                Debug.Log("Arrow hit");

            }
        }
        else {
            if (arrowcollider.gameObject.tag == "Player") {

                hitSomething = true;
               
                if(arrowcollider.GetComponent<PlayerHealthSystem>() != null) {
                    arrowcollider.GetComponent<PlayerHealthSystem>().NormalDmgEffect(damage);
                    arrowcollider.GetComponent<PlayerHealthSystem>().CmdDealDamage(damage);
                } else {
                    arrowcollider.GetComponent<PlayerCastleHealthSystem>().TakeDamage(damage);
                }
             
             



                if (arrowcollider.GetComponent<PlayerMeleeMovement>() != null) {
                    arrowcollider.GetComponent<EnemyMeleeMovement>().PushBack(enemyPushback);


                }



                if (arrowcollider.GetComponent<PlayerMeleeMovement>() != null) {
                    arrowcollider.GetComponent<PlayerMeleeMovement>().PushBack(enemyPushback);

                }
                else if (arrowcollider.GetComponent<PlayerDistanceMovement>() != null) {
                    arrowcollider.GetComponent<PlayerDistanceMovement>().PushBack(enemyPushback);
                }

                rBody.isKinematic = true;
                transform.parent = arrowcollider.transform;

                Destroy(rBody);
                Destroy(boxCollider);

                Debug.Log("Arrow hit");
            }


        }


        void Update() {
            if (hitSomething == true) {
                speed = 0;

                if (timer <= 0) {
                    gameObject.GetComponentInParent<EnemyMeleeMovement>().moveSpeed = gameObject.GetComponentInParent<EnemyMeleeMovement>().moveSpeed + 0.10f;
                    Destroy(gameObject);
                }

                timer -= Time.deltaTime;

            }


        }


    }
}
