using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using RTS;
using TMPro;




public class LevelSystem : MonoBehaviour
{
    public TMP_Text levelDisplay;
    public Michsky.UI.ModernUIPack.ProgressBar loadingBar;
    public TMP_Text percentageDisplay;
    private PlayerResourceManager resourceManager;

    public float firstLayerMulti;
    public float secondLayerMulti;
    public float thirdLayerMulti;
    public float fourthLayerMulti;


    private int playerLevel;

    private float currentProgress;
    private int maxProgress;

    private int[] levels;

    private bool goalFound = false;
    private float setGoal;

    private Player player;
    private ResourceDisplay display;

    private void Start() 
    
    {
        resourceManager = transform.GetComponent<PlayerResourceManager>();
        player = transform.GetComponent<Player>();


       




        DontDestroyOnLoad(this);
    }

    public IEnumerator Serialize() {

       

        yield return new WaitForSeconds(0.1f);
        display = GameObject.Find("MenuResourceDisplay").GetComponent<ResourceDisplay>();

        playerLevel = resourceManager.playerLevel;

        
            levelDisplay = display.transform.GetChild(6).GetChild(2).GetComponent<TMP_Text>();
            percentageDisplay = display.transform.GetChild(6).GetChild(3).GetComponent<TMP_Text>();
            loadingBar = display.transform.GetChild(6).GetComponent<Michsky.UI.ModernUIPack.ProgressBar>();
            SetLevelValues();
            levelDisplay.SetText(playerLevel.ToString());

            currentProgress = Player.bankResources[ResourceType.EPPoints];





            CheckProgress();

    

    }

    public void FarSerialize() {
        StartCoroutine(Serialize());
    }

    private void SetLevelValues() {
       
        levels = new int[60];

        float multiplicator = 0.3f;
        int baseEP = 600;

        for (int i = 1; i < levels.Length; i++) {

            if (i < 21) {
                float increase = new float();
                increase = baseEP * multiplicator;
                multiplicator += firstLayerMulti;
               
                levels[i] = baseEP + (int)increase; 
            }

            if (i < 41 && i > 20) {
                float increase = new float();
                increase = baseEP * multiplicator;
                multiplicator += secondLayerMulti;

                levels[i] = baseEP + (int)increase;
            }

            if (i < 51 && i > 40) {
                float increase = new float();
                increase = baseEP * multiplicator;
                multiplicator += thirdLayerMulti;

                levels[i] = baseEP + (int)increase;
            }

            if (i < 61 && i > 50) {
                float increase = new float();
                increase = baseEP * multiplicator;
                multiplicator += fourthLayerMulti;

                levels[i] = baseEP + (int)increase;
            }

            maxProgress = levels[playerLevel + 1];
           

        }
    }


    public void LevelIncrease(int increase) {

        StartCoroutine(Increase(increase));
        
    }

    IEnumerator Increase(int increase) {
        
        

        if(!goalFound) {
            setGoal = new float();
            setGoal = currentProgress + increase;
            goalFound = true;
        } 


        if (currentProgress <= setGoal) {  
            float difference = maxProgress - currentProgress;
            currentProgress += GetPercentage(increase, 10);
          

            loadingBar.currentPercent = currentProgress / maxProgress * 100;

            float count = new float();
            count = currentProgress / maxProgress * 100;
            percentageDisplay.SetText(count.ToString() + "%");

            CheckProgress();
           
        }
        else {
            goalFound = false;
            yield return null;
        }
    } 


    public void NextLevel() {
        playerLevel++;
        resourceManager.playerLevel = playerLevel;
        levelDisplay.SetText(playerLevel.ToString());


        //POP UP 

    }

    private void CheckProgress() {

        // loadingBar.currentPercent += currentProgress;
        // percentageDisplay.SetText(currentProgress.ToString() + "%");
        maxProgress = levels[playerLevel + 1];
        currentProgress = Player.bankResources[ResourceType.EPPoints];
        levelDisplay.SetText(playerLevel.ToString());

        float count = new float();
        count = currentProgress / maxProgress * 100;
        percentageDisplay.SetText(count.ToString() + "%");

        loadingBar.currentPercent = currentProgress / maxProgress * 100;


        if (currentProgress >= maxProgress) {
            loadingBar.currentPercent = 0;
            currentProgress = 0;
            percentageDisplay.SetText(0 + "%");
            NextLevel();
            Debug.Log("next Level");
        } else {
           
        }
      
    }

    private float GetPercentage(int maxAmount, int desiredChange) {
        float maxNormalized = maxAmount / 100;
        float getPercentage = maxNormalized * desiredChange;
        return getPercentage;
    }


 
}
