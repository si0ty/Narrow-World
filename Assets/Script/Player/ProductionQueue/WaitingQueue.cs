using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class WaitingQueue : MonoBehaviour
{


    public PositionHandler gamehandler;

    public GameObject iconPrefab;
    public Sprite[] iconSprites;

    private List<GameObject> iconList;
    private List<Vector3> positionList;

    private Vector3 entrancePosition;

    public GameObject emptyIcon;
    public static bool firstPosition;



    public WaitingQueue(List<Vector3> positionList ) {
        this.positionList = positionList;
        
        
        entrancePosition = positionList[positionList.Count - 1] + new Vector3(0.5f, 0);

        foreach (Vector3 position in positionList) {
            World_Sprite.Create(position, new Vector3(.3f, .3f), Color.green);
        }

        World_Sprite.Create(entrancePosition, new Vector3(.1f, .1f), Color.magenta);
        
        
    }


    private void Start() {

       iconList = new List<GameObject>();
    }




    public bool CanAddIcon() {
        return iconList.Count < positionList.Count;
    }

    public void AddIcon(GameObject icon) {
       

            icon.GetComponent<Icon>()._tweenFlag = true;
            GetComponent<WaitingQueue>().iconList.Add(icon);    
            icon.GetComponent<Icon>()._targetPos = positionList[1];

            icon.transform.position = this.entrancePosition;
          //  icon.transform.position = GetComponent<WaitingQueue>().positionList[iconList.IndexOf(icon)];

            Debug.Log("Icon addded" + icon.ToString()); 
            Debug.Log("iconList Count:" + iconList.Count.ToString());
    
              
    } 

    public GameObject GetFirstInQueue() {
        if (iconList.Count == 0) {
            return null;

        } else {
            GameObject icon = iconList[0];
            iconList.RemoveAt(0);
            RelocateAllIcons();

            return iconList[0];
        }
    }


    private void RelocateAllIcons() {
        for (int i = 0; i < iconList.Count; i++) {
            iconList[i].transform.position = positionList[i];
        }
    }
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
