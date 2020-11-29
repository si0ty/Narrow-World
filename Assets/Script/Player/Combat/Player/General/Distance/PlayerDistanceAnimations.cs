using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerDistanceAnimations : NetworkBehaviour
{
  
    [HideInInspector]
    public Animator anim;
    private PlayerDistanceCombat playerDistanceCombat;
    private PlayerDistanceMovement playerMovement;
    private PlayerHealthSystem playerHealthSystem;

      private PlayerValueSetter unitValueExchange;
    

    public Collider2D capsuleCollider;

    [HideInInspector]
    public Collider2D boxCollider;


    private Material material;
    private Color materialTintColor;
    private float tintFadeSpeed;

   public SpriteRenderer dropShadow;

    public int deathCount;
    public int idleCount;

    public Material damageMaterial;
    public Material dissolveMaterial;

    bool dissolving = false;
    private int dissolveTime = 4;
    float dissolveRate = 0f;

    public GameObject deathParticles;

    private void Awake() {
        materialTintColor = new Color(1, 0, 0, 0);
        SetMaterial(damageMaterial);
        tintFadeSpeed = 6f;
        GetComponent<SpriteRenderer>().material = material;
        // dropShadow = GetComponentInChildren<SpriteRenderer>();
       
    }

    private void Start() {
        anim = GetComponent<Animator>();

        unitValueExchange = GetComponent<PlayerValueSetter>();

        playerDistanceCombat = GetComponent<PlayerDistanceCombat>();
        playerMovement = GetComponent<PlayerDistanceMovement>();
        playerHealthSystem = GetComponent<PlayerHealthSystem>();
        boxCollider = GetComponent<BoxCollider2D>();

        dissolveMaterial.SetFloat("_DissolveAmount", 0);

        WalkingAnim();
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
        playerMovement.moveSpeed = playerMovement.walkSpeed ;
        
        anim.SetBool("Idle1", false);
        anim.SetBool("Idle2", false);
        anim.SetBool("Idle3", false);
        anim.SetBool("Idle4", false);
        anim.SetBool("Idle5", false);
        anim.SetBool("Running", false);
        anim.SetBool("Walking", true);
    }

    public void RollingAnim() {
        
            anim.SetTrigger("Roll");
        
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
        }
        else
        if (idleRandomiser == 2) {
            anim.SetBool("Idle2", true);
            anim.SetBool("Idle1", false);

            anim.SetBool("Idle3", false);
            anim.SetBool("Idle4", false);
            anim.SetBool("Idle5", false);
            return;
        }
        else

        if (idleRandomiser == 3) {
            anim.SetBool("Idle3", true);
            anim.SetBool("Idle1", false);
            anim.SetBool("Idle2", false);

            anim.SetBool("Idle4", false);
            anim.SetBool("Idle5", false);
            return;
        }
        else

        if (idleRandomiser == 4) {
            anim.SetBool("Idle4", true);
            anim.SetBool("Idle1", false);
            anim.SetBool("Idle2", false);
            anim.SetBool("Idle3", false);

            anim.SetBool("Idle5", false);
            return;
        }
        else

        if (idleRandomiser == 5) {
            anim.SetBool("Idle5", true);
            anim.SetBool("Idle1", false);
            anim.SetBool("Idle2", false);
            anim.SetBool("Idle3", false);
            anim.SetBool("Idle4", false);
            return;

        }

    }

    public void ShootingAnim() {
        playerMovement.moveSpeed = 0f;
        anim.SetBool("Walking", false);
        anim.SetBool("Running", false);
        anim.SetBool("Idle1", false);
        anim.SetBool("Idle2", false);
        anim.SetBool("Idle3", false);
        anim.SetBool("Idle4", false);
        anim.SetBool("Idle5", false);
        anim.SetTrigger("Shoot");

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

        anim.ResetTrigger("Shoot");
        anim.ResetTrigger("NormalCast");
        anim.ResetTrigger("SuperCast");


        if (unitValueExchange.smallGold == true) {
            unitValueExchange.DropGold("small");
        }
        

      if (unitValueExchange.mediumGold == true) {
            unitValueExchange.DropGold("medium");

        }
         if (unitValueExchange.largeGold == true) {
            unitValueExchange.DropGold("large");
        }
       if (unitValueExchange.largerGold == true) {
            unitValueExchange.DropGold("larger");
        }

        if (playerMovement.canRun == true) {
            anim.SetBool("Running", false);
        }

      

        playerMovement.enabled = false;
        playerDistanceCombat.enabled = false;

        int deathRandomiser = new int();
        deathRandomiser = Random.Range(1, deathCount + 1);

     
         if (deathRandomiser == 1) {
            anim.SetBool("Death1", true);
           
        }
        else

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
