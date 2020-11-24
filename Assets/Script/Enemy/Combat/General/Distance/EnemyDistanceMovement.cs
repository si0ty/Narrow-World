using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistanceMovement : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    public float moveSpeed;

    [HideInInspector]
    public EnemyDistanceAnimations baseAnimation;
    [HideInInspector]
    public EnemyRayCast rayCast;
    private Rigidbody2D body;

    public bool canRun;
    public bool canRoll;
    private int rollCount;

    private float pushAmount;
    private float getX;

    private Animator anim;

    private void Start() {
        moveSpeed = walkSpeed;
        baseAnimation = GetComponent<EnemyDistanceAnimations>();
        rayCast = GetComponent<EnemyRayCast>();

        body = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

    }

    IEnumerator Wait() {
        baseAnimation.IdleAnim();
        yield return new WaitForSeconds(0.5f);
        baseAnimation.WalkingAnim();

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
        if (collidertwo.gameObject.tag == "Enemy")

            StartCoroutine(Wait());


        if (collidertwo.gameObject.tag == "Player") {
            GetComponentInChildren<EnemyUnitHealthBar>().fill.SetActive(false);

            baseAnimation.WalkingAnim();

            anim.ResetTrigger("Shoot");
            anim.ResetTrigger("NormalCast");
            anim.ResetTrigger("SuperCast");

        }
    }


    void Update() {


        if (!rayCast.enemySpotted && moveSpeed > 0f) {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
            baseAnimation.WalkingAnim();
        }


      

        if (canRun == true) {

            if (rayCast != null) {

                if (rayCast.enemySpotted == false && rayCast.allySpotted == false) {

                    baseAnimation.RunningAnim();
                    moveSpeed = runSpeed;
                }
            }

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

        yield return new WaitForSeconds(0.5f);

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
