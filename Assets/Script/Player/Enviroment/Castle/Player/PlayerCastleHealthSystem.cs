using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerCastleHealthSystem : MonoBehaviour
{
    public string unitName;
    public bool melee, mage, distance;

    public float maxHealth;
    public float currentHealth;

    private SpriteRenderer spriteRenderer;

    public GameObject healthBar;

    private PlayerMeleeAnimations playerMeleeAnimations;
    private PlayerDistanceAnimations playerDistanceAnimations;


    private PlayerMeleeMovement playerMeleeMovement;
    private PlayerDistanceMovement playerDistanceMovement;

    public GameObject damagePopUp;
    public float positionOffset;

    private GameObject worldCanvas;

  


    void Start() {
        currentHealth = maxHealth;
        worldCanvas = GameObject.Find("WorldUI").transform.gameObject;

       
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (melee == true) {
            playerMeleeAnimations = GetComponent<PlayerMeleeAnimations>();
            playerMeleeMovement = GetComponent<PlayerMeleeMovement>();
        }

        if (distance == true) {

            playerDistanceAnimations = GetComponent<PlayerDistanceAnimations>();
            playerDistanceMovement = GetComponent<PlayerDistanceMovement>();
        }

        if (mage == true) {

            playerDistanceAnimations = GetComponent<PlayerDistanceAnimations>();
            playerDistanceMovement = GetComponent<PlayerDistanceMovement>();
        }
    }


    public void NormalDmgEffect(int damage) {
        GameObject points = Instantiate(damagePopUp, transform.position + new Vector3(positionOffset, .5f, 0), Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Normal");
        points.transform.SetParent(worldCanvas.transform, true);
        points.transform.GetChild(0).GetComponent<TMP_Text>().SetText(damage.ToString());
    }

    public void TakeDamage(int damage) {

        currentHealth -= damage;

        if (healthBar.transform.GetChild(0).GetComponentInChildren<Image>().enabled == false) {
            healthBar.GetComponent<PlayerCastleHealthBar>().HealthUpdate();
        }

        NormalDmgEffect(damage);
             
        if (melee == true) {

            if (playerMeleeAnimations != null) {
                playerMeleeAnimations.HurtAnim();
                GetComponent<PlayerMeleeMovement>().PushBack(-3f);
            }

            healthBar.GetComponent<PlayerCastleHealthBar>().HealthUpdate();



            if (currentHealth <= 0) {
                playerMeleeAnimations.Die();
            }
        }

        if (distance == true) {

            playerDistanceAnimations.HurtAnim();
            healthBar.GetComponent<PlayerCastleHealthBar>().HealthUpdate();
            GetComponent<PlayerDistanceMovement>().PushBack(-10f);

            if (currentHealth <= 0) {
                playerDistanceAnimations.Die();
            }
        }

        if (mage == true) {

            playerDistanceAnimations.HurtAnim();
            healthBar.GetComponent<PlayerCastleHealthBar>().HealthUpdate();
            GetComponent<PlayerDistanceMovement>().PushBack(-3f);

            if (currentHealth <= 0) {
                playerDistanceAnimations.Die();
            }
        }



    }
}
