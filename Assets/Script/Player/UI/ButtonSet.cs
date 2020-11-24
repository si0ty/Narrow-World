using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Disable() {
        gameObject.SetActive(false);
    }

    private void Enable() {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
