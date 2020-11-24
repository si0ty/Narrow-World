using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using RTS;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ChestOpen : MonoBehaviour
{
    private Animator anim;
    public GameObject gold;
    private GameObject goldSpawn;

    public Transform spawnPoint;
    private PlayerResourceManager resourceManager;

    public bool goldReady = true;
    private bool spawned = false;
    private ResourceDisplay display;
    public GameObject timerImage;


    public TMP_Text timer;
    private bool counting = false;

    int mm;
    float ss;

    void Start()
    {
        anim = GetComponent<Animator>();
        display = FindObjectOfType<ResourceDisplay>().GetComponent<ResourceDisplay>();
        resourceManager = GameObject.Find("Player").GetComponent<PlayerResourceManager>();


        StartCoroutine(LateSerialize());
    
      

        timer.DOFade(0, 0);

        
    }

    IEnumerator LateSerialize() {
        yield return new WaitForSeconds(0.1f);
        CheckTimer();

        if (resourceManager.goldReady) {
            timerImage.GetComponent<Animator>().SetBool("Wub", true);
        }


    }

    private void CheckTimer() {
        if(resourceManager.timeStore.Hour + 1 <= System.DateTime.Now.Hour && !resourceManager.goldReady) {
            resourceManager.goldReady = true;
           
        } else {

            LoadTimer();
        }
    }
   
    private void LoadTimer() {
      if(!resourceManager.goldReady) {
            int minutesPassed = 60 - resourceManager.timeStore.Minute + System.DateTime.Now.Minute;
            int secondsPassed = 60 - resourceManager.timeStore.Second + System.DateTime.Now.Minute;

            mm = 60 - minutesPassed;
            ss = 60 - secondsPassed;

            counting = true;
        }
       

      
    }

    private void SetTimer() {

        resourceManager.timeStore = System.DateTime.Now;
        mm = 59;
        ss = 60;

        counting = true;


    }

    void OnMouseOver() {
       

        if (resourceManager.goldReady == true && !spawned) {
            anim.SetBool("Open", true);
            GoldSpawn();
            spawned = true;
        }
    }
    void OnMouseExit() {
        anim.SetBool("Open", false);
        DestroyGold();
        spawned = false;
    }
   
     private void OnMouseDown() {
      if(!goldSpawn) {
            return;
        } else {
            Player.AddResource(ResourceType.BankMoney, goldSpawn.transform.GetComponent<GoldPickUp>().goldAmount, display );
            display.UpdateDisplay(goldSpawn.transform.GetComponent<GoldPickUp>().goldAmount, ResourceType.BankMoney, false);
            timerImage.GetComponent<Animator>().SetBool("Wub", false);
              DestroyGold();
            SetTimer();
            resourceManager.goldReady = false;
            spawned = false;
            timer.DOFade(1, 2);
        }

       


    }

    private void GoldSpawn() {
        
        GameObject goldSpawn = Instantiate(gold, spawnPoint.transform.position, Quaternion.identity);

        this.goldSpawn = goldSpawn;
        goldSpawn.transform.SetParent(gameObject.transform);
    }

    private void DestroyGold() {
        Destroy(goldSpawn);
    }


    private void Update() {
      

        if(counting) {
         
            ss -= Time.deltaTime;
            int seconds = (int)ss % 60;
            if(seconds == 0) {
                ss = 60;
                mm--;
            }
           
            timer.SetText(mm.ToString() + ":" + seconds.ToString());
            if(mm == 0) {
                resourceManager.goldReady = true;
                counting = false;
                timer.DOFade(0, 2);
                
            }
        }
    }
}
