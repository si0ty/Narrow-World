using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeMovement : MonoBehaviour
{

    [HideInInspector]
    public float moveSpeed;
    public float walkSpeed;
    public float runSpeed;

    [HideInInspector]
    public EnemyMeleeAnimations baseAnimation;
    private EnemyCloseCombat enemyCombat;
    [HideInInspector]
    public EnemyRayCast rayCast;
    private Rigidbody2D body;

    private Animator anim; 

    private int rollCount;

    public bool canRun;
    public bool canRoll;

    private float pushAmount;
    private float getX;
    private float timer = 0;

  
    private float distanceX;
    private float keepDistance = 0.5f;
    private bool walkBack = false;

    private void Start() {
        body = GetComponent<Rigidbody2D>();
        rayCast = GetComponent<EnemyRayCast>();
        baseAnimation = GetComponent<EnemyMeleeAnimations>();
        moveSpeed = walkSpeed;

        anim = GetComponent<Animator>();

        enemyCombat = GetComponent<EnemyCloseCombat>();
        baseAnimation.WalkingAnim();

        if (runSpeed >= 1) {
            canRun = true;
        }
    }

    IEnumerator Wait() {
        baseAnimation.IdleAnim();
        yield return new WaitForSeconds(1);
        baseAnimation.WalkingAnim();

    }

    IEnumerator Wait2() {
        baseAnimation.IdleAnim();
        yield return new WaitForSeconds(0.6f);
        baseAnimation.WalkingAnim();

    }

  
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {

            distanceX = transform.position.x - collision.transform.position.x;
            if (distanceX < keepDistance) {
                walkBack = true;
            }
        }
    }
 

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy") {

            baseAnimation.IdleAnim();

        }

        if (collider.gameObject.tag == "Player") {
            GetComponentInChildren<EnemyUnitHealthBar>().fill.SetActive(true);
            baseAnimation.IdleAnim();

        }
    }

    private void OnTriggerExit2D(Collider2D collidertwo) {
        if (collidertwo.gameObject.tag == "Enemy") {
            StartCoroutine(Wait());
            walkBack = false;
        }
                  
        if (collidertwo.gameObject.tag == "Player") {
            GetComponentInChildren<EnemyUnitHealthBar>().fill.SetActive(false);
           

          

            anim.ResetTrigger("Attack1");
            anim.ResetTrigger("Attack2");
            anim.ResetTrigger("Attack3");
            anim.ResetTrigger("Attack4");

        }
    }

    private void Update() {
        
        if(!enemyCombat.inRange && moveSpeed > 0f) {
                     
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
                    baseAnimation.WalkingAnim();
                    
          
        }

        if (walkBack) {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
            baseAnimation.WalkingAnim();


        }
        

        if (rayCast != null) {

            if (rayCast.enemySpotted == false && rayCast.allySpotted == false && canRun == true) {

                baseAnimation.RunningAnim();
                moveSpeed = runSpeed;
            }
        }

        /*
        if (rayCast != null) {
            if (rayCast.enemySpotted == true && rollCount == 0) {

                baseAnimation.RollingAnim();
                rollCount = 1;
            }
        } */


    }



    IEnumerator PushBack() {
        moveSpeed = 0;
        body.AddForce(new Vector2(pushAmount, 0), ForceMode2D.Force);

        yield return new WaitForSeconds(0.6f);

        body.velocity = Vector3.zero;
        body.angularVelocity = 0;

        moveSpeed = walkSpeed;

        StopCoroutine(PushBack());

    }

    public void PushBack(float pushAmount) {
        this.pushAmount = pushAmount;
        StartCoroutine(PushBack());
    }

}