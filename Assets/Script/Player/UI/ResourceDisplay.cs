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


    private void Start() {
        StartCoroutine(SetupDelay());
    }

    IEnumerator SetupDelay() {
        yield return new WaitForSeconds(0.02f);

        player = GameObject.Find("Player").GetComponent<Player>();
        resourceManager = GameObject.Find("Player").GetComponent<PlayerResourceManager>();

        if (playerName != null) {
            playerName.SetText(resourceManager.playerName);
        }


        if (ingameMenu) {
            goldText.SetText(IngamePlayer.ingameResources[ResourceType.Money].ToString());
            redStoneText.SetText(IngamePlayer.ingameResources[ResourceType.RedStone].ToString());

            if (knowledgeText != null) {
                knowledgeText.SetText(IngamePlayer.ingameResources[ResourceType.Knowledge].ToString());
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
            displayScore = Player.ingameResources[resource] - value;
            counting = true;
        }


        if(ingameMenu) {
            while (true) {
                if (counting) {

                    if (Player.ingameResources[resource] == displayScore) {
                        counting = false;
                        Debug.Log("Stopped");
                        yield return null;
                    }

                    displayScore++; //Increment the display score by 1

                   

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
                }
                else if (value >= 500 && value < 1500) {
                    yield return new WaitForSeconds(0.03f);
                }
                else if (value >= 1500) {
                    yield return new WaitForSeconds(0.01f);
                } // I used .2 secs but you can update it as fast as you want
            }
        } else {

            if (!counting && !ingameMenu) {
                displayScore = Player.bankResources[resource] - value;
                counting = true;
            }

            while (true) {
                if (counting) {
                    displayScore++;

                 


                    if (resource == ResourceType.BankMoney && Player.bankResources[ResourceType.BankMoney] > displayScore) {
                      


                            goldText.SetText(displayScore.ToString());

                     
                    }

                    if (resource == ResourceType.BankStone && Player.bankResources[ResourceType.BankStone] > displayScore) {
                        


                            redStoneText.SetText(displayScore.ToString());

                        
                    }

                    if (resource == ResourceType.SkillPoints && Player.bankResources[ResourceType.SkillPoints] > displayScore) {
                        


                            skillPointsText.SetText(displayScore.ToString());

                       
                    }

                    if (Player.bankResources[ResourceType.BankMoney] == displayScore || Player.bankResources[ResourceType.BankStone] == displayScore || Player.bankResources[ResourceType.SkillPoints] == displayScore) {
                        counting = false;
                      
                    }

                }

                if (value < 500) {
                    yield return new WaitForSeconds(0.05f);
                }
                else if (value >= 500 && value < 1500) {
                    yield return new WaitForSeconds(0.03f);
                }
                else if (value >= 1500) {
                    yield return new WaitForSeconds(0.01f);
                }


            }



        }


    }

    IEnumerator CountDownEffect(int value, ResourceType resource) {

        if (!counting && ingameMenu) {
            displayScore = Player.ingameResources[resource] + value;
            counting = true;
        }

        if (ingameMenu) {
           


            while (true) {
                if (counting) {
                    //Increment the display score by 

                    if (Player.ingameResources[resource] == displayScore) {
                        counting = false;
                        Debug.Log("Stopped");
                        yield return null;
                    }


                    displayScore--;


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
                GameObject text = new GameObject(); 
                text =
                Instantiate(plusEffect, new Vector3(goldText.transform.position.x + 0.08f, goldText.transform.position.y - 0.08f, goldText.transform.position.z), Quaternion.identity);
                text.GetComponent<TMP_Text>().SetText("+" + value.ToString());
                text.transform.SetParent(this.transform);
            }

            if (resource == ResourceType.RedStone || resource == ResourceType.BankStone) {
                GameObject text = new GameObject();
                text =
                Instantiate(plusEffect, new Vector3(redStoneText.transform.position.x + 0.08f, redStoneText.transform.position.y - 0.08f, redStoneText.transform.position.z), Quaternion.identity);
                text.GetComponent<TMP_Text>().SetText("+" + value.ToString());
                text.transform.SetParent(this.transform);
            }

            if (resource == ResourceType.Knowledge) {
                GameObject text = new GameObject();
                text =
                  Instantiate(plusEffect, new Vector3(knowledgeText.transform.position.x + 0.08f, knowledgeText.transform.position.y - 0.08f, knowledgeText.transform.position.z), Quaternion.identity);
                text.GetComponent<TMP_Text>().SetText("+"+ value.ToString());
                text.transform.SetParent(this.transform);
            }

            if  (resource == ResourceType.SkillPoints) {
                GameObject text = new GameObject(); 
                text =
                  Instantiate(plusEffect, new Vector3(skillPointsText.transform.position.x + 0.08f, skillPointsText.transform.position.y - 0.08f, skillPointsText.transform.position.z), Quaternion.identity);
                text.GetComponent<TMP_Text>().SetText("+" + value.ToString());
                text.transform.SetParent(this.transform);
            }
            StartCoroutine(CountUpEffect(value, resource));


        } else {
           

            if (resource == ResourceType.Money || resource == ResourceType.BankMoney) {

                GameObject text = new GameObject();
                 text = 
                Instantiate(minusEffect, new Vector3(goldText.transform.position.x + 0.08f, goldText.transform.position.y - 0.08f, goldText.transform.position.z), Quaternion.identity);

                text.GetComponent<TMP_Text>().SetText("+" + value.ToString());
                text.transform.SetParent(this.transform);
            }

            if (resource == ResourceType.RedStone || resource == ResourceType.BankStone) {
                GameObject text = new GameObject();
                text =
              Instantiate(minusEffect, new Vector3(redStoneText.transform.position.x + 0.08f, redStoneText.transform.position.y - 0.08f, redStoneText.transform.position.z), Quaternion.identity);

                text.GetComponent<TMP_Text>().SetText("+" + value.ToString());
                text.transform.SetParent(this.transform);
            }

            if (resource == ResourceType.Knowledge) {
                GameObject text = new GameObject();
                text =
                                  Instantiate(minusEffect, new Vector3(knowledgeText.transform.position.x + 0.08f, knowledgeText.transform.position.y - 0.08f, knowledgeText.transform.position.z), Quaternion.identity);

                text.GetComponent<TMP_Text>().SetText("+" + value.ToString());
                text.transform.SetParent(this.transform);
            }

            if (resource == ResourceType.SkillPoints) {
                GameObject text = new GameObject();
                text =
                                  Instantiate(minusEffect, new Vector3(skillPointsText.transform.position.x + 0.08f, skillPointsText.transform.position.y - 0.08f, skillPointsText.transform.position.z), Quaternion.identity);

                text.GetComponent<TMP_Text>().SetText("+" + value.ToString());
                text.transform.SetParent(this.transform);
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
