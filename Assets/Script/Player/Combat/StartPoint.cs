using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public float xPos;
    public float yPos;

    void Start()
    {
        transform.localPosition = new Vector3(xPos, yPos, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
