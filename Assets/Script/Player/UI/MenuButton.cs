using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using RTS;
using System;

public class MenuButton : MonoBehaviour
{
    public bool sceneLoader;
    public bool intro;
    public bool firstLogin;
    public int sceneIndex;


    public bool pageInteract;
    public GameObject menuPage;
    public string popUpText;

    public float tweenSpeed;
    public float tweenScale;

    public bool fade;
    private CanvasGroup canvasGroup;

    public TMP_Text playerNameInput;
        private PlayerResourceManager resources;
    

    public List<GameObject> pagesToClose;

    public GameManager loader;
    public Player player;

    public void Awake() {


        StartCoroutine(Delay());

      

        if (sceneLoader) {
           
                loader = FindObjectOfType<GameManager>().GetComponent<GameManager>();
           
         
         
            GetComponent<Button>().onClick.AddListener(() =>
                
            SceneSwitch(sceneIndex));

           
       } 

      if(firstLogin) {
         
                loader = FindObjectOfType<GameManager>().GetComponent<GameManager>();
          
          
            GetComponent<Button>().onClick.AddListener(() =>
          SetupPlayerName());
            
        }
      
        if(pageInteract) {
            GetComponent<Button>().onClick.AddListener(() =>

           UpdatePage());
            
        } 

        if(fade) {
            canvasGroup = menuPage.GetComponent<CanvasGroup>();
        }
    }

    private IEnumerator Delay() {
        yield return new WaitForSeconds(0.1f);
        player = GameObject.Find("Player").GetComponent<Player>();
        resources = player.GetComponent<PlayerResourceManager>();
        Debug.Log("Player is Working");


    }

    private void SetupPlayerName() {
        if(playerNameInput.text.Length <= 10) {
            FindObjectOfType<AudioManager>().Play("IntroClick");
            resources.playerName = playerNameInput.text;
            resources.SaveResources();
            loader.LoadScene(2);
        } else {
            GameObject.Find("PopUpSystem").GetComponent<PopUpSystem>().SimplePopUp("Maximum 10 characters allowed", 90f);

        }


    }


    private void SceneSwitch(int sceneIndex) {
        if(!intro) {
            GameObject.Find("PopUpSystem").GetComponent<PopUpSystem>().ScenePopUp(popUpText, sceneIndex, 90f);
        } else {
            if(player.logins == 1) {
                loader.LoadScene(1);
            } else {
                loader.LoadScene(2);
            }
          

        }
        
       
    }


    IEnumerator DisableWindow() {

        yield return new WaitForSeconds(0.5f);

        menuPage.gameObject.SetActive(false);
    }
   
    // private bool isOpen = false;
    
    public void UpdatePage() {

        if (pagesToClose != null)
            foreach (GameObject list in pagesToClose) {
                list.SetActive(false);
            }



        menuPage.gameObject.SetActive(true);

            if (fade) {
                canvasGroup.DOFade(tweenScale, tweenSpeed);
            } else
            menuPage.transform.DOScale(tweenScale, tweenSpeed).SetEase(Ease.InCirc);
            
         //   isOpen = true;

       
        
      
        // isOpen = false;
      

    }

  

   
}
