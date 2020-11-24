using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;

public class GoldPickUp : MonoBehaviour
{

    public int lowestGoldAmount;
    public int maxGoldAmount;
    [HideInInspector]
    public int goldAmount;

    private Animator anim;
    private SpriteRenderer sprite;
   
   

    private bool picked;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        goldAmount = new int();
        goldAmount = Random.Range(lowestGoldAmount, maxGoldAmount);

    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if(picked != true) {
        

            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player") {

                picked = true;

                if (collision.gameObject.GetComponent<PlayerValueSetter>() != null) {
                    collision.gameObject.GetComponent<PlayerValueSetter>().GoldPickup(goldAmount);
                }

             
                anim.SetBool("Pickup", true);
                // GetComponent<Collider2D>().enabled = false;

                Destroy(this.gameObject);
                
            }
           
        }
    }        


    private void Update() {
        
        float flickerValue = new float();
        flickerValue = Random.Range(0.8f, 1.4f);

        sprite.material.SetFloat("Intensity", flickerValue);
        
    }

}
