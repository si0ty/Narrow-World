using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ShopButton : MonoBehaviour
{

    public string buttonName;
    public int buttonIndex;

    public GameObject shopPage; 
    public List<GameObject> shopPages;

    private bool isOpen = false;
   

    void Start()
    {
        shopPages.Add(shopPage);
    }

    public void UpdateShopPage() {
       
        
            if (!isOpen) {

            foreach (GameObject page in shopPages)
                page.gameObject.SetActive(false);
            shopPage.gameObject.SetActive(true);
            isOpen = true;
        } else {

                shopPage.gameObject.SetActive(false);
                 isOpen = false;

        }

            
        }    
        
}
  

