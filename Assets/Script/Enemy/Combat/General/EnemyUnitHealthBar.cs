using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using NarrowWorld.Combat;


public class EnemyUnitHealthBar : NetworkBehaviour
{


    private EnemyHealthSystem enemyHealthSystem;
    private EnemyCloseCombat enemyCombat;
    private EnemyDistanceCombat enemyDistanceCombat;
    private EnemyRayCast enemyRayCast;

    public bool castle;

    private Slider slider;
    
    public Image image;
    public GameObject fill;


    /*
    private void HandleHealthChanged(object sender, EnemyHealthSystem.HealthChangedEventArgs e) {
        HealthUpdate();
        slider.value = e.Health / e.MaxHealth;
    
    } */

    void Start() {
    
        fill.SetActive(false);

        if(transform.parent.GetComponentInParent<EnemyHealthSystem>() != null) {
            enemyHealthSystem = transform.parent.GetComponentInParent<EnemyHealthSystem>();
        }



       // enemyHealthSystem.EventHealthChanged += HandleHealthChanged;

        if (!castle) {
            if (enemyHealthSystem.melee == true) { enemyCombat = transform.parent.GetComponentInParent<EnemyCloseCombat>(); }

            if (enemyHealthSystem.mage == true || enemyHealthSystem.distance == true) {
                enemyDistanceCombat = transform.parent.GetComponentInParent<EnemyDistanceCombat>();
                enemyRayCast = transform.parent.GetComponentInParent<EnemyRayCast>();
            }
        }


        slider = GetComponent<Slider>();

       
        slider.maxValue = enemyHealthSystem.maxHealth;

        HealthUpdate();

    }


    IEnumerator TurnOff() {
        yield return new WaitForSeconds(5);
        fill.SetActive(false);
    }

 

   
    public void HealthUpdate() {
        HealthUpdateEffect();
    }


    public void HealthUpdateEffect() {
        slider.value = enemyHealthSystem.currentHealth;

        fill.SetActive(true);

        if (enemyHealthSystem.melee == true) {
           
            if (enemyCombat.inRange == true) {
                fill.SetActive(true);

            }
            else {
                StartCoroutine(TurnOff());
          
            }
        }
     

        if (enemyHealthSystem.mage == true || enemyHealthSystem.distance == true  )

        if (enemyRayCast.enemySpotted == true) {
                fill.SetActive(true);

            }
        else {
            StartCoroutine(TurnOff());
        }

      
    }


}
