using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIGroup : MonoBehaviour
{
    private CanvasGroup canvasG;

    // Start is called before the first frame update
    void Start()
    {
        canvasG = GetComponent<CanvasGroup>();
        canvasG.alpha = 0;
    }

  
}
