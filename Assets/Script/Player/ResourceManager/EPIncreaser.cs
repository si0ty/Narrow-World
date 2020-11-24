using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EPIncreaser : MonoBehaviour
{

    public Player player;
    private int increase = 50;
    // Start is called before the first frame update
    void Start()
    {




        this.GetComponent<Button>().onClick.AddListener(() => {
            player.GetComponent<LevelSystem>().LevelIncrease(300);
            Debug.Log("Level increased by " + increase);
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
