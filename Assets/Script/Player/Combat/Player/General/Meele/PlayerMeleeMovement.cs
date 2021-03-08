using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using NarrowWorld.Combat; 

public class PlayerMeleeMovement : NetworkBehaviour
{
   
    
    public float moveSpeed;

    public float walkSpeed;
    public float runSpeed;

    [HideInInspector]
    public PlayerMeleeAnimations baseAnimation;
    private PlayerCloseCombat playerCombat;
    [HideInInspector]
    public PlayerRayCast rayCast;
    private Animator anim;
    private Rigidbody2D body;

    private int rollCount;
   
    public bool canRun;
    public bool canRoll;

    private float getX;
    private float timer = 0;

    private float distanceXBetween;
    private float positionX;

    private bool walkBack;
    private float pushAmount;
  

    private void Start() {
        body = GetComponent<Rigidbody2D>();
        rayCast = GetComponent<PlayerRayCast>();
        baseAnimation = GetComponent<PlayerMeleeAnimations>();
        moveSpeed = walkSpeed;
        anim = GetComponent<Animator>();
        playerCombat = GetComponent<PlayerCloseCombat>();
        baseAnimation.WalkingAnim();



        if (runSpeed >= 1) {
            canRun = true;
        }
       
    }

    private void Awake() {
       
    }

    IEnumerator Wait() {
        baseAnimation.IdleAnim();
        yield return new WaitForSeconds(1);
        baseAnimation.WalkingAnim();

    }



   

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && collision.gameObject.name != "PlayerCastle") {


            distanceXBetween = transform.position.x - collision.gameObject.transform.position.x;
            if(distanceXBetween <= 0.2) {
                walkBack = true;
            }  


        }
    }

   

    
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy") {
           
          
            GetComponentInChildren<PlayerUnitHealthBar>().fill.SetActive(true);
            baseAnimation.IdleAnim();

        }

        if (collider.gameObject.tag == "Player" && collider.gameObject.name != "PlayerCastle" /* && collider.gameObject.GetComponent<PlayerDistanceCombat>() == null*/) {

            walkBack = false;
            baseAnimation.IdleAnim();

        }
    }


    private void OnTriggerExit2D(Collider2D collidertwo) {
        if (collidertwo.gameObject.tag == "Enemy")
          
       
        GetComponentInChildren<PlayerUnitHealthBar>().fill.SetActive(false);
       

        anim.ResetTrigger("Attack1");
        anim.ResetTrigger("Attack2");
        anim.ResetTrigger("Attack3");
        anim.ResetTrigger("Attack4");

        baseAnimation.WalkingAnim();

        if (collidertwo.gameObject.tag == "Player" && collidertwo.gameObject.name != "PlayerCastle") {

            StartCoroutine(Wait());

        }
    }

    void Update() {

        if (!playerCombat.inRange && moveSpeed > 0f && !walkBack) {


            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
            baseAnimation.WalkingAnim();


        }

        if(walkBack) {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
            baseAnimation.WalkingAnim();
        }


        if (rayCast != null) {

            if (rayCast.enemySpotted == false && rayCast.allySpotted == false && canRun == true) {

                baseAnimation.RunningAnim();
              
            }
             else {
       
            }
        } 

     /*   if (rayCast != null) {
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
