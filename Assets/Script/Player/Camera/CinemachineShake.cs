﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{

    public static CinemachineShake Instance { get; private set; }
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;

    private float shakeTimerTotal;
    private float startingIntensity;

    private bool fade;

    private void Awake() {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    

    public void ShakeCamera(float intensity, float time, bool fade) {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;


        this.fade = fade;
      shakeTimer = time;

    shakeTimerTotal = time;
    startingIntensity = intensity;
}

private void Update() {
        if(shakeTimer > 0) {
            shakeTimer -= Time.deltaTime;

            if(fade) {
                
                if (shakeTimer <= 6) {
                    CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                  cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                    if (cinemachineBasicMultiChannelPerlin.m_AmplitudeGain > 0)
                    cinemachineBasicMultiChannelPerlin.m_AmplitudeGain =- 0.001f;
                }
         
             
            }
            if(shakeTimer <= 0f) {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                     cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
                    
                    //Mathf.Lerp(startingIntensity, 0f, (1 - (shakeTimer / shakeTimerTotal)) );
            }
        }
    }
}
