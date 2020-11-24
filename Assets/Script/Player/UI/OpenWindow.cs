using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWindow : MonoBehaviour
{

    public GameObject window;
    public GameObject firstPage;
    public bool isOpen = false;

    private void Start() {
        window.gameObject.SetActive(false);
    }

    public void Open() {
       
        if (!isOpen) {

            window.gameObject.SetActive(true);
            firstPage.gameObject.SetActive(true);
            isOpen = true;
        }
        else if ( isOpen ) {
            window.gameObject.SetActive(false);
            isOpen = false;
        }
    }

}
