using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;

public class SaveButton : MonoBehaviour
{

    private PlayerResourceManager resourceManager;
    // Start is called before the first frame update
    void Start() {
        resourceManager = GameObject.Find("Player").GetComponent<PlayerResourceManager>();
    }

    public void SaveGame() {
        resourceManager.SaveResources();
    }

}
