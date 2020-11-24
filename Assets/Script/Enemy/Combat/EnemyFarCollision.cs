using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFarCollision : MonoBehaviour
{

    
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {

            if (GetComponentInParent<EnemyDistanceAnimations>() != null) {
                GetComponentInParent<EnemyDistanceAnimations>().IdleAnim();
            } else {
                
                GetComponentInParent<EnemyMeleeAnimations>().IdleAnim();

            }

               

        }

    }

    private void OnTriggerExit2D(Collider2D collidertwo) {
        if (collidertwo.gameObject.tag == "Player")
            if(GetComponentInParent<EnemyDistanceAnimations>() != null) {
                GetComponentInParent<EnemyDistanceAnimations>().WalkingAnim();
            } else
            GetComponentInParent<EnemyMeleeAnimations>().WalkingAnim();


    }

    
}
