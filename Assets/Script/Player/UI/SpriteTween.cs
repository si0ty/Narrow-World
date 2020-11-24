using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTween : MonoBehaviour
{

    public Vector3 from = Vector3.one;
    public Vector3 to = Vector3.one * 0.95f;

    private void OnMouseDown() {
        StartCoroutine(Scaling());
        GetComponent<Transform>().localScale = from;
    }

   
   

    IEnumerator Scaling() {
        GetComponent<Transform>().localScale = to;
        yield return new WaitForSeconds(Time.fixedDeltaTime * 3);
        GetComponent<Transform>().localScale = from;
    }

}
