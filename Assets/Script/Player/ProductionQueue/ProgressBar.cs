using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;


public class ProgressBar : MonoBehaviour 
{ 
    private Slider slider;
   
    public GameObject sparkBurst;

    public ParticleSystem particleSystem;
    public BuildQueue buildQueue;

    private bool firstBurst;
    private bool secondBurst;

   

    private void Start() {
        slider = GetComponent<Slider>();
       

      
    }

    private void Update() {

        if (slider.value == 0) {

            particleSystem.Stop();
        }



        if (buildQueue.buildQueue.Count >= 1)
            {


         


                if (slider.value != 0) {

                if (!particleSystem.isPlaying) {
                    particleSystem.Play();
                }
                    /*

                if (slider.value >= GetFloatPercentage(slider.maxValue, 33.33333333f)) {
                 
                    if(!firstBurst) {
                        
                       
                        GameObject particleBurst = new GameObject();
                        particleBurst = Instantiate(sparkBurst, transform.localPosition, Quaternion.identity);

                        particleBurst.transform.SetParent(transform);
                        firstBurst = true;
                    }
            
                }

                if (slider.value >= GetFloatPercentage(slider.maxValue, 66.666666f)) {
                 
                    if (!secondBurst) {
                        GameObject particleBurst2 = new GameObject();
                      
                        particleBurst2 = Instantiate(sparkBurst, particleSystem.transform.localPosition, Quaternion.identity);

                        particleBurst2.transform.SetParent(particleSystem.transform);
                        secondBurst = true;
                    }
                }

                if(slider.value >= slider.maxValue) {
                    firstBurst = false;
                    secondBurst = false;

                }
                    */
               
               
            }
        } 
          
     
    }

    private float GetFloatPercentage(float maxAmount, float desiredChange) {
        float maxNormalized = maxAmount / 100;
        float getPercentage = maxNormalized * desiredChange;
        return getPercentage;
    }


}

	

