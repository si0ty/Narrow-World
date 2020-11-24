using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public GameObject volume;
    public CanvasGroup button;

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

    void Start() {
        volume = GameObject.Find("Global Volume").transform.gameObject;
        volume.SetActive(false);
        startPoint = new Vector2(transform.position.x, transform.position.y);
        logo.DOFade(0, 0);
        StartCoroutine(Delay2());

      
        
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
        if (transform.position.y < 2 && !button.gameObject.activeSelf) {
            button.gameObject.SetActive(true);
            button.DOFade(1, 2);

           
           int random = Random.Range(1, 3);

            if (random == 1) {
                FindObjectOfType<AudioManager>().Play("SlowTheme2");
            }
            if (random == 2) {

                FindObjectOfType<AudioManager>().Play("FastTheme2");
            }

        }
    }
}
