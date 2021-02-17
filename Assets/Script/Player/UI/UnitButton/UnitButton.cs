using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTS;
using TMPro;
using Mirror;



public class UnitButton : MonoBehaviour
{
    public bool demon;
    public string buttonName;
    private int unitPrice;

    private Button refferedButton;

    public GameObject spawnPoint;
    public GameObject iconPrefab;

    public string iconName;
    private BuildQueue buildQueue;
    public GameObject castle;
    public HUD hud;
    private ResourceDisplay display;

    private TMP_Text priceTag;
    private IngamePlayer player;

   

    private void Start() {

        StartCoroutine(Delay());

        refferedButton = GetComponent<Button>();
        refferedButton.onClick.AddListener(() => {
            BuyUnit();
        });

        if(!demon) {
           if(iconPrefab.GetComponent<Icon>().unitPrefab.transform.GetChild(0).GetComponentInChildren<PlayerValueSetter>() != null) {
                unitPrice = iconPrefab.GetComponent<Icon>().unitPrefab.transform.GetChild(0).GetComponentInChildren<PlayerValueSetter>().unitPrice;

            } else {
                unitPrice = iconPrefab.GetComponent<Icon>().unitPrefab.GetComponent<PlayerValueSetter>().unitPrice;

            }

        } else if (iconPrefab.GetComponent<Icon>().unitPrefab.transform.GetChild(0).GetComponentInChildren<EnemyValueSetter>()) {
            unitPrice = iconPrefab.GetComponent<Icon>().unitPrefab.transform.GetChild(0).GetComponentInChildren<EnemyValueSetter>().unitPrice;

        } else {
            unitPrice = iconPrefab.GetComponent<Icon>().unitPrefab.GetComponent<EnemyValueSetter>().unitPrice;
        }
        priceTag = transform.GetChild(0).GetComponentInChildren<TMP_Text>();
        priceTag.SetText(unitPrice.ToString());

        if (priceTag.text.Length < 3) {
            transform.GetChild(0).localPosition = new Vector3(transform.GetChild(0).localPosition.x + 10f, transform.GetChild(0).localPosition.y, transform.GetChild(0).localPosition.z);
            return;
        }

        if (priceTag.text.Length < 4) {
            transform.GetChild(0).localPosition = new Vector3(transform.GetChild(0).localPosition.x + 5f, transform.GetChild(0).localPosition.y, transform.GetChild(0).localPosition.z);
        }

    }


    private void Awake() {

      

        if(demon) {
            player = GameObject.FindGameObjectWithTag("DemonPlayer").GetComponent<IngamePlayer>();
        } else {
            player = GameObject.FindGameObjectWithTag("KnightPlayer").GetComponent<IngamePlayer>();

        }
    }

    
    IEnumerator Delay() {
        yield return new WaitForSeconds(1f);

        buildQueue = FindObjectOfType<BuildQueue>().GetComponent<BuildQueue>();
        display = GameObject.Find("IngameResourceDisplay").GetComponent<ResourceDisplay>();


    }

    
    public void BuyUnit() {

        // unitPrice = iconPrefab.GetComponent<Icon>().unitPrice;

  
        if(buildQueue) {
            if (buildQueue.buildQueue.Count == buildQueue.queueMax) {
                Debug.Log("Queue is full");
                return;
            }

        }


        if (player.ingameResources[ResourceType.Money] >= unitPrice) {

            player.SpendResource(ResourceType.Money, unitPrice, display);

            display.UpdateDisplay(unitPrice, ResourceType.Money, true);
           
            Debug.Log("Unit actually bought");

           

            buildQueue.AddUnitToBuildQueue(iconPrefab);

        } else {
            Debug.Log("Not enough Gold bro.");
        }


    }

}



    


