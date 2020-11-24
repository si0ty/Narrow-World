using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    public Material firstGlow;
    public Material secondGlow;
    public Material thirdGlow;
    public Material fourthGlow;

    public int goldCost;


    public int level1Percentage;
    public int level2Percentage;
    public int level3Percentage;

    [HideInInspector]
    public Image itemImage;
    [HideInInspector]
    public Image slotFrame;
    public string itemName;
    public string description;
    public string classContent;
    public string typeContent;
    public int effect;

    private bool positionSet = false;
    float pricePosition;


    [HideInInspector]
    public TMP_Text priceTag;

    public Material defaultMaterial;

    private void Awake() {
        priceTag = GetComponentInChildren<TMP_Text>();
        itemImage = transform.GetChild(1).GetComponent<Image>();
        slotFrame = transform.GetChild(2).GetComponent<Image>();
    }

    void Start()
    {
        transform.GetComponent<Image>().material = defaultMaterial;
      
       
    }

    void OnEnable() {
        priceTag.SetText(goldCost.ToString());      

        if(!positionSet) {
          

            if (priceTag.text.Length <= 3) {
                priceTag.GetComponentInParent<RectTransform>().transform.localPosition = new Vector3(priceTag.GetComponentInParent<RectTransform>().transform.localPosition.x, priceTag.GetComponentInParent<RectTransform>().transform.localPosition.y, priceTag.GetComponentInParent<RectTransform>().transform.localPosition.z);
            }

            if (priceTag.text.Length > 4) {
                priceTag.fontSize = 31.90f;
            }

            positionSet = true;
        }
       
    }

    public void ItemActivated() {
        int random = new int();
        random = Random.Range(1, 5);

        if(random == 1) {
            transform.GetChild(0).GetComponent<Image>().material = firstGlow;
            return;
        }

        if (random == 2) {
            transform.GetChild(0).GetComponent<Image>().material = secondGlow;
            return;
        }

        if (random == 3) {
            transform.GetChild(0).GetComponent<Image>().material = thirdGlow;
            return;
        }

        if (random == 4) {
            transform.GetChild(0).GetComponent<Image>().material = fourthGlow;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
