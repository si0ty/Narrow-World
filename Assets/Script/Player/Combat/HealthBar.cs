using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public string name;

    public int maxValue;


    private RectTransform rectTransform;
    private Vector3 worldPos; 

    void Start()
    {
      // worldPos = new Vector3(Camera.main.ScreenToWorldPoint(this.transform.position));
        // this.transform.position = ScreenToWorldPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
