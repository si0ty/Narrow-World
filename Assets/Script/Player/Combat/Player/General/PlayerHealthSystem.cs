using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mirror;

public class PlayerHealthSystem : NetworkBehaviour
{
    public string unitName;
    public bool melee, mage, distance;

    public int maxHealth;

    [SyncVar]
    public int currentHealth;

    public delegate void HealthChangedDelegate(int currentHealth, int maxHealth);

    public event HealthChangedDelegate EventHealthChanged;

   
    [Server]
    private void SetHealth(int value) {
        currentHealth = value;
        EventHealthChanged?.Invoke(currentHealth, maxHealth);
    }


    private SpriteRenderer spriteRenderer;

    public GameObject healthBar;

    private PlayerMeleeAnimations playerMeleeAnimations;
    private PlayerDistanceAnimations playerDistanceAnimations;
   

    private PlayerMeleeMovement playerMeleeMovement;
    private PlayerDistanceMovement playerDistanceMovement;

    public GameObject damagePopUp;

    private GameObject worldCanvas;

    public float positionOffset;
    public int pushback = -40;

    void Start() {

        // SetHealth(maxHealth);
        worldCanvas = GameObject.Find("WorldUI").transform.gameObject;

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (melee == true) {
            playerMeleeAnimations = GetComponent<PlayerMeleeAnimations>();
            playerMeleeMovement = GetComponent<PlayerMeleeMovement>();
        }

        if (distance == true) {

            playerDistanceAnimations = GetComponent<PlayerDistanceAnimations>();
            playerDistanceMovement = GetComponent<PlayerDistanceMovement>();
        }

        if (mage == true) {

            playerDistanceAnimations = GetComponent<PlayerDistanceAnimations>();
            playerDistanceMovement = GetComponent<PlayerDistanceMovement>();
        }


    }

    private void Awake() {
       
    }

    public void NormalDmgEffect(int damage) {
        GameObject points = Instantiate(damagePopUp, transform.position + new Vector3(positionOffset, .5f, 0), Quaternion.identity);
        points.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Normal");
        points.transform.SetParent(worldCanvas.transform, true);
        points.transform.GetChild(0).GetComponent<TMP_Text>().SetText(damage.ToString());
    }

    public void MiddleDmgEffect(int damage) {
        GameObject points = Instantiate(damagePopUp, transform.position + new Vector3(positionOffset, .5f, 0), Quaternion.identity);
        points.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Middle");
        points.transform.SetParent(worldCanvas.transform, true);
        points.transform.GetChild(0).GetComponent<TMP_Text>().SetText(damage.ToString());
    }

    public void LargeDmgEffect(int damage) {
        GameObject points = Instantiate(damagePopUp, transform.position + new Vector3(positionOffset, .5f, 0), Quaternion.identity);
        points.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Super");
        points.transform.SetParent(worldCanvas.transform, true);
        points.transform.GetChild(0).GetComponent<TMP_Text>().SetText(damage.ToString());
    }

    public void MagicDmgEffect(int damage) {
        GameObject points = Instantiate(damagePopUp, transform.position + new Vector3(positionOffset, .5f, 0), Quaternion.identity);
        points.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Magic");
        points.transform.SetParent(worldCanvas.transform, true);
        points.transform.GetChild(0).GetComponent<TMP_Text>().SetText(damage.ToString());
    }

    [Command]
    public void CmdDealDamage(int damage) {

       
        currentHealth -= damage;

        SetHealth(Mathf.Max(currentHealth - damage, 0));

        if (healthBar.transform.GetChild(0).GetComponentInChildren<Image>().enabled == false) {
            healthBar.GetComponent<PlayerUnitHealthBar>().HealthUpdate();
        }

        if (melee == true) {

            if(playerMeleeAnimations != null) {
                playerMeleeAnimations.HurtAnim();
                if (currentHealth > 0) {
                    if (GetComponent<PlayerMeleeMovement>() != null) {
                        GetComponent<PlayerMeleeMovement>().PushBack(pushback + 10);
                    }
                    else {
                        GetComponent<PlayerDistanceMovement>().PushBack(pushback + 10);
                    }

                }

            }

            healthBar.GetComponent<PlayerUnitHealthBar>().HealthUpdate();
    

            if (currentHealth <= 0) {
                playerMeleeAnimations.Die();
            }
        }

        if (distance == true) {

            playerDistanceAnimations.HurtAnim();
            healthBar.GetComponent<PlayerUnitHealthBar>().HealthUpdate();
            if (currentHealth > 0) {
                if(GetComponent<PlayerMeleeMovement>() != null) {
                    GetComponent<PlayerMeleeMovement>().PushBack(pushback);
                } else {
                    GetComponent<PlayerDistanceMovement>().PushBack(pushback);
                }
               
            }


            if (currentHealth <= 0) {
                playerDistanceAnimations.Die();
            }
        }

        if (mage == true) {

            playerDistanceAnimations.HurtAnim();
            healthBar.GetComponent<PlayerUnitHealthBar>().HealthUpdate();

              if (currentHealth > 0) {
                if(GetComponent<PlayerMeleeMovement>() != null) {
                    GetComponent<PlayerMeleeMovement>().PushBack(pushback);
                } else {
                    GetComponent<PlayerDistanceMovement>().PushBack(pushback);
                }
               
            }

            if (currentHealth <= 0) {
                playerDistanceAnimations.Die();
            }
        }

        

    }


   

}
