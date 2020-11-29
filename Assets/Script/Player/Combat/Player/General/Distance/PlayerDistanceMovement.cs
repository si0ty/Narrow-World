using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerDistanceMovement : NetworkBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    public float moveSpeed;

    [HideInInspector]
    public PlayerDistanceAnimations baseAnimation;

  
    public PlayerDistanceCombat playerCombat;

    [HideInInspector]
    public PlayerRayCast rayCast;
    private Rigidbody2D body;
    private Animator anim;


    public bool canRun;
    public bool canRoll;
    private int rollCount;

    private float pushAmount;
    private float getX;
    private float timer = 0;

    private float distanceXBetween;
    private float positionX;

    private bool walkBack;


    private void Start() {
     
       

    }

    private void Awake() {

        playerCombat = GetComponent<PlayerDistanceCombat>();

        body = GetComponent<Rigidbody2D>();
        moveSpeed = walkSpeed;
        baseAnimation = GetComponent<PlayerDistanceAnimations>();
        rayCast = GetComponent<PlayerRayCast>();
        anim = GetComponent<Animator>();

      
    }

    IEnumerator Wait() {
        baseAnimation.IdleAnim();
        yield return new WaitForSeconds(1);
        baseAnimation.WalkingAnim();

    }

    /*
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {


            distanceXBetween = transform.position.x - collision.gameObject.transform.position.x;
            if (distanceXBetween <= 0.2) {
                walkBack = true;
            }


        }
    }
    */


    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy") {
            GetComponentInChildren<PlayerUnitHealthBar>().fill.SetActive(true);
            baseAnimation.IdleAnim();


        }

        if (collider.gameObject.tag == "Player" && collider.gameObject.name != "PlayerbigCastle") {

            walkBack = false;
            baseAnimation.IdleAnim();
        }

    }


    private void OnTriggerExit2D(Collider2D collidertwo) {
        if (collidertwo.gameObject.tag == "Enemy")
            GetComponentInChildren<PlayerUnitHealthBar>().fill.SetActive(false);
            baseAnimation.WalkingAnim();


        anim.ResetTrigger("Shoot");
        anim.ResetTrigger("NormalCast");
        anim.ResetTrigger("SuperCast");
        

        if (collidertwo.gameObject.tag == "Player") {
           
            StartCoroutine(Wait());

        }
    }


    void Update() {



        if (!rayCast.enemySpotted && moveSpeed > 0f && !walkBack) {

          
                transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
                baseAnimation.WalkingAnim();
         


        }

        if (canRun == true) {

            if (rayCast != null) {

                if (rayCast.enemySpotted == false && rayCast.allySpotted == false) {

                    baseAnimation.RunningAnim();
                    moveSpeed = runSpeed;
                }
            }
        }

        if (canRoll) { 

        if (rayCast != null) {
            if (rayCast.enemySpotted == true && rollCount == 0) {

                baseAnimation.RollingAnim();
                rollCount = 1;
            }
            }
        }

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
