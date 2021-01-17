using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerLeaveButton : MonoBehaviour
{
    [HideInInspector]
    public NarrowNetwork network;
    void Start()
    {
        network = GameObject.Find("NarrowNetwork").GetComponent<NarrowNetwork>();    }

    public void FromServerDisconnect() {
        network.StopServer();
    }
}
