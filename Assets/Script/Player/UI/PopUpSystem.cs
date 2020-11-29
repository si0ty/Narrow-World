using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using Mirror;


public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public GameObject sceneBox;
    public GameObject simpleBox;

    public Animator animator;

    public TMP_Text popUpText;

    public GameObject checkmate;
    public GameObject cancelButton;

    public GameManager sceneLoader;
    private NarrowNetwork network;

    public bool onlineMatch;

    private void Start() {

        sceneLoader = GameObject.Find("GameManager").GetComponent<GameManager>();
        network = GameObject.Find("NetworkManager").GetComponent<NarrowNetwork>();
    }



    private void FadeOut(float scale, float speed) {
        FindObjectOfType<AudioManager>().Play("Page3");
        popUpBox.transform.DOScale(scale, speed);

    }


    public void ScenePopUp(string text, int sceneIndex, float scale) {

        popUpBox.transform.DOScale(scale, 0.3f);
        sceneBox.SetActive(true);

        sceneBox.GetComponentInChildren<TMP_Text>().text = text;

        sceneBox.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() =>


     
            SceneSwitch(sceneIndex)
       
      

         );

        sceneBox.transform.GetChild(5).GetComponent<Button>().onClick.AddListener(() =>
      
        FadeOut(0, 0.3f)); 


    }

   

    public void SimplePopUp(string text, float scale) {
        popUpBox.transform.DOScale(scale, 0.3f);
        simpleBox.SetActive(true);
        simpleBox.GetComponentInChildren<TMP_Text>().text = text;

        simpleBox.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() =>

        FadeOut(0, 0.3f));


    }





    public void SceneSwitch(int sceneIndex) {
        Debug.Log("Test");

        if (sceneIndex == (int)SceneIndexes.MAIN_MENU) {
            Debug.Log("GameFullyLoaded");
            sceneLoader.LoadScene(sceneIndex);

            return;
        }

        if(sceneIndex == (int)SceneIndexes.MAP) {
            sceneLoader.LoadScene(sceneIndex);
            return;
        } 

        sceneLoader.LoadScene(sceneIndex);

      
    }




   





    IEnumerator TransitionTime() {
        yield return new WaitForSeconds(1);

        popUpBox.SetActive(false);
    }
}
