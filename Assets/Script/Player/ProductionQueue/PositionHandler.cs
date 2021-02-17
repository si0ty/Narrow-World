using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public BuildQueue buildQueue;

    
    public GameObject firstPositionObject;
    [HideInInspector]
    public Vector3 firstPosition;
  
   
    void Start()
    {
        buildQueue = GetComponentInParent<BuildQueue>();
        List<Vector3> waitingQueuePositionList = new List<Vector3>();


        firstPosition = firstPositionObject.transform.localPosition;
        
        float positionSize = 1.3f;
        for (int i = 0; i < 5; i++) {
          
            waitingQueuePositionList.Add(firstPosition + new Vector3(0.5f, 0) * positionSize * i);
             
          //  Debug.Log(waitingQueuePositionList.Count.ToString());

        }

        buildQueue = new BuildQueue(waitingQueuePositionList);
    }


   
   
}
