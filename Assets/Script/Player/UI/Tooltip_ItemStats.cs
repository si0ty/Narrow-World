using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tooltip_ItemStats : MonoBehaviour
{
    private static Tooltip_ItemStats instance;

    [SerializeField]
    private Camera uiCamera;
    [SerializeField]
    private RectTransform canvasRectTransform;

    private Image itemImage;

    private TMP_Text itemNameText;
    private TMP_Text descriptionText;
    private TMP_Text classText;
    private TMP_Text typeText;
    private TMP_Text effectText;
    private TMP_Text tooltipText;

    private string itemNameTextString;
    private string descriptionTextString;
    private string classTextString;
    private string typeTextString;
    private string effectTextString;
    private string tooltipTextString;

    private RectTransform backgroundRectTransform;

    public float textPaddingSize = 6f;
    private int multiplicator = 2;

    private void Awake() {

        instance = this;
        backgroundRectTransform = transform.Find("Background").GetComponent<RectTransform>();
        // tooltipText = transform.Find("Text").GetComponent<TMP_Text>();

    itemNameText = transform.Find("ItemName").GetComponent<TMP_Text>();
    descriptionText = transform.Find("Description").GetComponent<TMP_Text>(); 
    classText = transform.Find("ClassContent").GetComponent<TMP_Text>(); 
    typeText = transform.Find("TypeContent").GetComponent<TMP_Text>(); 
    effectText = transform.Find("EffectContent").GetComponent<TMP_Text>();
        itemImage = transform.Find("ItemImage").GetComponent<Image>();



    }

    private void Start() {
      
        HideTooltip();
    }

    private void Update() {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
        transform.localPosition = new Vector2(localPoint.x + 8, localPoint.y);

      

        Vector2 anchoredPosition = transform.GetComponent<RectTransform>().anchoredPosition;
        if(anchoredPosition.x + backgroundRectTransform.rect.width > canvasRectTransform.rect.width) {
            anchoredPosition.x = canvasRectTransform.rect.width - backgroundRectTransform.rect.width;
        }

        if (anchoredPosition.y - backgroundRectTransform.rect.width > canvasRectTransform.rect.width) {
            anchoredPosition.y = canvasRectTransform.rect.width + backgroundRectTransform.rect.width;
        }
        transform.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
    }

    private void ShowTooltip(Image itemSprite, string itemName, string itemDescription, string classContent, string typeContent, int effect ) {
        gameObject.SetActive(true);
       
         

        transform.SetAsLastSibling();

        itemImage.sprite = itemSprite.sprite;
        itemNameTextString = itemName;
        descriptionTextString = itemDescription;
        classTextString = classContent;
        typeTextString = typeContent;
        effectTextString = effect.ToString();
     



        itemNameText.SetText(itemName);
        descriptionText.SetText(itemDescription);
        classText.SetText(classContent);
        typeText.SetText(typeContent);
        effectText.SetText("+" + effect.ToString() + "%");

        if(itemName.Length > 16) {
            multiplicator += 8;

          
        } 
        
       if (typeContent.Length < 14) {
                multiplicator += 14;
            }
        else {

         

        }



        Vector2 backgroundSize = new Vector2((itemNameText.preferredWidth + 14 + typeText.preferredWidth) + textPaddingSize * multiplicator, backgroundRectTransform.rect.height);
        
        backgroundRectTransform.sizeDelta = backgroundSize;
        multiplicator = 2;
       
        Update();
        }

   
    private void HideTooltip() {
        gameObject.SetActive(false);
    }

    public static void Showtooltip_Static(Image itemSprite, string itemName, string itemDescription, string classContent, string typeContent, int effect) {
        instance.ShowTooltip(itemSprite, itemName, itemDescription, classContent, typeContent, effect);
    }

    public static void HideTooltip_Static() {
        instance.HideTooltip();
    }

    public static void AddTooltip(Transform transform, Image itemSprite, string itemName, string itemDescription, string classContent, string typeContent, int effect) {
        if(transform.GetComponent<Button>() != null) {
            EventTrigger.Entry eventtype = new EventTrigger.Entry();
            eventtype.eventID = EventTriggerType.PointerEnter;
            eventtype.callback.AddListener((eventData) => { Showtooltip_Static(itemSprite, itemName, itemDescription, classContent, typeContent, effect); });

    


            transform.gameObject.AddComponent<EventTrigger>();
            transform.GetComponent<EventTrigger>().triggers.Add(eventtype);



        }
    }

}
