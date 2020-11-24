using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeRayCast : MonoBehaviour
{
    public Transform sightStart, sightEnd;

    public bool enemySpotted = false;
    public bool allyspotted = false;

    // Update is called once per frame
    void Update() {
        RayCast();

    }

    void RayCast() {
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);
        enemySpotted = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("PlayerSprite"));

        allyspotted = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("EnemySprite"));
    }
}
