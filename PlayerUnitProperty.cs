using System;
using UnityEngine;
using System.Collections;


public class PlayerUnitProperty : MonoBehaviour
{
    public int health;
    public float speed;
    
    
    private float dazedTime;
    public float startDazedTime;

    private Animator anim;
    public GameObject bloodEffect;

    void Start() {

        anim = GetComponent<Animator>();

        if (dazedTime <= 0) {
            speed = 5;
        }
        else {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (health <= 0) {
            Destroy(gameObject);
        }

       
    }

    public void TakeDamage(int damage) {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("Damage Taken!");
    }




}
