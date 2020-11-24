using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ObjectOnUI: MonoBehaviour
{

    private RectTransform rectTransform;
 
    void Start() {
        rectTransform = GetComponent<RectTransform>();

        Vector2 pos = gameObject.transform.position;  // get the game object position
        Vector2 viewportPoint = Camera.main.WorldToViewportPoint(pos);  //convert game object position to VievportPoint

        // set MIN and MAX Anchor values(positions) to the same position (ViewportPoint)
        rectTransform.anchorMin = viewportPoint;
        rectTransform.anchorMax = viewportPoint;


    }





}
