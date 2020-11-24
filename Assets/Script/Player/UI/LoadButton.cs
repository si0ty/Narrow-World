using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DTS;
using RTS;

public class LoadButton : MonoBehaviour
{

    private PlayerResourceManager resourceManager;
    // Start is called before the first frame update
    void Start()
    {
        resourceManager = GameObject.Find("Player").GetComponent<PlayerResourceManager>();
    }

    public void LoadGame() {
        resourceManager.LoadResources();
    }

    // Update is called once per frame
  
}
