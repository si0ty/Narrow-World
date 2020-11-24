using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RTS;
using Cinemachine;

public class UserInput : MonoBehaviour
{

    public GameObject mainCamera;

    public Player player;
    private PlayerResourceManager resourceManager;
 
    void Start() {
        player = GetComponent<Player>();
        resourceManager = player.GetComponent<PlayerResourceManager>();
    }


    /*

    void LateUpdate() {
        if (player.human) {
            MoveCamera();
        }

    }

    private void MoveCamera() {
        float xpos = Input.mousePosition.x;
        float ypos = Input.mousePosition.y;

        Vector3 movement = new Vector3(0, 0, 0);

        //horizontal camera movement
        if (xpos >= 0 && xpos < resourceManager.scrollWidth) {
              
            if (mainCamera.transform.position.x > -6.19f) {
                movement.x -= resourceManager.scrollSpeed;
            } else {
                movement.x = 0;
            }
        }
        else if (xpos <= Screen.width && xpos > Screen.width - resourceManager.scrollWidth) {
            if (mainCamera.transform.position.x < 26.18f) {
                movement.x += resourceManager.scrollSpeed;
            }
            else {
                movement.x = 0;
            }
        
          
        }
/*
        if (ypos <= resourceManager.scrollHeight) {
            movement.x = 0;
            
        }

        if (ypos >= Screen.height - resourceManager.scrollHeight) {
            movement.x = 0;
           
        } 


        //calculate desired camera position based on received input
        Vector3 origin = Camera.main.transform.position;
        Vector3 destination = origin;
        destination.x += movement.x;
       
      

        //if a change in position is detected perform the necessary update
        if (destination != origin) {
            Camera.main.transform.position = Vector3.MoveTowards(origin, destination, Time.deltaTime * resourceManager.scrollSpeed);
        }


    }  */


}
