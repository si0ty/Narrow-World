using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSetter : MonoBehaviour
{
    private Player player;
     public  ShopSystem shopSystem;

    void Start() {

        shopSystem = GetComponentInParent<ShopSystem>();
        player = FindObjectOfType<Player>().GetComponent<Player>();
        Serialize();
       
    }

    public void Serialize() {
        StartCoroutine(Serialization());
    }

    public IEnumerator Serialization() {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Items successful Initilized");
       
        shopSystem.SetPlayerItems(player.GetPlayerItems());
        shopSystem.UpdateVisuals();
        transform.parent.gameObject.SetActive(false);
      
    }
    // Update is called once per frame
    void Update() {

    }
}
