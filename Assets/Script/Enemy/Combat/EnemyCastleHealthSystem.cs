using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCastleHealthSystem : MonoBehaviour
{
    public string unitName;
    public bool melee, mage, distance;

    public float maxHealth;
    public float currentHealth;

    private SpriteRenderer spriteRenderer;

    public GameObject healthBar;

    private EnemyMeleeAnimations playerMeleeAnimations;
    private EnemyDistanceAnimations playerDistanceAnimations;


    private EnemyMeleeMovement playerMeleeMovement;
    private EnemyDistanceMovement playerDistanceMovement;

    public GameObject damagePopUp;

    private GameObject worldCanvas;




    void Start() {
        currentHealth = maxHealth;
        worldCanvas = GameObject.Find("WorldUI").transform.gameObject;


        spriteRenderer = GetComponent<SpriteRenderer>();

        if (melee == true) {
            playerMeleeAnimations = GetComponent<EnemyMeleeAnimations>();
            playerMeleeMovement = GetComponent<EnemyMeleeMovement>();
        }

        if (distance == true) {

            playerDistanceAnimations = GetComponent<EnemyDistanceAnimations>();
            playerDistanceMovement = GetComponent<EnemyDistanceMovement>();
        }

        if (mage == true) {

            playerDistanceAnimations = GetComponent<EnemyDistanceAnimations>();
            playerDistanceMovement = GetComponent<EnemyDistanceMovement>();
        }
    }


    public void TakeDamage(int damage) {

        currentHealth -= damage;

        if (healthBar.transform.GetChild(0).GetComponentInChildren<Image>().enabled == false) {
            healthBar.GetComponent<PlayerCastleHealthBar>().HealthUpdate();
        }

        GameObject points = Instantiate(damagePopUp, transform.position + new Vector3(-5f, .5f, 0), Quaternion.identity) as GameObject;
        points.transform.SetParent(worldCanvas.transform, true);
        points.transform.GetChild(0).GetComponent<TMP_Text>().SetText(damage.ToString());


        if (melee == true) {

            if (playerMeleeAnimations != null) {
                playerMeleeAnimations.HurtAnim();
                GetComponent<EnemyMeleeMovement>().PushBack(-3f);
            }

            healthBar.GetComponent<EnemyCastleHealthBar>().HealthUpdate();



            if (currentHealth <= 0) {
                playerMeleeAnimations.Die();
            }
        }

        if (distance == true) {

            playerDistanceAnimations.HurtAnim();
            healthBar.GetComponent<EnemyCastleHealthBar>().HealthUpdate();
            GetComponent<EnemyDistanceMovement>().PushBack(-10f);

            if (currentHealth <= 0) {
                playerDistanceAnimations.Die();
            }
        }

        if (mage == true) {

            playerDistanceAnimations.HurtAnim();
            healthBar.GetComponent<EnemyCastleHealthBar>().HealthUpdate();
            GetComponent<EnemyDistanceMovement>().PushBack(-3f);

            if (currentHealth <= 0) {
                playerDistanceAnimations.Die();
            }
        }



    }
}
