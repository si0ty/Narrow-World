using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentEffects : MonoBehaviour
{
    public ParticleSystem playerParticleSystem;
    public ParticleSystem enemyParticleSystem;
   
    
    void Start()
    {
        playerParticleSystem.Play();
        enemyParticleSystem.Play();

    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
