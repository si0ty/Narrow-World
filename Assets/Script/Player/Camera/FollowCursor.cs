
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;


public class FollowCursor : MonoBehaviour
{







    void Follow() {


        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        gameObject.transform.position = pz;

    }

    void FixedUpdate() {
      
        Follow();

    }


   
   






}
