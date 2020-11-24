using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateClose : MonoBehaviour
{
    private Animator anim;
  
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenGate() {
        StopAllCoroutines();
        anim.SetBool("Open", true);
        StartCoroutine(CloseGate());

    }

    IEnumerator CloseGate() {
        yield return new WaitForSeconds(4);
        anim.SetBool("Open", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
