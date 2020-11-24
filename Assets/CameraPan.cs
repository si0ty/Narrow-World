using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraPan : MonoBehaviour
{
    private Camera camera;
    private Transform display;
    public float panRangeX;
    public float displayPanRangeX;

    private Image demonImage;
    private Sprite demonSprite;
    [SerializeField]
    public Sprite knightImage;

    private bool secondRoom = false;

    void Start()
    {
        display = FindObjectOfType<ResourceDisplay>().gameObject.transform;
        demonImage = GetComponent<Image>();
        camera = Camera.main;
        demonSprite = demonImage.sprite;

        GetComponent<Button>().onClick.AddListener(() => {
            if (!secondRoom) {
                camera.transform.DOMoveX(panRangeX, 2.7f).SetEase(Ease.OutSine);
                demonImage.DOFade(0, 1f).SetEase(Ease.OutSine);
                demonImage.sprite = knightImage;
                demonImage.DOFade(0, 0);
                demonImage.DOFade(1, 1.8f).SetEase(Ease.OutSine);
                secondRoom = true;
            } else {
                camera.transform.DOMoveX(0, 2.7f).SetEase(Ease.OutSine);
                demonImage.DOFade(0, 1f).SetEase(Ease.OutSine);
                demonImage.sprite = demonSprite;
               demonImage.DOFade(0, 0);
                demonImage.DOFade(1, 1.8f).SetEase(Ease.OutSine);

                secondRoom = false;
            }
            
            });
    }

  


    void Update()
    {
        
    }
}
