using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyCastleHealthBar : MonoBehaviour
{

    public EnemyCastleHealthSystem playerHealthSystem;
    private EnemyCloseCombat playerCombat;
    private EnemyDistanceCombat playerDistanceCombat;
    private EnemyRayCast playerRayCast;

    public bool castle;


    private Slider slider;

    public Image image;
    public GameObject fill;


    void Awake() {




        if (!castle) {

            if (playerHealthSystem.melee == true) { playerCombat = GetComponentInParent<EnemyCloseCombat>(); }

            if (playerHealthSystem.mage == true || playerHealthSystem.distance == true) {
                playerDistanceCombat = GetComponentInParent<EnemyDistanceCombat>();
                playerRayCast = GetComponentInParent<EnemyRayCast>();
            }
        }


        slider = GetComponent<Slider>();
        if (playerHealthSystem.maxHealth == 0) {
            Destroy(gameObject);
        }

        image = GetComponentInChildren<Image>();
        slider.maxValue = playerHealthSystem.maxHealth;

    }

    IEnumerator TurnOff() {
        yield return new WaitForSeconds(3);
        fill.SetActive(false);
    }



    public void HealthUpdate() {




    }

    void LateUpdate() {
        slider.value = playerHealthSystem.currentHealth;

    }
}
