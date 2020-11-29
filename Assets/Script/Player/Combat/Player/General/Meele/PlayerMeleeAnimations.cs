using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMeleeAnimations : NetworkBehaviour
{

    private Animator anim;
    private PlayerCloseCombat playercombat;
    private PlayerMeleeMovement playerMovement;
    private PlayerHealthSystem playerHealthSystem;
    private PlayerValueSetter unitValueExchange;

    private Collider2D capsuleCollider;
    private Collider2D boxCollider;

    private Material material;
    private Color materialTintColor;
    private float tintFadeSpeed;

    private SpriteRenderer spriteRenderer;

    public SpriteRenderer dropShadow;

    public int deathCount;
    public int idleCount;
    public int attackCount;

    public Material dissolveMaterial;
    public Material damageMaterial;

    bool dissolving = false;
    private int dissolveTime = 4;
    float dissolveRate = 0f;

    public GameObject deathParticles;



    private void Start() {
        
      
        spriteRenderer = GetComponent<SpriteRenderer>();
        playercombat = GetComponent<PlayerCloseCombat>();
       
        playerHealthSystem = GetComponent<PlayerHealthSystem>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        unitValueExchange = GetComponent<PlayerValueSetter>();

       
        spriteRenderer.material = damageMaterial;
        dissolveMaterial.SetFloat("_DissolveAmount", 0);

    }

    private void Awake() {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMeleeMovement>();
        materialTintColor = new Color(1, 0, 0, 0);
        SetMaterial(damageMaterial);
        GetComponent<SpriteRenderer>().material = material;
        tintFadeSpeed = 6f;
    }

    private void Update() {
        if (materialTintColor.a > 0) {
            materialTintColor.a = Mathf.Clamp01(materialTintColor.a - tintFadeSpeed * Time.deltaTime);
            material.SetColor("_Tint", materialTintColor);
        }


    }

    private void SetMaterial(Material material) {
        this.material = material;
    }

    public void SetTintColor(Color color) {
        materialTintColor = color;
        material.SetColor("_Tint", materialTintColor);
    }

    public void SetTintFadeSpeed(float tintFadeSpeed) {
        this.tintFadeSpeed = tintFadeSpeed;
    }

    public void WalkingAnim() {
        playerMovement.moveSpeed = playerMovement.walkSpeed;

        anim.SetBool("Idle1", false);
        anim.SetBool("Idle2", false);
        anim.SetBool("Idle3", false);
        anim.SetBool("Idle4", false);
        anim.SetBool("Idle5", false);

        anim.SetBool("Running", false);
        anim.SetBool("Walking", true);
    }

    public void RunningAnim() {
        playerMovement.moveSpeed = playerMovement.runSpeed;
        
        anim.SetBool("Idle1", false);
        anim.SetBool("Idle2", false);
        anim.SetBool("Idle3", false);
        anim.SetBool("Idle4", false);
        anim.SetBool("Idle5", false);
        anim.SetBool("Running", true);
        anim.SetBool("Walking", false);
    }

    public void RollingAnim() {
        anim.SetTrigger("Roll");
    }

    public void IdleAnim() {
        playerMovement.moveSpeed = 0f;

        anim.SetBool("Walking", false);
        anim.SetBool("Running", false);


        int idleRandomiser = new int();
        idleRandomiser = Random.Range(1, idleCount + 1);

        if (idleRandomiser == 1) {
            anim.SetBool("Idle1", true);

            anim.SetBool("Idle2", false);
            anim.SetBool("Idle3", false);
            anim.SetBool("Idle4", false);
            anim.SetBool("Idle5", false);
            return;
        } else

        if (idleRandomiser == 2) {
            anim.SetBool("Idle2", true);
            anim.SetBool("Idle1", false);

            anim.SetBool("Idle3", false);
            anim.SetBool("Idle4", false);
            anim.SetBool("Idle5", false);
            return;
        } else

        if (idleRandomiser == 3) {
            anim.SetBool("Idle3", true);
            anim.SetBool("Idle1", false);
            anim.SetBool("Idle2", false);

            anim.SetBool("Idle4", false);
            anim.SetBool("Idle5", false);
            return;
        } else

        if (idleRandomiser == 4) {
            anim.SetBool("Idle4", true);
            anim.SetBool("Idle1", false);
            anim.SetBool("Idle2", false);
            anim.SetBool("Idle3", false);

            anim.SetBool("Idle5", false);
            return;
        } else

        if (idleRandomiser == 5) {
            anim.SetBool("Idle5", true);
            anim.SetBool("Idle1", false);
            anim.SetBool("Idle2", false);
            anim.SetBool("Idle3", false);
            anim.SetBool("Idle4", false);
            return;
        }
    }

    public void FightingAnim() {

        playerMovement.moveSpeed = 0f;
        int combo = new int();
        combo = Random.Range(1, attackCount + 1);
       
        anim.SetBool("Walking", false);

        if (combo == 1) {
            anim.SetTrigger("Attack1");
            playercombat.combo = combo;
            return;
        } else
        if (combo == 2) {
            anim.SetTrigger("Attack2");
            playercombat.combo = combo;
            return;
        } else
        if (combo == 3) {
            anim.SetTrigger("Attack3");
            playercombat.combo = combo;
            return;
        } else
        if (combo == 4) {
            anim.SetTrigger("Attack4");
            playercombat.combo = combo;
            return;
        }
    }



    public void NormalCastAnim() {
        playerMovement.moveSpeed = 0f;
        anim.SetBool("Walking", false);
        anim.SetBool("Running", false);
        anim.SetBool("Idle1", false);
        anim.SetBool("Idle2", false);
        anim.SetBool("Idle3", false);
        anim.SetBool("Idle4", false);
        anim.SetBool("Idle5", false);
        anim.SetTrigger("NormalCast");

    }

    public void SuperCastAnim() {
        playerMovement.moveSpeed = 0f;
        anim.SetBool("Walking", false);
        anim.SetBool("Running", false);
        anim.SetBool("Idle1", false);
        anim.SetBool("Idle2", false);
        anim.SetBool("Idle3", false);
        anim.SetBool("Idle4", false);
        anim.SetBool("Idle5", false);
        anim.SetTrigger("SuperCast");

    }


    public void HurtAnim() {
     

     
        
        SetTintColor(new Color(1, 0, 0, 1f));
    }


    IEnumerator DeathWait() {
        yield return new WaitForSeconds(3);
        GetComponent<SpriteRenderer>().material = dissolveMaterial;
        anim.enabled = false;
        StartCoroutine(Dissolving());
        GameObject particles = Instantiate(deathParticles, new Vector3(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
        particles.transform.SetParent(gameObject.transform);
    }

    IEnumerator Dissolving() {


        dissolving = true;


        while (dissolveRate < 1) {

            dissolveMaterial.SetFloat("_DissolveAmount", dissolveRate);


            dissolveRate += Time.deltaTime / dissolveTime;

            if (dissolveRate >= 0.5) {
                dropShadow.color = new Color(dropShadow.color.r, dropShadow.color.g, dropShadow.color.b, dropShadow.color.a - dissolveRate);
            }
            yield return null;
        }

        if (dissolveRate == 1) {
            Destroy(this);
            StopAllCoroutines();

        }
    }

    public void Die() {

        anim.SetBool("Walking", false);
        anim.SetBool("Idle5", false);
        anim.SetBool("Idle1", false);
        anim.SetBool("Idle2", false);
        anim.SetBool("Idle3", false);
        anim.SetBool("Idle4", false);

        anim.ResetTrigger("Attack1");
        anim.ResetTrigger("Attack2");
        anim.ResetTrigger("Attack3");
        anim.ResetTrigger("Attack3");

        if (unitValueExchange.smallGold == true) {
            unitValueExchange.DropGold("small");
        } else

             if (unitValueExchange.mediumGold == true) {
            unitValueExchange.DropGold("medium");

        } else  if (unitValueExchange.largeGold == true) {
                unitValueExchange.DropGold("large");
            }
        else if (unitValueExchange.largerGold == true) {
            unitValueExchange.DropGold("larger");
        }

        playerMovement.enabled = false;
        playercombat.enabled = false;      

        if (playerMovement.canRun == true) {
            anim.SetBool("Running", false);
        }      

        int deathRandomiser = new int();
        deathRandomiser = Random.Range(1, deathCount + 1);

     


        if (deathRandomiser == 1) {
            anim.SetBool("Death1", true);
           
        } else

        if (deathRandomiser == 2) {
            anim.SetBool("Death2", true);
            
        }

      
        playerHealthSystem.enabled = false;
        boxCollider.enabled = false;
        capsuleCollider.enabled = false;

      

        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;

        StartCoroutine(DeathWait());

    }

}
