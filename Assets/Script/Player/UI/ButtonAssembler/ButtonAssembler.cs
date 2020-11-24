using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;
using DG.Tweening;
using RTS;

public class ButtonAssembler : MonoBehaviour
{
    // private bool tier2unlock, tier3unlock, tier4unlock;
   

    public int buttonCount;
    public GameObject setupFirstPosition;


    private List<Vector3> positionList;


    private int firstRequierment = 0;
    private int secondRequierment = 250;
    private int thirdRequierment = 750;


    public Button t1AssemblyButton;
    public Button t2AssemblyButton;
    public Button t3AssemblyButton;

    public GameObject t1Assembly;
    public GameObject t2Assembly;
    public GameObject t3Assembly;

    private Player player;
    private PlayerResourceManager resources;

    /*
    public void SetupAssembler() {
        int[] buttonScale = new int[buttonCount];

        foreach (int count in buttonScale) {

        }


    }

    private ButtonAssembler(List<Vector3> positionList1, List<Vector3> positionList2, List<Vector3> positionList3, List<Vector3> positionList4) {


        foreach (Vector3 position in positionList1) {
            World_Sprite.Create(position, new Vector3(.3f, .3f), Color.green);

        }
    }

    */




    public void UpdateVisuals() {

        if (Player.ingameResources[ResourceType.Knowledge] < secondRequierment) {
            t2AssemblyButton.gameObject.GetComponent<ButtonSelector>().SetLocked();
            t3AssemblyButton.gameObject.GetComponent<ButtonSelector>().SetLocked();
            t2AssemblyButton.interactable = false;
            t3AssemblyButton.interactable = false;
            return;
        }

        if (Player.ingameResources[ResourceType.Knowledge] < thirdRequierment) {
            t2AssemblyButton.gameObject.GetComponent<ButtonSelector>().DefaultMaterial();
            t2AssemblyButton.interactable = true;
            t3AssemblyButton.gameObject.GetComponent<ButtonSelector>().SetLocked();
            t3AssemblyButton.interactable = false;
            return;
        }


        if (Player.ingameResources[ResourceType.Knowledge] >= thirdRequierment) {
            t2AssemblyButton.gameObject.GetComponent<ButtonSelector>().DefaultMaterial();
            t2AssemblyButton.interactable = true;
            t3AssemblyButton.gameObject.GetComponent<ButtonSelector>().DefaultMaterial();
            t3AssemblyButton.interactable = true;
            return;
        }

    }


    void Start() {
        player = FindObjectOfType<Player>();
        resources = player.GetComponent<PlayerResourceManager>();

        t1AssemblyButton.gameObject.GetComponent<ButtonSelector>().DefaultMaterial();


        t1AssemblyButton.GetComponent<Button>().onClick.AddListener(() => {
            t1AssemblyButton.gameObject.GetComponent<ButtonSelector>().SetGlow();
            t2AssemblyButton.gameObject.GetComponent<ButtonSelector>().DefaultMaterial();
            t3AssemblyButton.gameObject.GetComponent<ButtonSelector>().DefaultMaterial();

            t1Assembly.SetActive(true);
            
            t2Assembly.SetActive(false);
            t3Assembly.SetActive(false);

            /*   t1Assembly.GetComponent<Animator>().SetTrigger("FadeIn");
            t2Assembly.GetComponent<Animator>().SetTrigger("FadeOut");
            t3Assembly.GetComponent<Animator>().SetTrigger("FadeOut");
            Debug.Log("TEST"); */
        });

        t2AssemblyButton.GetComponent<Button>().onClick.AddListener(() => {
            t2AssemblyButton.gameObject.GetComponent<ButtonSelector>().SetGlow();
            t3AssemblyButton.gameObject.GetComponent<ButtonSelector>().DefaultMaterial();
            t1AssemblyButton.gameObject.GetComponent<ButtonSelector>().DefaultMaterial();

            t1Assembly.SetActive(false);
            t2Assembly.SetActive(true);
            t3Assembly.SetActive(false);
            /*  t1Assembly.GetComponent<Animator>().SetTrigger("FadeOut");
              t2Assembly.GetComponent<Animator>().SetTrigger("FadeIn");
              t3Assembly.GetComponent<Animator>().SetTrigger("FadeOut"); */
        });

        t3AssemblyButton.GetComponent<Button>().onClick.AddListener(() => {
            t3AssemblyButton.gameObject.GetComponent<ButtonSelector>().SetGlow();
            t2AssemblyButton.gameObject.GetComponent<ButtonSelector>().DefaultMaterial();
            t1AssemblyButton.gameObject.GetComponent<ButtonSelector>().DefaultMaterial();

            t1Assembly.SetActive(false);
            t2Assembly.SetActive(false);
            t3Assembly.SetActive(true);

            /*  t1Assembly.GetComponent<Animator>().SetTrigger("FadeOut");
            t2Assembly.GetComponent<Animator>().SetTrigger("FadeOut");
            t3Assembly.GetComponent<Animator>().SetTrigger("FadeIn"); */
        });


        UpdateVisuals();
        /*

        Vector3 startPosition = new Vector3(1, 1, 1);
        startPosition = setupFirstPosition.transform.position;

        List<Vector3> tier1Positions = new List<Vector3>();
        List<Vector3> tier2Positions = new List<Vector3>();
        List<Vector3> tier3Positions = new List<Vector3>();
        List<Vector3> tier4Positions = new List<Vector3>();

        float positionSize = 0.55f;
        
            for (int i = 0; i < buttonCount; i++) {
            tier1Positions.Add((startPosition + new Vector3(1f, 0) * positionSize * i));

        }

        startPosition = new Vector3(setupFirstPosition.transform.position.x + chunk1Spacing, setupFirstPosition.transform.position.y, setupFirstPosition.transform.position.z);

        for (int i = 0; i < buttonCount; i++) {
            tier2Positions.Add((startPosition + new Vector3(1f, 0) * positionSize * i));

        }

        startPosition = new Vector3(setupFirstPosition.transform.position.x + chunk2Spacing, setupFirstPosition.transform.position.y, setupFirstPosition.transform.position.z);

        for (int i = 0; i < buttonCount; i++) {
            tier3Positions.Add((startPosition + new Vector3(1f, 0) * positionSize * i));

        }

        startPosition = new Vector3(setupFirstPosition.transform.position.x + chunk3Spacing, setupFirstPosition.transform.position.y, setupFirstPosition.transform.position.z);

        for (int i = 0; i < buttonCount; i++) {
            tier4Positions.Add((startPosition + new Vector3(1f, 0) * positionSize * i));

        }


        currentAssembly = new ButtonAssembler(tier1Positions, tier2Positions, tier3Positions, tier4Positions);
    }
        */

        // Update is called once per frame

    }
}
