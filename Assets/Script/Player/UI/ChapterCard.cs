using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTS;

public class ChapterCard : MonoBehaviour
{
   
    private Animator anim;
    private bool active;

    private Player player;

    [HideInInspector]
    public Image image;

    public GameObject skillPage;
    public GameObject otherSkillPage1;
    public GameObject otherSkillPage2;
    public GameObject otherSkillPage3;

    public GameObject badge1;
    public GameObject badge2;
    public GameObject badge3;

   

    public Material defaultMaterial;
    public Material glowMaterial;

    private int tier1Requirement = 0;
    private int tier2Requirement = 250;
    private int tier3Requirement = 750;

    public bool withAnim;
    public bool withGlow;
    public bool ingame;

    private int playerKnowledge;

  

    void Start() {
        image.material = defaultMaterial;

     



        player = GameObject.Find("Player").GetComponent<Player>();

    }


    private void OnEnable() {
        if (ingame) {


            if (withGlow) {

               
                if (skillPage.activeSelf) {
                        image.material = glowMaterial;
                }
               

                if (skillPage.name == "Tier1") {

                    if (Player.ingameResources[ResourceType.Knowledge] >= tier1Requirement) {


                        badge1.transform.GetComponent<Image>().material = defaultMaterial;
                        Color color = new Color();
                        color = image.color;

                        color.a = 1f;

                        badge1.transform.GetComponent<Image>().color = color;

                        badge1.transform.GetComponent<Button>().interactable = true;

                        badge1.transform.GetComponent<Button>().onClick.AddListener(() => {
                            Activate();
                        });




                    }
                }


                if(skillPage.name == "Tier2") {


                    if (Player.ingameResources[ResourceType.Knowledge] <= tier2Requirement) {


                        badge2.GetComponent<Image>().material = defaultMaterial;

                        Color color = new Color();
                        color = image.color;
                        color.a = 0.45f;
                        badge2.transform.GetComponent<Image>().color = color;




                    }
                    else {


                        badge2.GetComponent<Image>().material = defaultMaterial;
                        Color color = new Color();
                        color = image.color;
                        color.a = 1f;
                        badge2.transform.GetComponent<Image>().color = color;

                        badge2.GetComponent<Button>().interactable = true;

                        badge2.transform.GetComponent<Button>().onClick.AddListener(() => {
                            Activate();
                        });

                    }
                }



                if (skillPage.name == "Tier3") {

                    if (Player.ingameResources[ResourceType.Knowledge] <= tier3Requirement) {


                        if (playerKnowledge < tier3Requirement) {



                            badge3.GetComponent<Image>().material = defaultMaterial;

                            Color color = new Color();
                            color = image.color;
                            color.a = 0.45f;
                            badge3.transform.GetComponent<Image>().color = color;


                        }
                        else {


                            badge3.GetComponent<Image>().material = defaultMaterial;
                            Color color = new Color();
                            color = image.color;
                            color.a = 1f;
                            badge3.transform.GetComponent<Image>().color = color;

                            badge3.GetComponent<Button>().interactable = true;

                            badge3.transform.GetComponent<Button>().onClick.AddListener(() => {
                                Activate();
                            });

                        }
                    }
                }

            }

            }
    }
      

       
   

    private void Awake() {
      
        image = GetComponent<Image>();
      

       

        if (withAnim) {
            anim = GetComponent<Animator>();
        }      

       
    }



    private void OnMouseExit() {
        if(active) {
            return;
        } else if (withAnim) {
            anim.SetBool("Clicked", false);
        }

       
    }

    private void OnMouseOver() {
        
        if (active == false && withAnim)
        anim.SetBool("Clicked", true);
        else {
            return;
        }
    }
    

    private void OnMouseDown() {
        int random = new int();
        random = Random.Range(1, 3);
        if (random == 1) {
            FindObjectOfType<AudioManager>().Play("Page1");

        }
        if(random == 2) {
            FindObjectOfType<AudioManager>().Play("Page2");
        }
        Activate();
    }


    private void Activate() {
    


        skillPage.SetActive(true);
        Debug.Log("TEST");
        if (withGlow) { image.material = glowMaterial; }

        active = true;


        otherSkillPage1.GetComponent<ChapterCard>().skillPage.SetActive(false);
        if (badge2 != null) {
            badge2.GetComponent<Image>().material = defaultMaterial;
        }
        otherSkillPage1.GetComponent<ChapterCard>().active = false;



        otherSkillPage2.GetComponent<ChapterCard>().skillPage.SetActive(false);
        if (badge3 != null) {
            badge3.GetComponent<Image>().material = defaultMaterial;
        }

        otherSkillPage2.GetComponent<ChapterCard>().active = false;


        if (otherSkillPage3 != null) {
            otherSkillPage3.GetComponent<ChapterCard>().skillPage.SetActive(false);
          
            otherSkillPage3.GetComponent<ChapterCard>().active = false;
        }



        if (withAnim) {
            anim.SetBool("Clicked", true);
            otherSkillPage1.GetComponent<ChapterCard>().anim.SetBool("Clicked", false);
            otherSkillPage2.GetComponent<ChapterCard>().anim.SetBool("Clicked", false);
            otherSkillPage3.GetComponent<ChapterCard>().anim.SetBool("Clicked", false);
        }
    }

 
}
