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
    public float goldSpawnDelay;

    public Transform spawnPoint;
    private PlayerResourceManager resourceManager;

    public bool goldReady = true;
    private bool spawned = false;
    private ResourceDisplay display;
    public GameObject timerImage;


    public TMP_Text timer;
    private bool counting = false;
    private int minutesPassed;

    int mm;
    float ss;

    void Start()
    {
        anim = GetComponent<Animator>();
        display = FindObjectOfType<ResourceDisplay>().GetComponent<ResourceDisplay>();
        resourceManager = GameObject.Find("Player").GetComponent<PlayerResourceManager>();


        CheckTimer();


    }


    private void CheckTimer() {
        if(resourceManager.timeStore.Hour != System.DateTime.Now.Hour || resourceManager.timeStore.Day != System.DateTime.Now.Day) {
            resourceManager.goldReady = true;
            spawned = false;
            timer.DOFade(0, 0);
            timerImage.GetComponent<Animator>().SetBool("Wub", true);
            return;
        } else {

            LoadTimer();
        }
    }
   
    private void LoadTimer() {

       System.DateTime nowMinutes = System.DateTime.Now; 
            

        if (nowMinutes.Minute > resourceManager.timeStore.Minute) {

            minutesPassed = nowMinutes.Minute - resourceManager.timeStore.Minute;

            mm = 60 - minutesPassed;
            ss = System.DateTime.Now.Second;

        }
        else if (nowMinutes.Minute < resourceManager.timeStore.Minute) {

            minutesPassed = (60 - resourceManager.timeStore.Minute) + nowMinutes.Minute;

            mm = 60 - minutesPassed;
            ss = 60 - Random.Range(0, 60);
        }

        counting = true;

    }

    private void SetTimer() {

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
            resourceManager.timeStore = System.DateTime.Now;
            resourceManager.goldReady = false;

            resourceManager.SaveResources();
         
            spawned = false;
            timer.DOFade(1, 2);
        }

    }

    IEnumerator SpawnDelay() {
        yield return new WaitForSeconds(goldSpawnDelay);
        goldSpawn = Instantiate(gold, spawnPoint.transform.position, Quaternion.identity);
        goldSpawn.transform.SetParent(gameObject.transform);

    }

    private void GoldSpawn() {

        StartCoroutine(SpawnDelay());
       
        
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
            if(seconds <= 9) {
                timer.SetText(mm.ToString() + ":0" + seconds.ToString());
            }
            if (mm <= 9) {
                timer.SetText("0" + mm.ToString() + ":" + seconds.ToString());
            }
            if (mm == 0 && ss == 0) {
                timerImage.GetComponent<Animator>().SetBool("Wub", true);
                resourceManager.goldReady = true;
                counting = false;
                timer.DOFade(0, 2);
                
            }
        }
    }
}
