﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTS;
using TMPro;



public class UnitButton : MonoBehaviour
{

    public string buttonName;
    private int unitPrice;

    private Button refferedButton;

    public GameObject spawnPoint;
    public GameObject iconPrefab;

    public string iconName;
    public BuildQueue buildQueue;
    public GameObject castle;
    public HUD hud;
    private ResourceDisplay display;

    private TMP_Text priceTag;

   

    private void Start() {
        refferedButton = GetComponent<Button>();
        refferedButton.onClick.AddListener(() => {
            BuyUnit();
        });

        unitPrice = iconPrefab.GetComponent<Icon>().unitPrefab.GetComponent<PlayerValueSetter>().unitPrice;
        priceTag = transform.GetChild(0).GetComponentInChildren<TMP_Text>();
        priceTag.SetText(unitPrice.ToString());
    }


    private void Awake() {

      
        display = GameObject.Find("IngameResourceDisplay").GetComponent<ResourceDisplay>();
  }

    


    public void BuyUnit() {

       // unitPrice = iconPrefab.GetComponent<Icon>().unitPrice;

        if (buildQueue.buildQueue.Count == buildQueue.queueMax) {
            return;
        }
     

        else if (Player.ingameResources[RTS.ResourceType.Money] >= unitPrice) {

            Player.SpendResource(RTS.ResourceType.Money, unitPrice, display);

            display.UpdateDisplay(unitPrice, RTS.ResourceType.Money, true);
           
            Debug.Log("ButtonPressed");

            buildQueue.AddUnitToBuildQueue(iconPrefab);

        } else {
            Debug.Log("Not enough Gold bro.");
        }


    }

}



    

