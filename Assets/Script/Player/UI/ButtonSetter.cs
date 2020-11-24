using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetter : MonoBehaviour
{
         public Transform tier1pos1;
         public Transform tier1pos2;
         public Transform tier1pos3;
         public Transform tier1pos4;

    private List<GameObject> tier1Button;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetTier1Buttons(GameObject button1, GameObject button2, GameObject button3, GameObject button4) {
        foreach (GameObject button in tier1Button) {
             Destroy(button);
        }

        List<GameObject> tier1buttons = new List<GameObject>();
        this.tier1Button = tier1buttons;
        

        Instantiate(button1, tier1pos1);
        Instantiate(button2, tier1pos2);
        Instantiate(button3, tier1pos3);
        Instantiate(button4, tier1pos4);

        tier1Button.Add(button1);
        tier1Button.Add(button1);
        tier1Button.Add(button1);
        tier1Button.Add(button1);
    }
}
