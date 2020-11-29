using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour
{
   
    public Material defaultMaterial;
    public Material glowMaterial;
    public Material lockedMaterial;

    private Image image;

    private void Awake() {
        image = GetComponent<Image>();
    }


    public void SetGlow() {
        image.material = glowMaterial;
    }

    public void DefaultMaterial() {
        image.material = defaultMaterial;
    }


    public void SetLocked() {
        image.material = lockedMaterial;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
