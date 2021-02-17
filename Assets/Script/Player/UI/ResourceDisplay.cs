using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
using TMPro;
using UnityEngine.PlayerLoop;

public class ResourceDisplay : MonoBehaviour
{
    public bool ingameMenu;
    
    public TMP_Text goldText;
    public TMP_Text redStoneText;
    public TMP_Text knowledgeText;

    public TMP_Text skillPointsText;

    public TMP_Text playerName;

    public GameObject minusEffect;
    public GameObject plusEffect;

    public GameObject sparkEffect;

    public ChapterCard level1Badge;
    public ChapterCard level2Badge;
    public ChapterCard level3Badge;

    private GameObject text;

    private ButtonAssembler buttonAssembler;

    private int score;
    private int displayScore;
    private bool counting = false;


    private PlayerResourceManager resourceManager;
    private Player player;
    private IngamePlayer ingamePlayer;

    public GameObject goldEffect;
    public GameObject skillEffect;
    public GameObject redStoneEffect;
    public GameObject knowledgeEffect;

    private void Start() {
        StartCoroutine(SetupDelay());

       
     
    }

    IEnumerator SetupDelay() {
        yield return new WaitForSeconds(0.02f);

        player = GameObject.Find("Player").GetComponent<Player>();
        resourceManager = player.GetComponent<PlayerResourceManager>();

        if (playerName != null) {
            playerName.SetText(resourceManager.playerName);
        }


        if (ingameMenu) {
            if(player.demon) {
                ingamePlayer = GameObject.FindGameObjectWithTag("DemonPlayer").GetComponent<IngamePlayer>();
            } else {
                ingamePlayer = GameObject.FindGameObjectWithTag("KnightPlayer").GetComponent<IngamePlayer>();
            }

            goldText.SetText(ingamePlayer.ingameResources[ResourceType.Money].ToString());
            redStoneText.SetText(ingamePlayer.ingameResources[ResourceType.RedStone].ToString());

            if (knowledgeText != null) {
                knowledgeText.SetText(ingamePlayer.ingameResources[ResourceType.Knowledge].ToString());
            }

            buttonAssembler = FindObjectOfType<ButtonAssembler>();
            buttonAssembler.UpdateVisuals();

        }
        else {
            goldText.SetText(Player.bankResources[ResourceType.BankMoney].ToString());
            redStoneText.SetText(Player.bankResources[ResourceType.BankStone].ToString());


            if (skillPointsText != null) {
                skillPointsText.SetText(Player.bankResources[ResourceType.SkillPoints].ToString());
            }
        }

        /*
        UpdateDisplay(0, ResourceType.Money, false);
        UpdateDisplay(0, ResourceType.RedStone, false);
       
        UpdateDisplay(0, ResourceType.Knowledge, false);
        */
    }
 

    IEnumerator CountUpEffect(int value, ResourceType resource) {
        
        if(!counting && ingameMenu) {
            displayScore = ingamePlayer.ingameResources[resource] - value;
            counting = true;
        }


        if(ingameMenu) {
            while (true) {
                if (counting) {

                    displayScore++;

                    if (ingamePlayer.ingameResources[resource] == displayScore) {
                        counting = false;
                        Debug.Log("Stopped");
                        StopAllCoroutines();
                    }

                    //Increment the display score by 1

                   

                    if (resource == ResourceType.Money) {
                        goldText.SetText(displayScore.ToString());
                    }

                    if (resource == ResourceType.RedStone) {
                        redStoneText.SetText(displayScore.ToString());
                    }

                    if (resource == ResourceType.Knowledge) {
                        knowledgeText.SetText(displayScore.ToString());
                    }

                    if (resource == ResourceType.SkillPoints) {
                        skillPointsText.SetText(displayScore.ToString());
                    }

               

                }
                if (value < 500) {
                    yield return new WaitForSeconds(0.01f);
                }
                else if (value >= 500 && value < 1500) {
                    yield return new WaitForSeconds(0.001f);
                }
                else if (value >= 1500) {
                    yield return new WaitForSeconds(0.0001f);
                } // I used .2 secs but you can update it as fast as you want

                else if(displayScore > value - 20) {
                    yield return new WaitForSeconds(0.15f);
                }
            }
        } else {

            if (!counting && !ingameMenu) {
                displayScore = Player.bankResources[resource] - value;
                counting = true;
            }

            while (true) {
                if (counting) {
                    displayScore++;

                    if (Player.bankResources[ResourceType.BankMoney] == displayScore || Player.bankResources[ResourceType.BankStone] == displayScore || Player.bankResources[ResourceType.SkillPoints] == displayScore) {
                        counting = false;
                        StopAllCoroutines();

                    }


                    if (resource == ResourceType.BankMoney && Player.bankResources[ResourceType.BankMoney] > displayScore) {
                      


                            goldText.SetText(displayScore.ToString());

                     
                    }

                    if (resource == ResourceType.BankStone && Player.bankResources[ResourceType.BankStone] > displayScore) {
                        


                            redStoneText.SetText(displayScore.ToString());

                        
                    }

                    if (resource == ResourceType.SkillPoints && Player.bankResources[ResourceType.SkillPoints] > displayScore) {
                        


                            skillPointsText.SetText(displayScore.ToString());

                       
                    }

                

                }

                if (value < 500) {
                    yield return new WaitForSeconds(0.01f);
                }
                else if (value >= 500 && value < 1500) {
                    yield return new WaitForSeconds(0.001f);
                }
                else if (value >= 1500) {
                    yield return new WaitForSeconds(0.0001f);
                }

                else if (displayScore > value - 20) {
                    yield return new WaitForSeconds(0.15f);
                }
            }



        }


    }

    IEnumerator CountDownEffect(int value, ResourceType resource) {

        if (!counting && ingameMenu) {
            displayScore = new int();
            displayScore = ingamePlayer.ingameResources[resource] + value;
            counting = true;
        }

        if (ingameMenu) {
           


            while (true) {
                if (counting) {
                    //Increment the display score by 

                    displayScore--;
                    if (ingamePlayer.ingameResources[resource] == displayScore) {
                        counting = false;
                        Debug.Log("Stopped");
                        StopAllCoroutines();
                    }


                  


                    if (resource == ResourceType.Money) {
                        goldText.SetText(displayScore.ToString());
                    }

                    if (resource == ResourceType.RedStone) {
                        redStoneText.SetText(displayScore.ToString());
                    }

                    if (resource == ResourceType.Knowledge) {
                        knowledgeText.SetText(displayScore.ToString());
                    }

                    if (resource == ResourceType.SkillPoints) {
                        skillPointsText.SetText(displayScore.ToString());
                    }



                }

                if (value < 500) {
                    yield return new WaitForSeconds(0.05f);
                } if (value >= 500 && value < 1500) {
                    yield return new WaitForSeconds(0.03f);
                } if(value >= 1500) {
                    yield return new WaitForSeconds(0.01f);
                }
               // I used .2 secs but you can update it as fast as you want
            }
        } else {
            if(!counting) {
                displayScore = new int();
                displayScore = Player.bankResources[resource] + value;
                counting = true;
            }
            
            while (true) {
                if(counting) {
                  
                        displayScore--;



                    if (resource == ResourceType.BankMoney && Player.bankResources[ResourceType.BankMoney] < displayScore) {
                      
                         

                            goldText.SetText(displayScore.ToString());

                      
                    }

                    if (resource == ResourceType.BankStone && Player.bankResources[ResourceType.BankStone] < displayScore) {
                      
                            

                            redStoneText.SetText(displayScore.ToString());
                       

                    }

                    if (resource == ResourceType.SkillPoints && Player.bankResources[ResourceType.SkillPoints] < displayScore) {
                       
                            

                            skillPointsText.SetText(displayScore.ToString());
                      

                    }



                    if (Player.bankResources[ResourceType.BankMoney] == displayScore || Player.bankResources[ResourceType.BankStone] == displayScore || Player.bankResources[ResourceType.SkillPoints] == displayScore) {
                        counting = false;
                        Debug.Log("Stopped");
                        StopAllCoroutines();

                    }

                }

                if (value < 500) {
                    yield return new WaitForSeconds(0.01f);
                }
                 if (value >= 500 && value < 1500) {
                    yield return new WaitForSeconds(0.03f);
                }
                  if (value >= 1500) {
                    yield return new WaitForSeconds(0.01f);
                }


            }
                                       
        
        }
    
    
    
    }

      




    public void UpdateDisplay(int value, ResourceType resource, bool minus) {

        if (ingameMenu) {
            buttonAssembler.UpdateVisuals();
        }
      

        if (!minus) {
           

            if (resource == ResourceType.Money || resource == ResourceType.BankMoney) {
                GameObject 
                text = 
                Instantiate(plusEffect, transform.position, Quaternion.identity);
                text.GetComponent<TMP_Text>().SetText("+" + value.ToString());
                text.transform.SetParent(this.transform, false);
                text.GetComponent<RectTransform>().localPosition = goldEffect.GetComponent<RectTransform>().transform.localPosition;
            }

            if (resource == ResourceType.RedStone || resource == ResourceType.BankStone) {
                GameObject text = new GameObject();
                text =
                Instantiate(plusEffect, transform.position, Quaternion.identity);
                text.GetComponent<TMP_Text>().SetText("+" + value.ToString());
                text.transform.SetParent(this.transform, false);
                text.GetComponent<RectTransform>().localPosition = redStoneEffect.GetComponent<RectTransform>().transform.localPosition;
            }

            if (resource == ResourceType.Knowledge) {
                GameObject text = new GameObject();
                text =
                Instantiate(plusEffect, transform.position, Quaternion.identity); 
                text.GetComponent<TMP_Text>().SetText("+"+ value.ToString());
                text.transform.SetParent(this.transform);
                text.GetComponent<RectTransform>().localPosition = knowledgeEffect.GetComponent<RectTransform>().transform.localPosition;

            }

            if  (resource == ResourceType.SkillPoints) {
                GameObject text = new GameObject(); 
                text =
                Instantiate(plusEffect, transform.position, Quaternion.identity); 
                text.GetComponent<TMP_Text>().SetText("+" + value.ToString());
                text.transform.SetParent(this.transform);
                text.GetComponent<RectTransform>().localPosition = skillEffect.GetComponent<RectTransform>().transform.localPosition;

            }
            StartCoroutine(CountUpEffect(value, resource));


        } else {
           

            if (resource == ResourceType.Money || resource == ResourceType.BankMoney) {

                GameObject text = new GameObject();
                 text = 
                Instantiate(minusEffect, transform.position, Quaternion.identity);

                text.GetComponent<TMP_Text>().SetText("+" + value.ToString());
                text.transform.SetParent(this.transform);
                text.GetComponent<RectTransform>().localPosition = goldEffect.GetComponent<RectTransform>().transform.localPosition;

            }

            if (resource == ResourceType.RedStone || resource == ResourceType.BankStone) {
                GameObject text = new GameObject();
                text =
                Instantiate(minusEffect, transform.position, Quaternion.identity);
                text.GetComponent<TMP_Text>().SetText("+" + value.ToString());
                text.transform.SetParent(this.transform);
                text.GetComponent<RectTransform>().localPosition = redStoneEffect.GetComponent<RectTransform>().transform.localPosition;

            }

            if (resource == ResourceType.Knowledge) {
                GameObject text = new GameObject();
                text =
                Instantiate(minusEffect, transform.position, Quaternion.identity);
                text.GetComponent<TMP_Text>().SetText("+" + value.ToString());
                text.transform.SetParent(this.transform);
                text.GetComponent<RectTransform>().localPosition = knowledgeEffect.GetComponent<RectTransform>().transform.localPosition;
            }

            if (resource == ResourceType.SkillPoints) {
                GameObject text = new GameObject();
                text =
                Instantiate(minusEffect, transform.position, Quaternion.identity);

                text.GetComponent<TMP_Text>().SetText("+" + value.ToString());
                text.transform.SetParent(this.transform);
                text.GetComponent<RectTransform>().localPosition = skillEffect.GetComponent<RectTransform>().transform.localPosition;

            }

            StartCoroutine(CountDownEffect(value, resource));
        }
        
        /*
        if (level2Badge != null) {
            if(Player.resources[ResourceType.Knowledge] >= resourceManager.requiredTier2) {
                level2Badge.GetComponent<SpriteRenderer>().material = level2Badge.glowMaterial;
                Instantiate(sparkEffect, level2Badge.transform.position, Quaternion.identity);
            } else {
                level2Badge.GetComponent<SpriteRenderer>().material = level2Badge.defaultMaterial;
            }

            if (Player.resources[ResourceType.Knowledge] >= resourceManager.requiredTier3) {
                level2Badge.GetComponent<SpriteRenderer>().material = level3Badge.glowMaterial;
            } else {
                level3Badge.GetComponent<SpriteRenderer>().material = level3Badge.defaultMaterial;
            }
        }

        */
        /* goldText.SetText(Player.resources[RTS.ResourceType.Money].ToString());

         redStoneText.SetText(Player.resources[RTS.ResourceType.RedStone].ToString());

         skillPointsText.SetText(Player.resources[RTS.ResourceType.SkillPoints].ToString()); */
    }
}
