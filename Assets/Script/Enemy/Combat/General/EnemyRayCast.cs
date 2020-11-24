using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRayCast : MonoBehaviour
{
    public Transform sightStart, sightEnd;

    public bool enemySpotted = false;
    public bool allySpotted = false;

    public Vector2 onceEnemyPosition;
    
    private bool currentPosition = false;

    void FixedUpdate() {
        RayCast();
       
    }

    IEnumerator Wait() {
        currentPosition = true;
        yield return new WaitForSeconds(3);
        currentPosition = false;
    }
 

    void RayCast() {

        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);

        enemySpotted = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("PlayerSprite"));

        allySpotted = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("EnemySprite"));

        RaycastHit2D hit = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("PlayerSprite"));

        hit.point = onceEnemyPosition;


        if (enemySpotted == true && !currentPosition)  {

            StartCoroutine(Wait());
            onceEnemyPosition = hit.point;
            


        }

    }

}
