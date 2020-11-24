using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFarCollision : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy") {
           
            if (GetComponentInParent<PlayerDistanceAnimations>() != null) {
                GetComponentInParent<PlayerDistanceAnimations>().IdleAnim();
            }
            else {

                GetComponentInParent<PlayerMeleeAnimations>().IdleAnim();

            }
        }         

    }

    /*

    private void OnTriggerExit2D(Collider2D collidertwo) {
        if (collidertwo.gameObject.tag == "Enemy")

            if (GetComponentInParent<PlayerDistanceAnimations>() != null) {
              GetComponentInParent<PlayerDistanceAnimations>().WalkingAnim();
            }
          else
             GetComponentInParent<PlayerMeleeAnimations>().WalkingAnim();

    } */


}
