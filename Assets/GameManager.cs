using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using RTS;

public class GameManager : MonoBehaviour
{
   

    public static GameManager instance;
    public GameObject loadingScreen;
    private Slider loadingBar;
    private int totalScreenprogress;
    public Sprite[] backgrounds;
    public Image backgroundImage;
    public TMP_Text tipsText;
   
    public string[] tips;

    public float transitionTime = 1.2f;
    private Image crossfade;
    public CanvasGroup canvasGroup;
    public Image transitionDarken;

    public Player player;
    private PlayerResourceManager resources;


    private float playerBasePos = -6.37f;
    private float enemyBasePos = 27.15f;


    void Awake()
    {
        instance = this;
     //   SceneManager.LoadSceneAsync((int)SceneIndexes.TITLE_SCREEN, LoadSceneMode.Additive);
        DontDestroyOnLoad(this);
    }

    private void Start() {
        crossfade = loadingScreen.transform.GetChild(1).GetComponentInChildren<Image>();
        crossfade.color = new Color(0, 0, 0, 0);
        loadingBar = loadingScreen.transform.GetChild(1).GetComponent<Slider>();
       
        resources = player.GetComponent<PlayerResourceManager>();

        canvasGroup = loadingScreen.transform.GetChild(1).GetComponent<CanvasGroup>();

        canvasGroup.DOFade(0, transitionTime);
    }


   public void LoadScene(int sceneIndex) {

        StartCoroutine(LoadActualScene(sceneIndex));
       

    }

    public IEnumerator LoadActualScene(int sceneIndex) {
        FindObjectOfType<AudioManager>().Play("ArrowClick");
        // canvasGroup.DOFade(1, transitionTime);
        transitionDarken.DOFade(1, transitionTime).SetEase(Ease.InSine);
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);
        transitionDarken.DOFade(0, transitionTime).SetEase(Ease.OutSine);
        player.InitializePlayer();
      

        if (sceneIndex == (int)SceneIndexes.MAIN_MENU) {
            player.demon = false;
            player.GetComponent<LevelSystem>().FarSerialize();

            FindObjectOfType<AudioManager>().PlayRandomSong();
        }

        if (sceneIndex == (int)SceneIndexes.MAP) {
            if(player.demon) {
                GameObject.Find("CameraFollow").gameObject.transform.DOMoveX(enemyBasePos, 0f);

            } else {
                GameObject.Find("CameraFollow").gameObject.transform.DOMoveX(playerBasePos, 0f);
            }
            resources.SaveResources();
          

        }


    }
        

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    public void LoadGame() {
        resources.SaveResources();

        /*
        player.GetComponentInChildren<ItemSetter>().Serialize(); 

        backgroundImage.sprite = backgrounds[Random.Range(0, backgrounds.Length)];


            StartCoroutine(GenerateTips());

        loadingScreen.gameObject.SetActive(true);
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.TITLE_SCREEN));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.MAP, LoadSceneMode.Single));
      
        StartCoroutine(GetSceneLoadProgress());*/

        StartCoroutine(LoadActualScene((int)SceneIndexes.MAP));
       
    } 

    public int tipCount;
    IEnumerator GenerateTips() {
        tipCount = Random.Range(0, tips.Length);
        tipsText.text = tips[tipCount];
        while(loadingScreen.activeInHierarchy) {
            yield return new WaitForSeconds(3f);
            LeanTween.alphaCanvas(canvasGroup, 0, 0.5f);
            yield return new WaitForSeconds(0.5f);
                tipCount++;
            if(tipCount >= tips.Length) {
                tipCount = 0;
            }

            tipsText.text = tips[tipCount];
            LeanTween.alphaCanvas(canvasGroup, 1, 0.5f);
        }
    }

    public void LoadMenu() {
      
        resources.LoadResources();
        player.SendToBank();
        

        backgroundImage.sprite = backgrounds[Random.Range(0, backgrounds.Length)];


        StartCoroutine(GenerateTips());

        loadingScreen.gameObject.SetActive(true);

        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.MAP));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU, LoadSceneMode.Additive));
       
        StartCoroutine(GetSceneLoadProgress());
    }

    float totalSceneProgress;
    public IEnumerator GetSceneLoadProgress() {
        for (int i = 0; i < scenesLoading.Count; i++) {
            while (!scenesLoading[i].isDone) {
                totalSceneProgress = 0;

                foreach(AsyncOperation operation in scenesLoading) {
                    totalSceneProgress += operation.progress;
                }

                totalSceneProgress = (totalSceneProgress / scenesLoading.Count) * 100f;
                loadingBar.value = Mathf.RoundToInt(totalSceneProgress);
                yield return null;
            }
        }
        loadingScreen.gameObject.SetActive(false);
        player.InitializePlayer();
        canvasGroup.DOFade(0, transitionTime);
    }

  


}
