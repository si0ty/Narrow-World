using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;
using RTS;

public class BuildQueue : MonoBehaviour
{
    private float currentBuildTime;
    public int queueMax;

    public GameObject progressBar;

    public PositionHandler positionHandler;

    public GameObject spawnPoint;
    private Vector3 entrancePosition;
    private Vector3 targetPosition;

    public GameObject gate;

    private List<Vector3> positionList;
    public List<GameObject> buildQueue;
    public List<GameObject> queueSlot;

    public Canvas mainUI;

    private void Start() {
        buildQueue = new List<GameObject>();

        currentBuildTime = 0;
}

    void Update() {
        UpdateBuildTime();

       
    }

    public BuildQueue(List<Vector3> positionList) {
        this.positionList = positionList;
        
              entrancePosition = positionList[positionList.Count - 1] + new Vector3(0.5f, 0);

        foreach (Vector3 position in positionList) {
                     
           // World_Sprite.Create(position, new Vector3(.3f, .3f), Color.green);
             
                                 
        }     

       // World_Sprite.Create(entrancePosition, new Vector3(.1f, .1f), Color.magenta);      
    }

    private void UpdateBuildTime() {
       
        if (buildQueue.Count > 0 ) {
            
            progressBar.GetComponent<Slider>().value += Time.deltaTime * 1;
            currentBuildTime += Time.deltaTime * 1;
            // Debug.Log("currentBuildTime: " + currentBuildTime);
            if (currentBuildTime >= buildQueue[0].gameObject.GetComponent<Icon>().buildTime) {
                Debug.Log("Unit Spawned + " + buildQueue[0].gameObject.name);
                
                SpawnUnit(buildQueue[0]);

                progressBar.GetComponent<Slider>().value = 0;
                currentBuildTime = 0;              
            }
        } 
    }


    public void AddUnitToBuildQueue(GameObject icon) {
 
        if (buildQueue.Count <= queueMax) {
            GameObject newIcon = Instantiate(icon, new Vector2(positionHandler.buildQueue.entrancePosition.x, positionHandler.buildQueue.entrancePosition.y), Quaternion.identity);
           
            newIcon.transform.SetParent(Camera.main.transform);

            if (buildQueue.Count == 0) {
                targetPosition = positionHandler.firstPosition;
             
            }
            else {
                targetPosition = positionHandler.buildQueue.positionList[buildQueue.Count - 1] + new Vector3(0.65f, 0);
            }

            Debug.Log("PositionList Count: " + positionHandler.buildQueue.positionList.Count.ToString());
                
            buildQueue.Add(newIcon);
            progressBar.GetComponent<Slider>().maxValue = buildQueue[0].gameObject.GetComponent<Icon>().buildTime;

           
          

           // newIcon.GetComponent<Icon>()._tweenFlag = true;
            newIcon.transform.localPosition = positionHandler.buildQueue.entrancePosition;
            newIcon.GetComponent<Icon>()._targetPos = targetPosition;
            Debug.Log("Icon addded" + icon.ToString());
            
        } else {
            Debug.Log("Queue is full");
        }
    }

    private void SpawnUnit(GameObject unit) {

        Vector3 pos = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
        Instantiate(unit.GetComponent<Icon>().unitPrefab, pos, Quaternion.identity);
        gate.GetComponent<GateClose>().OpenGate();
        Debug.Log("Object Removed + " + buildQueue[0].gameObject.name);
      
        Destroy(buildQueue[0].gameObject);
        buildQueue.RemoveAt(0);

        Debug.Log("buildList Count:" + buildQueue.Count.ToString());
        if (buildQueue.Count == 0) {
             return;
        } else {
            RelocateAllIcons();
        }     
    }

    public void RelocateAllIcons() {
        for (int i = 0; i < buildQueue.Count; i++) {
            buildQueue[i].GetComponent<Icon>()._tweenFlag = true;
            buildQueue[i].GetComponent<Icon>()._targetPos = positionHandler.buildQueue.positionList[i];
          //  buildQueue[i].transform.position = gameHandler.buildQueue.positionList[i];
            
        } 
    }

}
