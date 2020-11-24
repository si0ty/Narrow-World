using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;
using System;
using DTS;
using RTS;


public class SkillTree : MonoBehaviour
{
    [SerializeField] private Material skillLockedMaterial;
    [SerializeField] private Material skillUnlockableMaterial;
    [SerializeField] private Material skillGlowMaterial;
    [SerializeField] private SkillUnlockPath[] skillUnlockPathArray;
   

    [SerializeField] private Sprite normalLine;
    [SerializeField] private Sprite glowlLine;





    //MeleeDamage
    public GameObject hardenedBladesButton;
    public GameObject sharpBladesButton;
    public GameObject solidGripButton;
    public GameObject agressiveDefence;
    public GameObject strongForged;
    public GameObject piercingBlade;
    public GameObject innerFire;
    public GameObject forTheKing;
    public GameObject knightOfTheKing;

    public GameObject hardenedArrows;
    public GameObject shootingCape;
    public GameObject naturalyCalm;
    public GameObject longForgedArrowTips;
    public GameObject strongerDrag;
    public GameObject enchantedArrowTips;
    public GameObject fullFocus;
    public GameObject vitality;

    public GameObject heatUp;
    public GameObject highVoltage;
    public GameObject fireBolt;
    public GameObject naturalBalance;
    public GameObject devestation;
    public GameObject longerShock;
    public GameObject hardenedLeafs;
    public GameObject strongWinds;
    public GameObject combatDissolve;
    public GameObject royalMagician;

    public GameObject goodFood;
    public GameObject desertersJail;
    public GameObject highEducation;
    public GameObject betterHealth;
    public GameObject strangePotion;



    //MeleeMovement


    //Health
    public Player player;

    
    List<SkillButton> skillButtonList;

    
    private PlayerSkills playerSkills;
    /*
    private void Awake() {

        //MeleeSkills
        hardenedBladesButton.GetComponent<Button_UI>().ClickFunc = () => {
            if (!playerSkills.TryUnlockSkill(PlayerSkills.SkillType.HardenedBlade)) {
                Debug.Log("Cannot be unlocked");
            }
            
        };

        sharpBladesButton.GetComponent<Button_UI>().ClickFunc = () => {
            if (!playerSkills.TryUnlockSkill(PlayerSkills.SkillType.SharpenedBlade)) {
                Debug.Log("Cannot be unlocked");
            }
        };

        solidGripButton.GetComponent<Button_UI>().ClickFunc = () => {
            if (!playerSkills.TryUnlockSkill(PlayerSkills.SkillType.SolidGrip)) {
                Debug.Log("Cannot be unlocked");
            }
        };

        agressiveDefence.GetComponent<Button_UI>().ClickFunc = () => {
            if (!playerSkills.TryUnlockSkill(PlayerSkills.SkillType.AgressiveDefence)) {
                Debug.Log("Cannot be unlocked");
            }
        };

        strongForged.GetComponent<Button_UI>().ClickFunc = () => {
            if (!playerSkills.TryUnlockSkill(PlayerSkills.SkillType.StrongForged)) {
                Debug.Log("Cannot be unlocked");
            }
        };

        piercingBlade.GetComponent<Button_UI>().ClickFunc = () => {
            if (!playerSkills.TryUnlockSkill(PlayerSkills.SkillType.PiercingBlades)) {
                Debug.Log("Cannot be unlocked");
            }
        };

       forTheKing.GetComponent<Button_UI>().ClickFunc = () => {
           if (!playerSkills.TryUnlockSkill(PlayerSkills.SkillType.ForTheKing)) {
               Debug.Log("Cannot be unlocked");
           }
       };

       knightOfTheKing.GetComponent<Button_UI>().ClickFunc = () => {
           if (!playerSkills.TryUnlockSkill(PlayerSkills.SkillType.KnightOfTheKing)) {
               Debug.Log("Cannot be unlocked");
           }
       };

        innerFire.GetComponent<Button_UI>().ClickFunc = () => {
           if (!playerSkills.TryUnlockSkill(PlayerSkills.SkillType.InnerFire)) {
                Debug.Log("Cannot be unlocked");
            }
        }; 

        /*
                //Archery
                hardenedArrows.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.HardenedArrows);
                    Debug.Log("Click");
                };

                shootingCape.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.ShootingCape);
                    Debug.Log("Click");
                };

                naturalyCalm.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.NaturallyCalm);
                    Debug.Log("Click");
                };

                longForgedArrowTips.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.LongForgedArrows);
                    Debug.Log("Click");
                };

                strongerDrag.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.StrongerDrag);
                    Debug.Log("Click");
                };

                enchantedArrowTips.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.EnchantedArrows);
                    Debug.Log("Click");
                };

                fullFocus.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.FullFocus);
                    Debug.Log("Click");
                };

                vitality.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.Vitality);
                    Debug.Log("Click");
                };



                //Magic
                heatUp.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.HeatUp);
                    Debug.Log("Click");
                };

                highVoltage.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.HighVoltage);
                    Debug.Log("Click");
                };

                fireBolt.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.FireBolt);
                    Debug.Log("Click");
                };

                naturalBalance.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.NaturalBalance);
                    Debug.Log("Click");
                };

                devestation.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.Devestation);
                    Debug.Log("Click");
                };

                longerShock.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.LongerShock);
                    Debug.Log("Click");
                };

                hardenedLeafs.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.HardenedLeafs);
                    Debug.Log("Click");
                };

                strongWinds.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.StrongWinds);
                    Debug.Log("Click");
                };

                combatDissolve.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.CombatDissolve);
                    Debug.Log("Click");
                };

                royalMagician.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.RoyalMagician);
                    Debug.Log("Click");
                };




                goodFood.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.GoodFood);
                    Debug.Log("Click");
                };

                desertersJail.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.DesertersJail);
                    Debug.Log("Click");
                };

                highEducation.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.HighEducation);
                    Debug.Log("Click");
                };

               betterHealth.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.BetterHealth);
                    Debug.Log("Click");
                };

                strangePotion.GetComponent<Button_UI>().ClickFunc = () => {
                    playerSkills.UnlockSkill(PlayerSkills.SkillType.StrangePotion);
                    Debug.Log("Click");
                };
       
    }  */

    public PlayerResourceManager resourceManager;

    private void Start() {
       
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(Serialize());
       
    }

    IEnumerator Serialize() {
        yield return new WaitForSeconds(0.4f);
        player = GameObject.Find("Player").GetComponent<Player>();
        resourceManager = player.GetComponent<PlayerResourceManager>();
    }

    public void SetPlayerSkills(PlayerSkills playerSkills) {
       
        this.playerSkills = playerSkills;
        skillButtonList = new List<SkillButton>();
       
        skillButtonList.Add(new SkillButton(hardenedBladesButton.transform, playerSkills, PlayerSkills.SkillType.HardenedBlades, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, hardenedBladesButton.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(sharpBladesButton.transform, playerSkills, PlayerSkills.SkillType.SharpenedBlades, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, sharpBladesButton.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(solidGripButton.transform, playerSkills, PlayerSkills.SkillType.SolidGrip, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, solidGripButton.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(agressiveDefence.transform, playerSkills, PlayerSkills.SkillType.AgressiveDefence, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, agressiveDefence.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(strongForged.transform, playerSkills, PlayerSkills.SkillType.StrongForged, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, strongForged.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(piercingBlade.transform, playerSkills, PlayerSkills.SkillType.PiercingBlades, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, piercingBlade.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(innerFire.transform, playerSkills, PlayerSkills.SkillType.InnerFire, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, innerFire.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(knightOfTheKing.transform, playerSkills, PlayerSkills.SkillType.KnightOfTheKing, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, knightOfTheKing.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(forTheKing.transform, playerSkills, PlayerSkills.SkillType.ForTheKing, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, forTheKing.transform.GetChild(0), player, skillGlowMaterial));

        skillButtonList.Add(new SkillButton(hardenedArrows.transform, playerSkills, PlayerSkills.SkillType.HardenedArrows, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, hardenedArrows.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(shootingCape.transform, playerSkills, PlayerSkills.SkillType.ShootingCape, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, shootingCape.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(naturalyCalm.transform, playerSkills, PlayerSkills.SkillType.NaturallyCalm, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, naturalyCalm.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(longForgedArrowTips.transform, playerSkills, PlayerSkills.SkillType.LongForgedArrows, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, longForgedArrowTips.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(strongerDrag.transform, playerSkills, PlayerSkills.SkillType.StrongerDrag, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, strongerDrag.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(enchantedArrowTips.transform, playerSkills, PlayerSkills.SkillType.EnchantedArrows, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, enchantedArrowTips.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(fullFocus.transform, playerSkills, PlayerSkills.SkillType.FullFocus, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, fullFocus.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(vitality.transform, playerSkills, PlayerSkills.SkillType.Vitality, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, vitality.transform.GetChild(0), player, skillGlowMaterial));

        skillButtonList.Add(new SkillButton(heatUp.transform, playerSkills, PlayerSkills.SkillType.HeatUp, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, heatUp.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(highVoltage.transform, playerSkills, PlayerSkills.SkillType.HighVoltage, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, highVoltage.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(naturalBalance.transform, playerSkills, PlayerSkills.SkillType.NaturalBalance, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, naturalBalance.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(devestation.transform, playerSkills, PlayerSkills.SkillType.Devestation, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, devestation.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(fireBolt.transform, playerSkills, PlayerSkills.SkillType.FireBolt, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, fireBolt.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(strongWinds.transform, playerSkills, PlayerSkills.SkillType.StrongWinds, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, strongWinds.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(longerShock.transform, playerSkills, PlayerSkills.SkillType.LongerShock, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, longerShock.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(hardenedLeafs.transform, playerSkills, PlayerSkills.SkillType.HardenedLeafs, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, hardenedLeafs.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(combatDissolve.transform, playerSkills, PlayerSkills.SkillType.CombatDissolve, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, combatDissolve.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(royalMagician.transform, playerSkills, PlayerSkills.SkillType.RoyalMagician, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, royalMagician.transform.GetChild(0), player, skillGlowMaterial));


        //General
        skillButtonList.Add(new SkillButton(goodFood.transform, playerSkills, PlayerSkills.SkillType.GoodFood, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, goodFood.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(desertersJail.transform, playerSkills, PlayerSkills.SkillType.DesertersJail, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, desertersJail.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(highEducation.transform, playerSkills, PlayerSkills.SkillType.HighEducation, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, highEducation.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(betterHealth.transform, playerSkills, PlayerSkills.SkillType.BetterHealth, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, betterHealth.transform.GetChild(0), player, skillGlowMaterial));
        skillButtonList.Add(new SkillButton(strangePotion.transform, playerSkills, PlayerSkills.SkillType.StrangePotion, skillLockedMaterial, skillUnlockableMaterial, 3, false, skillButtonList, strangePotion.transform.GetChild(0), player, skillGlowMaterial));

        //  playerSkills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;
        UpdateVisuals();
    }

    private void PlayerSkills_OnSkillUnlocked(object sender, PlayerSkills.OnSkillUnlockedEventArgs e) {
        UpdateVisuals();
    }


    public void UpdateVisuals() {
        foreach (SkillButton skillButton in skillButtonList) {
            skillButton.UpdateVisuals();
        }

        //darken all the links

        foreach (SkillUnlockPath skillUnlockPath in skillUnlockPathArray) {
            foreach(Image linkImage in skillUnlockPath.linkImageArray) {
                linkImage.color = new Color(.8f, .8f, .8f);
                linkImage.sprite = normalLine;

            }
        }

        foreach (SkillUnlockPath skillUnlockPath in skillUnlockPathArray) {
            if(playerSkills.IsSkillUnlocked(skillUnlockPath.skillType) && playerSkills.CanUnlock(skillUnlockPath.skillType)) {
                // Skill unlocked or can be unlocked
                foreach (Image linkImage in skillUnlockPath.linkImageArray) {
                    linkImage.color = Color.white;
                    linkImage.sprite = glowlLine;
                }  
            }
            
        }

        foreach (SkillButton skillButton in skillButtonList) {
            skillButton.UpdateVisuals();
        }
    }


   
    private class SkillButton
    {
        private Transform transform;
        private Image image;
        private Image frame;
        private PlayerSkills playerSkills;
        private PlayerSkills.SkillType skillType;
        private Material skillLockedMaterial;
        private Material skillUnlockableMaterial;
        private Material skillGlowMaterial;
        private Player player;

        private bool active;
        private List<SkillButton> skillButtonList;

        private Transform skillPreview;


        private void Awake() {
            skillButtonList = transform.GetComponent<SkillTree>().skillButtonList;


           
        }   

           

        public SkillButton(Transform transform, PlayerSkills playerSkills, PlayerSkills.SkillType skillType, 
            Material skillLockedMaterial, Material skillUnlockableMaterial, int skillPointCost, bool active, List<SkillButton> skillButtonList, Transform skillPreview, Player player, Material skillGlowMaterial) {
            this.transform = transform;
            this.playerSkills = playerSkills;
            this.skillType = skillType;
            this.skillLockedMaterial = skillLockedMaterial;
            this.skillUnlockableMaterial = skillUnlockableMaterial;
            this.skillGlowMaterial = skillGlowMaterial;
            this.skillButtonList = skillButtonList;
            this.active = active;
            this.skillPreview = skillPreview;
            this.player = player;
                 

          

            transform.GetComponent<Button_UI>().ClickFunc = () => {
                Debug.Log("Clicked");
                
                if (!playerSkills.CanUnlock(skillType)) {
                    Debug.Log("Cannot be unlocked");
                } else {
                    foreach (SkillButton button in skillButtonList) {
                        
                        button.transform.GetChild(0).gameObject.SetActive(false);
                    }
                                   
                   transform.GetChild(0).gameObject.SetActive(true);
                    
                   
                }    
            };


            skillPreview.transform.GetComponentInChildren<Button_UI>().ClickFunc = () => {
              
                if (!playerSkills.IsSkillUnlocked(skillType)) { 
                if (playerSkills.TryUnlockSkill(skillType) && transform.GetComponent<SkillValues>().redStoneCost <= Player.bankResources[ResourceType.BankStone] && transform.GetComponent<SkillValues>().skillPointCost <= Player.bankResources[ResourceType.SkillPoints]) {


                        FindObjectOfType<AudioManager>().Play("HardClick");
                    Debug.Log("Skill unlocked" + skillType.ToString());
                    transform.GetComponent<EffectCenter>().UpgradeLevel1(transform.GetComponent<SkillValues>().level1Percentage);
                        transform.GetComponent<EffectCenter>().UpgradeLevel2(transform.GetComponent<SkillValues>().level2Percentage);
                        transform.GetComponent<EffectCenter>().UpgradeLevel3(transform.GetComponent<SkillValues>().level3Percentage);

                        // Player.SpendResource(RTS.ResourceType.RedStone, transform.GetComponent<SkillValues>().redStoneCost);
                        // Player.SpendResource(RTS.ResourceType.SkillPoints, transform.GetComponent<SkillValues>().skillPointCost);
                        Player.SpendResource(ResourceType.BankStone, transform.GetComponent<SkillValues>().redStoneCost, GameObject.Find("MenuResourceDisplay").GetComponent<ResourceDisplay>());
                        Player.SpendResource(ResourceType.SkillPoints, transform.GetComponent<SkillValues>().skillPointCost, GameObject.Find("MenuResourceDisplay").GetComponent<ResourceDisplay>());

                        GameObject.Find("MenuResourceDisplay").GetComponent<ResourceDisplay>().UpdateDisplay(transform.GetComponent<SkillValues>().redStoneCost, ResourceType.BankStone, true);
                        GameObject.Find("MenuResourceDisplay").transform.GetComponent<ResourceDisplay>().UpdateDisplay(transform.GetComponent<SkillValues>().skillPointCost, ResourceType.SkillPoints, true);
                        GameObject.Find("SkillTree").transform.GetComponent<SkillTree>().UpdateVisuals();

                        return;

                }
                else {
                    Debug.Log("Insufficent Resources");
                        return;
                }
                } else {
                    Debug.Log("Skill already unlocked");
                    return;
                }

            };



        }

        public void UpdateVisuals() {
            if (playerSkills.IsSkillUnlocked(skillType)) {
                transform.GetComponent<Image>().material = null;
                transform.GetChild(1).GetComponent<Image>().material = skillGlowMaterial;


            }
           
             else {
                if (playerSkills.CanUnlock(skillType)) {
                  
                    transform.GetComponent<Image>().material = skillUnlockableMaterial;
                    transform.GetChild(1).GetComponent<Image>().material = skillUnlockableMaterial;
                }
                else {
                    transform.GetComponent<Image>().material = skillLockedMaterial;
                    transform.GetChild(1).GetComponent<Image>().material = skillLockedMaterial;

                }
            }
        }


    }

    [System.Serializable]
    public class SkillUnlockPath
    {
        public PlayerSkills.SkillType skillType;
        public Image[] linkImageArray;
    }


}
