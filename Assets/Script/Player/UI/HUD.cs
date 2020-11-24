using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

using RTS;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GUISkin resourceSkin, ordersSkin;

    public Texture2D buttonHover, buttonClick;


    private float sliderValue;
    private int buildAreaHeight = 5;

    private Player player;

    private Dictionary<ResourceType, int> resourceValues;
    
    private const int ORDERS_BAR_WIDTH = 300 , RESOURCE_BAR_HEIGHT = 40;

    private const int BUILD_IMAGE_WIDTH = 64, BUILD_IMAGE_HEIGHT = 64;

    private const int ICON_WIDTH = 32, ICON_HEIGHT = 32, TEXT_WIDTH = 128, TEXT_HEIGHT = 32;

    public Texture2D[] resources;
    private Dictionary<ResourceType, Texture2D> resourceImages;
   
    public TMP_Text redStoneDisplay;
    public TMP_Text moneyDisplay;
    public TMP_Text epPointsDisplay;
        public 


    void Start() {

        player = GetComponentInParent<Player>();


        resourceValues = new Dictionary<ResourceType, int>();
        

        resourceImages = new Dictionary<ResourceType, Texture2D>();
        for (int i = 0; i < resources.Length; i++) {
            switch (resources[i].name) {
                case "Money":
                    resourceImages.Add(ResourceType.Money, resources[i]);
                    resourceValues.Add(ResourceType.Money, 0);
                    
                    break;
                case "Power":
                    resourceImages.Add(ResourceType.Knowledge, resources[i]);
                    resourceValues.Add(ResourceType.Knowledge, 0);
                  
                    break;
                case "RedStone":
                    resourceImages.Add(ResourceType.RedStone, resources[i]);
                    resourceValues.Add(ResourceType.RedStone, 0);
                   
                    break;
                case "SkillPoints":
                    resourceImages.Add(ResourceType.SkillPoints, resources[i]);
                    resourceValues.Add(ResourceType.SkillPoints, 0);
                    
                    break;
                default: break;
            }
        }

    }

  public void SetResourceValues() {
        redStoneDisplay.SetText(RTS.ResourceType.RedStone.ToString());
        moneyDisplay.SetText(RTS.ResourceType.Money.ToString());
        epPointsDisplay.SetText(RTS.ResourceType.Knowledge.ToString());

    }



   
}
