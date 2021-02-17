
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;


public class FollowCursor : MonoBehaviour
{

    private bool control;
    private bool delay = true;
    private Player player;

    private float playerBasePos = -6.37f;
    private float enemyBasePos = 27.15f;

    private void Start() {
        control = false;
        StartCoroutine(Delay());

        player = FindObjectOfType<Player>().GetComponent<Player>();

        if(player.demon) {
            transform.position = new Vector2(enemyBasePos, transform.position.y);
        } else {
            transform.position = new Vector2(playerBasePos, transform.position.y);
        }
    }


    void Follow() {
        Vector3 screenPos = Input.mousePosition;


        if (screenPos.x < Screen.width && screenPos.y > 0 && screenPos.y < Screen.height) {
            Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pz.z = 0;
            gameObject.transform.position = pz;

        }


    }

     void OnBecameInvisible() {
        control = false;
    }

     void OnBecameVisible() {
        control = true;
    }
    private IEnumerator Delay() {
        yield return new WaitForSeconds(10f);
        control = true;
        delay = false;
    }

    void FixedUpdate() {
      if(control && !delay)
        Follow();

    }


   
   






}
