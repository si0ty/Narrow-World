using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NarrowWorld.Combat; 

public class EnemySpell : MonoBehaviour
{
    public string spellName;

    public float speed = 20;
    public int damage = 15;

    public bool hitSomething = false;
    public Rigidbody2D rBody;
    public Collider2D boxCollider;
    public float stunTime = 2;

    public Animator spellAnim;


    private float timer;
    public float timerLength;



    void Start() {
        rBody.velocity =  Vector2.left * speed;

        timer = timerLength;
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy") {

            hitSomething = true;
            spellAnim.SetTrigger("Hit");
            collider.GetComponent<EnemyHealthSystem>().CmdTakeDamage(damage);
            collider.gameObject.GetComponent<EnemyMeleeMovement>().moveSpeed = collider.gameObject.GetComponent<EnemyMeleeMovement>().moveSpeed - 0.10f;

            rBody.isKinematic = true;
            transform.parent = collider.transform;

            Destroy(rBody);
            Destroy(boxCollider);


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
