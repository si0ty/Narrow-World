using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFade : MonoBehaviour
{
    private Image image;
    private Image damagebar; 
        
        void Start()
    {  
        image = GetComponentInChildren<Image>();
        damagebar = transform.Find("damagebar").GetComponent<Image>();
    }

 

    private void SetHealth(float healthNormalized) {
        image.fillAmount = healthNormalized;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
