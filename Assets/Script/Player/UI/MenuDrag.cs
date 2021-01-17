using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuDrag : MonoBehaviour
{
    public bool portal;

    public Material defaultMaterial;
    public Material glowMaterial;

    private Animator anim;
    public GameManager sceneLoader;

    public PopUpSystem popUpSystem;
    private Player player;


    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Player>();

        popUpSystem = GameObject.Find("PopUpSystem").GetComponent<PopUpSystem>();
        sceneLoader = player.GetComponent<GameManager>();

      
    }

    private IEnumerator Initialize() {
        yield return new WaitForSeconds(0.01f);
      
       
    }

    private void Whip() {
     
    }

    private void OnMouseOver() {
        if (!portal) {
            anim.SetBool("Stay", false);
        } else {
            transform.DOScale(1.2f, 1).SetEase(Ease.OutSine);
            GetComponent<SpriteRenderer>().material = glowMaterial;
        }
       
    }

    private void OnMouseExit() {
        if (!portal) {
            anim.SetBool("Stay", true);
        }
        else {
            transform.DOScale(1f, 1).SetEase(Ease.OutSine);
            GetComponent<SpriteRenderer>().material = defaultMaterial;
        }

    }

    private void OnMouseDown() {
        if(portal) {
            player.demon = true;
        } else {
            player.demon = false;
        }
        popUpSystem.ScenePopUp("You really want to start a battle?", 4, 90);
        
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
