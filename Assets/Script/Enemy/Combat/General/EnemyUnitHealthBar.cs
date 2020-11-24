using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUnitHealthBar : MonoBehaviour
{


    private EnemyHealthSystem enemyHealthSystem;
    private EnemyCloseCombat enemyCombat;
    private EnemyDistanceCombat enemyDistanceCombat;
    private EnemyRayCast enemyRayCast;

    public bool castle;
   



    private Slider slider;
    
    public Image image;
    public GameObject fill;


    void Start() {
    
        fill.SetActive(false);
        enemyHealthSystem = transform.parent.GetComponentInParent<EnemyHealthSystem>();

        if (!castle) {
            if (enemyHealthSystem.melee == true) { enemyCombat = transform.parent.GetComponentInParent<EnemyCloseCombat>(); }

            if (enemyHealthSystem.mage == true || enemyHealthSystem.distance == true) {
                enemyDistanceCombat = transform.parent.GetComponentInParent<EnemyDistanceCombat>();
                enemyRayCast = transform.parent.GetComponentInParent<EnemyRayCast>();
            }
        }


        slider = GetComponent<Slider>();


        slider.maxValue = enemyHealthSystem.maxHealth;



    }

    IEnumerator TurnOff() {
        yield return new WaitForSeconds(5);
        fill.SetActive(false);
    }

    private void Awake() {
    

        // slider.maxValue = enemyHealthSystem.maxHealth;



    }

    public void HealthUpdate() {
    

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

    void LateUpdate() {
        slider.value = enemyHealthSystem.currentHealth;

    }
}
