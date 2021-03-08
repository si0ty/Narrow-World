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

    public Animator planet;
    public float planetStopPoint;

    void Awake() {
       

        volume = GameObject.Find("Global Volume").transform.gameObject;

        volume.SetActive(false);
        startPoint = new Vector2(transform.position.x, transform.position.y);
       
        StartCoroutine(Delay2());

        button.gameObject.GetComponent<Button>().interactable = false;




      
       
        
    }

    private void Start() {
        StopPlanet();
    }

    public void StopPlanet() {

        StartCoroutine(Stop());
        
    }

    IEnumerator Stop() {
        yield return new WaitForSeconds(planetStopPoint);
        planet.speed = 0;
    }

    IEnumerator Delay2() {
      
        
     
        yield return new WaitForSeconds(logoFadeInLength - 1 );
       

        RideDown();

        yield return new WaitForSeconds(3);

        volume.SetActive(true);
        panel.DOFade(0, panelFadeOutLength);

       
        

    }
        


    private void RideDown() {
        transform.DOMoveY(endHeight, beginPanLength).SetEase(Ease.OutSine);
        transform.GetComponent<CinemachineShake>().ShakeCamera(3f, beginPanLength + 2, true);

      
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

            
               AudioManager.instance.Play("SlowTheme2");

              
            

            }
            if (random == 2) {


                AudioManager.instance.Play("FastTheme2");

             
            }

        }
    }
}
