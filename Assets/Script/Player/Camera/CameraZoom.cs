using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour
{
    public float orthoZoomedIn;

    public float orthoZoomedOut;

    public float zoomSpeed;

    private bool zoomActive;

    public Button enemyZoomButton;
    public Button playerZoomButton;


    private CinemachineVirtualCamera camera;

    void Start() {
        
        camera = GetComponent<CinemachineVirtualCamera>();

        playerZoomButton.onClick.AddListener(() =>
         ZoomFunction()
        );

        enemyZoomButton.onClick.AddListener(() =>
     ZoomFunction()
    );


    }


    IEnumerator ZoomOut() {
        zoomActive = true;

        while (zoomActive && camera.m_Lens.OrthographicSize != orthoZoomedOut) { 
            camera.m_Lens.OrthographicSize = Mathf.Lerp(camera.m_Lens.OrthographicSize, orthoZoomedOut, zoomSpeed);
            camera.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = 7;
            yield return null;
        }

        if (camera.m_Lens.OrthographicSize == orthoZoomedOut) {
           StopCoroutine(ZoomOut());
        }
        
           

    }

    IEnumerator ZoomIn() {
        zoomActive = false;

        while (!zoomActive && camera.m_Lens.OrthographicSize != orthoZoomedIn) {
            camera.m_Lens.OrthographicSize = Mathf.Lerp(camera.m_Lens.OrthographicSize, orthoZoomedIn, zoomSpeed);
            camera.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = 8;
            yield return null;
        }

        if (camera.m_Lens.OrthographicSize == orthoZoomedIn) {
            StopCoroutine(ZoomIn());
        }

      
    }

    private void ZoomFunction() {
        if(zoomActive) {
            StopCoroutine(ZoomOut());
            StartCoroutine(ZoomIn());
            return;
        } 
        if(!zoomActive) {
            StopCoroutine(ZoomIn());
            StartCoroutine(ZoomOut());
            
        }
    }

    // Start is called before the first frame update
  

  


}
