﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingText : MonoBehaviour
{
    private TMP_Text text;
    private bool animated = false;

    public string displayedText;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TMP_Text>();

      
    }

    IEnumerator TextAnim() {
        animated = true;
        if(animated) {
            yield return new WaitForSeconds(0.8f);
            text.SetText(displayedText);
            yield return new WaitForSeconds(0.8f);
            text.SetText(displayedText + ".");
            yield return new WaitForSeconds(0.8f);
            text.SetText(displayedText + "..");
            yield return new WaitForSeconds(0.8f);
            text.SetText(displayedText + "...");
          
            animated = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!animated) {
            StartCoroutine(TextAnim());
        }
      

    }
}
