using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class Timer : NetworkBehaviour
{
    private TMP_Text timer;
    private int mm;
    private float ss;
    public bool counting;

    void Start()
    {
        timer = GetComponent<TMP_Text>();   
    }


    [Command]
    public void Count() {
        CountEffect();
    }


    [ClientRpc]
    public void CountEffect() {

       
    }
    
    void Update()
    {
        if (counting) {
            ss += Time.deltaTime;
            int seconds = (int)ss % 60;
            int mm = this.mm;
            if (seconds >= 60) {
                ss = 0;
                mm++;
                Debug.Log("Minuts: " + mm.ToString());
            }

            timer.SetText(mm.ToString() + ":" + seconds.ToString());
            if (ss <= 9 && mm >= 9) {
                timer.SetText(mm.ToString() + ":0" + seconds.ToString());
            }
            if (mm <= 9 && ss <= 9) {
                timer.SetText("0" + mm.ToString() + ":0" + seconds.ToString());
            } else if (mm <= 9 && ss >= 10) {
                timer.SetText("0" + mm.ToString() + ":" + seconds.ToString());
            }
          
        }

      //  Count();
        
    }
}
