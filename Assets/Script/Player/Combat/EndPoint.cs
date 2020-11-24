using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private float xPos;
    public  float yPos;

    private PlayerDistanceCombat playerDistanceCombat;
    private PlayerCloseCombat playerCloseCombat;

    private EnemyDistanceCombat enemyDistanceCombat;
    private EnemyCloseCombat enemyCloseCombat;

    void Awake() {

        if (GetComponentInParent<PlayerDistanceCombat>() != null) {
            playerDistanceCombat = GetComponentInParent<PlayerDistanceCombat>();
            transform.localPosition = new Vector3(playerDistanceCombat.shootRange, yPos, 0);
        }

        if (GetComponentInParent<PlayerCloseCombat>() != null) {
            playerCloseCombat = GetComponentInParent<PlayerCloseCombat>();
            transform.localPosition = new Vector3(playerCloseCombat.spellRange, yPos, 0);
        }


        if (GetComponentInParent<EnemyDistanceCombat>() != null) {
            enemyDistanceCombat = GetComponentInParent<EnemyDistanceCombat>();
            transform.localPosition = new Vector3(enemyDistanceCombat.shootRange, yPos, 0);
        }

        if (GetComponentInParent<EnemyCloseCombat>() != null) {
            enemyCloseCombat = GetComponentInParent<EnemyCloseCombat>();
            transform.localPosition = new Vector3(enemyCloseCombat.spellRange, yPos, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
