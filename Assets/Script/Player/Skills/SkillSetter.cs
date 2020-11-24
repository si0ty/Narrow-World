using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSetter : MonoBehaviour
{
    private Player player;
    public SkillTree skillTree;

    void Start()
    {
     
     
        Serialize();
       
    }


    public void Serialize() {
        StartCoroutine(Serialization());
    }

    public IEnumerator Serialization() {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("Items successful Initilized");

        skillTree = GameObject.Find("SkillTree").GetComponent<SkillTree>();
        player  = FindObjectOfType<Player>().GetComponent<Player>();

        skillTree.SetPlayerSkills(player.GetPlayerSkills());
        skillTree.UpdateVisuals();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
