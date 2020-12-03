using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraPan : MonoBehaviour
{
    private Camera camera;
    private Transform display;
    public float panRange;
    public float displayPanRangeX;
   public bool horizontal;

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

            if (horizontal) {
                if (!secondRoom) {
                    camera.transform.DOMoveX(panRange, 1.2f).SetEase(Ease.InOutSine);
                    demonImage.DOFade(0, 1f).SetEase(Ease.InOutSine);
                    demonImage.sprite = knightImage;
                    demonImage.DOFade(0, 0);
                    demonImage.DOFade(1, 1.8f).SetEase(Ease.InOutSine);
                    secondRoom = true;
                }
                else {
                    camera.transform.DOMoveX(0, 1.4f).SetEase(Ease.InOutSine);
                    demonImage.DOFade(0, 1f).SetEase(Ease.InOutSine);
                    demonImage.sprite = demonSprite;
                    demonImage.DOFade(0, 0);
                    demonImage.DOFade(1, 1.8f).SetEase(Ease.InOutSine);

                    secondRoom = false;
                }
            } else {
                if (!secondRoom) {
                    camera.transform.DOMoveY(panRange, 1.2f).SetEase(Ease.InOutSine);
                    demonImage.DOFade(0, 1f).SetEase(Ease.InOutSine);
                    demonImage.sprite = knightImage;
                    demonImage.DOFade(0, 0);
                    demonImage.DOFade(1, 1.8f).SetEase(Ease.InOutSine);
                    secondRoom = true;
                }
                else {
                    camera.transform.DOMoveY(0, 1.4f).SetEase(Ease.InOutSine);
                    demonImage.DOFade(0, 1f).SetEase(Ease.InOutSine);
                    demonImage.sprite = demonSprite;
                    demonImage.DOFade(0, 0);
                    demonImage.DOFade(1, 1.8f).SetEase(Ease.InOutSine);

                    secondRoom = false;
                }
            }
           
            
            });
    }

  


    void Update()
    {
        
    }
}
