using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{

    public Transform sightStart, sightEnd;

    public bool enemySpotted = false;
    public bool allySpotted = false;

    public Vector2 onceEnemyPosition;

    private bool currentPosition = false;



    void Update() {
        RayCast();

    }


    IEnumerator Wait() {
        currentPosition = true;
        yield return new WaitForSeconds(3f);

        currentPosition = false;

    }


    void RayCast() {

        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

        enemySpotted = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("EnemySprite"));

        allySpotted = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("AllySprite"));

        RaycastHit2D hit = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("EnemySprite"));

     

        if (enemySpotted == true) {
           
          
            onceEnemyPosition = hit.point;
           


        }

    }
}
