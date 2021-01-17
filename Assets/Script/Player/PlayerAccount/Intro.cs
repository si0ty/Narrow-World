using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class Intro : MonoBehaviour
{
    public GameObject volume;
    public CanvasGroup button;
    public AudioManager audioManager;

    private Vector2 startPoint;
    public float endHeight;
    public int beginPanLength;
    public float beginFadeLength;

    public float camerashake;
    public int vibrato;

    public Image logo;
    public Image panel;

    
    public float logoFadeInLength;
    public float logoFadeOutLength;

    public float panelFadeOutLength;

    void Awake() {
       

        volume = GameObject.Find("Global Volume").transform.gameObject;

        volume.SetActive(false);
        startPoint = new Vector2(transform.position.x, transform.position.y);
        logo.DOFade(0, 0);
        StartCoroutine(Delay2());

        button.gameObject.GetComponent<Button>().interactable = false;

       
     
      
    
       
        
    }

    IEnumerator Delay2() {
      
        yield return new WaitForSeconds(1);
        logo.DOFade(1, logoFadeInLength).SetEase(Ease.InOutSine);
        yield return new WaitForSeconds(logoFadeInLength);
        logo.DOFade(0, logoFadeOutLength).SetEase(Ease.InOutSine);

        RideDown();

        yield return new WaitForSeconds(logoFadeInLength + logoFadeOutLength);

        volume.SetActive(true);
        panel.DOFade(0, panelFadeOutLength);

        yield return new WaitForSeconds(beginPanLength);
        

    }
        
       

       
    

    private void RideDown() {
        transform.DOMoveY(endHeight, beginPanLength).SetEase(Ease.InOutSine);
        transform.GetComponent<CinemachineShake>().ShakeCamera(3f, beginPanLength, true);

      
    }

  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            beginFadeLength = 1;
            beginPanLength = 3;
            panelFadeOutLength = 1;
        }

        if (transform.position.y < 2) {
            button.gameObject.GetComponent<Button>().interactable = true;

            button.DOFade(1, 2);

            int random = new int();
            random = UnityEngine.Random.Range(1, 3);

            if (random == 1) {

            
               audioManager.Play("SlowTheme2");

              
            

            }
            if (random == 2) {

              
              audioManager.Play("FastTheme2");

             
            }

        }
    }
}
