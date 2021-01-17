using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PlayerUnitHealthBar : MonoBehaviour
{

    private PlayerHealthSystem playerHealthSystem;
    private PlayerCloseCombat playerCombat;
    private PlayerDistanceCombat playerDistanceCombat;
    private PlayerRayCast playerRayCast;

    public bool castle;


    private Slider slider;

    public Image image;
    public GameObject fill;


    void Start() {
    
       
        fill.SetActive(false);
        playerHealthSystem = transform.parent.GetComponentInParent<PlayerHealthSystem>();

        if (!castle) {

            if (playerHealthSystem.melee == true) { playerCombat = GetComponentInParent<PlayerCloseCombat>(); }

            if (playerHealthSystem.mage == true || playerHealthSystem.distance == true) {
                playerDistanceCombat = GetComponentInParent<PlayerDistanceCombat>();
                playerRayCast = GetComponentInParent<PlayerRayCast>();
            }
        }

        slider = GetComponent<Slider>();


        slider.maxValue = playerHealthSystem.maxHealth;





    }

    private void Awake() {
   
    }


    IEnumerator TurnOff2() {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }


    IEnumerator TurnOff() {
        yield return new WaitForSeconds(3);
        fill.SetActive(false);
    }

   

    public void HealthUpdate() {
      

        fill.SetActive(true);

        if (playerHealthSystem.melee == true) {

            if (playerCombat.inRange == true) {
                fill.SetActive(true);

            }
            else {
                StartCoroutine(TurnOff());

            }
        }


        if (playerHealthSystem.mage == true || playerHealthSystem.distance == true)

            if (playerRayCast.enemySpotted == true) {
                fill.SetActive(true);

            }
            else {
                StartCoroutine(TurnOff());
            }

    }

    void LateUpdate() {
        slider.value = playerHealthSystem.currentHealth;

    }
}
