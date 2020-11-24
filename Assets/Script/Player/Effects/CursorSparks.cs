using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CursorSparks : MonoBehaviour
{
    
    public GameObject mouseEffectInput;
    private GameObject transMousePos;

    private void Start() {
        transMousePos = new GameObject();
    }

    private IEnumerator MouseSparkles() {
        GameObject particleInstance = new GameObject();
        Vector3 mousePos = new Vector3();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      
        transMousePos.transform.position = new Vector3 (mousePos.x, mousePos.y, mousePos.z);
        particleInstance = Instantiate(mouseEffectInput, transMousePos.transform);
        particleInstance.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(1);

       // particleInstance.GetComponent<ParticleSystem>().Stop();
        Destroy(particleInstance);
        StopCoroutine(MouseSparkles());
    }

    void Update()
    {
       if (Input.GetMouseButtonDown(0)) {
          
            StartCoroutine(MouseSparkles());
           
        }

       
    }
}
