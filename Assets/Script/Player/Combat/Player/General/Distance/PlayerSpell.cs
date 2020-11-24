using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSpell : MonoBehaviour
{
    public string spellName;

    public bool boltSpell;
    public bool fireSpell;
    public bool natureSpell;

    public float speed = 20;
    public int damage = 15;

    public bool hitSomething = false;
    private Rigidbody2D rBody;
    private Collider2D boxCollider;
    public float stunTime = 2;

    private Animator spellAnim;
   

    private float timer;
    public float timerLength;


    
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spellAnim = GetComponent<Animator>();
       rBody.velocity = transform.right * speed;

        timer = timerLength;
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Enemy") {
            
            hitSomething = true;
            spellAnim.SetTrigger("Hit");
            collider.GetComponent<EnemyHealthSystem>().TakeDamage(damage);
            collider.gameObject.GetComponent<EnemyMeleeMovement>().moveSpeed = collider.gameObject.GetComponent<EnemyMeleeMovement>().walkSpeed - 0.10f; 
           
            rBody.isKinematic = true;
            transform.parent = collider.transform;
           
            Destroy(rBody);
            Destroy(boxCollider);
          

        }
    }

   
    void Update()
    {
        if (hitSomething == true) {
            speed = 0;
            
            if (timer <= 0) {
                gameObject.GetComponentInParent<EnemyMeleeMovement>().moveSpeed = gameObject.GetComponentInParent<EnemyMeleeMovement>().walkSpeed + 0.10f;
                Destroy(gameObject);
            }

            timer -= Time.deltaTime;
            
        }


    }

 
}
