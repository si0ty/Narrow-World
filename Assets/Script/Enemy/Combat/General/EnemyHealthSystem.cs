using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealthSystem : MonoBehaviour
{
    public string unitName;
    public bool melee, mage, distance;

    public GameObject healthBar;


    public float maxHealth;
    public float currentHealth;

    private SpriteRenderer spriteRenderer;

    private EnemyMeleeAnimations enemyMeleeAnimations;
    private EnemyDistanceAnimations enemyDistanceAnimations;


    private EnemyMeleeMovement enemyMeeleMovement;
    private EnemyDistanceMovement enemyDistanceMovement;

    private GameObject worldCanvas;

    public GameObject damagePopUp;
    public float positionOffset;


    void Start() {
        worldCanvas = GameObject.Find("WorldUI").transform.gameObject;

        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (melee == true) {
            enemyMeleeAnimations =  GetComponent<EnemyMeleeAnimations>();
            enemyMeeleMovement = GetComponent<EnemyMeleeMovement>();
        } 

        if (distance == true) {

              enemyDistanceAnimations = GetComponent<EnemyDistanceAnimations>();
              enemyDistanceMovement = GetComponent<EnemyDistanceMovement>();
        } 

        if (mage == true) {

            enemyDistanceAnimations = GetComponent<EnemyDistanceAnimations>();
            enemyDistanceMovement = GetComponent<EnemyDistanceMovement>();
        }


    }


    public void NormalDmgEffect(int damage) {
        GameObject points = Instantiate(damagePopUp, transform.position + new Vector3(positionOffset, .5f, 0), Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Normal");
        points.transform.SetParent(worldCanvas.transform, true);
        points.transform.GetChild(0).GetComponent<TMP_Text>().SetText(damage.ToString());
    }

    public void MiddleDmgEffect(int damage) {
        GameObject points = Instantiate(damagePopUp, transform.position + new Vector3(positionOffset, .5f, 0), Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Middle");
        points.transform.SetParent(worldCanvas.transform, true);
        points.transform.GetChild(0).GetComponent<TMP_Text>().SetText(damage.ToString());
    }

    public void LargeDmgEffect(int damage) {
        GameObject points = Instantiate(damagePopUp, transform.position + new Vector3(positionOffset, .5f, 0), Quaternion.identity) as GameObject;
        points.GetComponent<Animator>().SetTrigger("Super");
        points.transform.SetParent(worldCanvas.transform, true);
        points.transform.GetChild(0).GetComponent<TMP_Text>().SetText(damage.ToString());
    }

    public void MagicDmgEffect(int damage) {
        GameObject points = Instantiate(damagePopUp, transform.position + new Vector3(positionOffset, .5f, 0), Quaternion.identity) as GameObject;
        points.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Magic");
        points.transform.SetParent(worldCanvas.transform, true);
        points.transform.GetChild(0).GetComponent<TMP_Text>().SetText(damage.ToString());
    }


    public void TakeDamage(int damage) {

        currentHealth -= damage;
       

        if (healthBar.transform.GetChild(0).GetComponentInChildren<Image>().enabled == false) {
            healthBar.GetComponent<EnemyUnitHealthBar>().HealthUpdate();
        }

       

        GameObject points = Instantiate(damagePopUp, transform.position + new Vector3(0.5f, .5f, 0), Quaternion.identity) as GameObject;
        points.transform.SetParent(worldCanvas.transform, true);
        points.transform.GetChild(0).GetComponent<TMP_Text>().SetText(damage.ToString()); 

        if (melee == true) {

            enemyMeleeAnimations.HurtAnim();
            healthBar.GetComponent<EnemyUnitHealthBar>().HealthUpdate();

            if(currentHealth > 0) {
                GetComponent<EnemyMeleeMovement>().PushBack(60f);
            }

          

            if (currentHealth <= 0) {
                enemyMeleeAnimations.Die();
            }
            
        }

     
          if (distance == true) {

              enemyDistanceAnimations.HurtAnim();
            healthBar.GetComponent<EnemyUnitHealthBar>().HealthUpdate();
          

            if (currentHealth > 0) {
                GetComponent<EnemyDistanceMovement>().PushBack(70f);
            }


            if (currentHealth <= 0) {
                  enemyDistanceAnimations.Die();
              }
          }



        if (mage == true) {

            enemyDistanceAnimations.HurtAnim();
            healthBar.GetComponent<EnemyUnitHealthBar>().HealthUpdate();
            GetComponent<EnemyDistanceMovement>().PushBack(3f);

            if (currentHealth > 0) {
                GetComponent<EnemyDistanceMovement>().PushBack(70f);
            }


            if (currentHealth <= 0) {
                enemyDistanceAnimations.Die();
            }
        }


    }




}
