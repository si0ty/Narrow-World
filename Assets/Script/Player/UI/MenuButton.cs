using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using RTS;

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
    private Player player;

    public void Start() {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        resources = FindObjectOfType<Player>().GetComponent<PlayerResourceManager>();

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

    private void SetupPlayerName() {
        FindObjectOfType<AudioManager>().Play("IntroClick");
        resources.playerName = playerNameInput.text;
        resources.SaveResources();
        loader.LoadScene(0);
    }


    private void SceneSwitch(int sceneIndex) {
        if(!intro) {
            GameObject.Find("PopUpSystem").GetComponent<PopUpSystem>().ScenePopUp(popUpText, sceneIndex, 90f);
        } else {
            if(player.logins == 1) {
                loader.LoadScene(4);
            } else {
                loader.LoadScene(0);
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
