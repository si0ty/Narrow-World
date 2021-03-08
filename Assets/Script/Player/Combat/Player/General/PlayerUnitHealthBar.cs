using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using Mirror;

using System;
using NarrowWorld.Combat;

public class PlayerUnitHealthBar : NetworkBehaviour
{

    
    [Header("Refrences")]
    [SerializeField] private PlayerHealthSystem playerHealthSystem;
    private PlayerCloseCombat playerCombat;
    private PlayerDistanceCombat playerDistanceCombat;
    private PlayerRayCast playerRayCast;

    public bool castle;

    private Slider slider;

    public Image image;
    public GameObject fill;




    void Start() {

     if(transform.parent.GetComponentInParent<PlayerHealthSystem>() != null) {
            playerHealthSystem = transform.parent.GetComponentInParent<PlayerHealthSystem>();
        }
    

        


        // playerHealthSystem.EventHealthChanged += HandleHealthChanged;

        if (!castle) {

            if (playerHealthSystem.melee == true) { playerCombat = GetComponentInParent<PlayerCloseCombat>(); }

            if (playerHealthSystem.mage == true || playerHealthSystem.distance == true) {
                playerDistanceCombat = GetComponentInParent<PlayerDistanceCombat>();
                playerRayCast = GetComponentInParent<PlayerRayCast>();
            }
        }

        slider = GetComponent<Slider>();

        slider.value = playerHealthSystem.currentHealth;
        slider.maxValue = playerHealthSystem.maxHealth;

        Debug.Log(playerHealthSystem.currentHealth.ToString());

        fill.SetActive(false);
    }

/*
    private void HandleHealthChanged(int currentHealth, int maxHealth) {
        HealthUpdate();
        slider.value = currentHealth / maxHealth;


    }
*/
    IEnumerator TurnOff2() {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }


    IEnumerator TurnOff() {
        yield return new WaitForSeconds(3);
        fill.SetActive(false);
    }


   
    public void HealthUpdate() {
        HealthUpdateEffect();
    }


    public void HealthUpdateEffect() {

        slider.value = playerHealthSystem.currentHealth;
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

  
}
