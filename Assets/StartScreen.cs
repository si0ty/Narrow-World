using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Mirror;
using UnityEngine.UI;

public class StartScreen : NetworkBehaviour
{
    private NarrowNetwork network;

    private string demonName;
    public TMP_Text demonNameDisplay;
    private int demonLevel;
    public TMP_Text demonLevelDisplay;

    private string knightName;
    public TMP_Text knightNameDisplay;
    private int knightLevel;
    public TMP_Text knightLevelDisplay;

    public int startScreenLength;
    public float fadeOutDuration;
    private CanvasGroup canvasGroup;

    private Player player;
    private IngamePlayer ingamePlayer;
  
    private CanvasGroup playerCanvasG;
    private CanvasGroup enemyCanvasG;

    public SpriteRenderer[] sprites;
    public ParticleSystem[] particles;

    public Button readyButton;
    public TMP_Text[] playerReadyTexts = new TMP_Text[4];

   

    void Start()
    {
        network = GameObject.Find("NarrowNetwork").GetComponent<NarrowNetwork>();
        playerCanvasG = GameObject.Find("PlayerUI").GetComponent<CanvasGroup>();
        enemyCanvasG = GameObject.Find("EnemyUI").GetComponent<CanvasGroup>();
       

        player = GameObject.Find("Player").GetComponent<Player>();


        if (player.demon) {
            ingamePlayer = GameObject.FindGameObjectWithTag("DemonPlayer").GetComponent<IngamePlayer>();
        } else {
            ingamePlayer = GameObject.FindGameObjectWithTag("KnightPlayer").GetComponent<IngamePlayer>();

        }


        canvasGroup = GetComponentInParent<CanvasGroup>();

        /*
        foreach (var players in network.GamePlayers) {
            if (players.demon) {
               
               demonName = players.playerName;
                demonLevel = players.playerLevel;
               }
            else {
                knightName = players.playerName;
                knightLevel = players.playerLevel;
            }
        }
        */

        if (player.demon) {
            demonNameDisplay.SetText(network.GamePlayers[0].playerName);
            demonLevelDisplay.SetText(network.GamePlayers[0].playerLevel.ToString());

            knightNameDisplay.SetText(network.GamePlayers[1].playerName);
            knightLevelDisplay.SetText(network.GamePlayers[1].playerLevel.ToString());
        }

        if (!player.demon) {
            demonNameDisplay.SetText(network.GamePlayers[1].playerName);
            demonLevelDisplay.SetText(network.GamePlayers[1].playerLevel.ToString());

            knightNameDisplay.SetText(network.GamePlayers[0].playerName);
            knightLevelDisplay.SetText(network.GamePlayers[0].playerLevel.ToString());

        }

        if (knightNameDisplay.text.Length > 5) {
            knightNameDisplay.fontSize = 90;
        }
        else if (knightNameDisplay.text.Length > 9) {
            knightNameDisplay.fontSize = 70;
        }

        if (demonNameDisplay.text.Length > 5) {
            demonNameDisplay.fontSize = 90;
        }
        else if (demonNameDisplay.text.Length > 9) {
            demonNameDisplay.fontSize = 70;
        }

        readyButton.onClick.AddListener(() => {
            ReadyUp();
            
            }
        );
       

        Debug.Log("Names should be set");



        ingamePlayer.playerReadyTexts = playerReadyTexts;
        ingamePlayer.UpdateDisplay();

      
        AudioManager.instance.AudioFadeOut();
        AudioManager.instance.Play("EpicTheme1");
    }

    private void ReadyUp() {
        ingamePlayer.CmdReadyUp();
        readyButton.interactable = false;
    }
   
    public void Intro() {
        StartCoroutine(FadeOut());
    }
    public IEnumerator FadeOut() {
     

        canvasGroup.DOFade(0, fadeOutDuration);

        if (player.demon) {
            enemyCanvasG.DOFade(1, 2);
        }
        else {
            playerCanvasG.DOFade(1, 2);
        }

        foreach (SpriteRenderer sprite in sprites) {
            sprite.DOFade(0, 2);
        }

        foreach (ParticleSystem particle in particles) {
            particle.Stop();
        }

        yield return new WaitForSeconds(fadeOutDuration);

      
      
            if (ingamePlayer.isLocalPlayer && ingamePlayer.index == 1) {
                ingamePlayer.AddStartResources();
            GameObject.Find("Timer").GetComponent<Timer>().counting = true;
            }
       
        Destroy(this.gameObject, 5f);
    }
}
