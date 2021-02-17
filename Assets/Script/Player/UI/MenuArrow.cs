using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuArrow : MonoBehaviour
{
   public int sceneIndex;
    public GameManager sceneLoader;
    private Button button;

    private void Start() {
        sceneLoader = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        sceneLoader.LoadScene(sceneIndex)
        );
    }


 
}
