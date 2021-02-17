using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Icon : NetworkBehaviour
{

    
    public string iconName;
    
   
    public int buildTime = 0;
   

    public GameObject unitPrefab;
    private NetworkIdentity identity;


    [HideInInspector]
    public Transform rectTransform;

    // Start is called before the first frame update
    [SerializeField] float _tweenRatio = 5f; // crank this up if Time.deltaTime is choking it
                                             // because of this it could actually be much larger than 1.0f
    public bool _tweenFlag = true; // set this to true when the positions need to update
    public Vector3 _targetPos; // the final resting place of the object; it's what we calculated earlier
    IngamePlayer player;


    private void Start() {
 

        rectTransform = GetComponent<Transform>();

      
    }

  

    public void Update() {
        if (_tweenFlag) {
           
           transform.localPosition += (_targetPos - transform.localPosition) * _tweenRatio * Time.deltaTime;
            if (areWeThereYet(transform.localPosition)) _tweenFlag = false;
        }

    }
    public bool areWeThereYet(Vector3 pos) => (_targetPos - pos).sqrMagnitude < 1E-8f;
}
