using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedAdd : MonoBehaviour
{
    public Player player;
    private Button button;
    private ResourceDisplay display;

    void Start()
    {
        button = GetComponent<Button>();
        player = GameObject.Find("Player").GetComponent<Player>();
        display = GameObject.Find("MenuResourceDisplay").GetComponent<ResourceDisplay>();

      
    }

    public void AddRed() {
        Player.AddResource(RTS.ResourceType.BankStone, 100, display);
        Player.AddResource(RTS.ResourceType.SkillPoints, 100, display);
    }

    public void RemoveRed() {
        Player.SpendResource(RTS.ResourceType.BankStone, 100, display);
        Player.SpendResource(RTS.ResourceType.SkillPoints, 100, display);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
