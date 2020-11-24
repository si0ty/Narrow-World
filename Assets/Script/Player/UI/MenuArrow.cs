using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuArrow : MonoBehaviour
{
   public int sceneIndex;
    public GameManager sceneLoader;

    private void Start() {
      
    }

    private void OnMouseDown() {
        sceneLoader = GameObject.Find("GameManager").GetComponent<GameManager>();
        sceneLoader.LoadScene(sceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
