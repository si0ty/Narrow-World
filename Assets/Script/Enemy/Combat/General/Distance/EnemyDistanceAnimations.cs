using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using NarrowWorld.Combat;

public class EnemyDistanceAnimations : NetworkBehaviour
{
    [HideInInspector]
    public Animator anim;
    private EnemyDistanceCombat enemyDistanceCombat;
    private EnemyDistanceMovement enemyMovement;
    private EnemyHealthSystem enemyHealthSystem;
   
    private PlayerValueSetter unitValueExchange;
    public GameObject castPoint;


    public Collider2D capsuleCollider;

    [HideInInspector]
    public Collider2D boxCollider;


    private Material material;
    private Color materialTintColor;
    private float tintFadeSpeed;


    public int deathCount;
    public int idleCount;

    public Material damageMaterial;
    public Material dissolveMaterial;

    public SpriteRenderer dropShadow;

    bool dissolving = false;
    private int dissolveTime = 4;
    float dissolveRate = 0;

    public GameObject deathParticles;

    private SpriteRenderer spriteRenderer;

   

    private void Awake() {
        materialTintColor = new Color(1, 0, 0, 0);
        SetMaterial(GetComponent<SpriteRenderer>().material);
        tintFadeSpeed = 6f;
        GetComponent<SpriteRenderer>().material = material;

    }

    private void Start() {

        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        unitValueExchange = GetComponent<PlayerValueSetter>();

        enemyDistanceCombat = GetComponent<EnemyDistanceCombat>();
        enemyMovement = GetComponent<EnemyDistanceMovement>();
        enemyHealthSystem = GetComponent<EnemyHealthSystem>();
        boxCollider = GetComponent<BoxCollider2D>();

        spriteRenderer.material = damageMaterial;
        dissolveMaterial.SetFloat("_DissolveAmount", 0);

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

    [Command]
    public void WalkingAnim() {
        WalkingAnimEffect();
    }

    [ClientRpc]
    public void WalkingAnimEffect() {
        enemyMovement.moveSpeed = enemyMovement.walkSpeed;

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

    [Command]
    public void RunningAnim() {
        RunningAnimEffect();
    }

     [ClientRpc]
    public void RunningAnimEffect() {
        enemyMovement.moveSpeed = enemyMovement.runSpeed;

        anim.SetBool("Idle1", false);
        anim.SetBool("Idle2", false);
        anim.SetBool("Idle3", false);
        anim.SetBool("Idle4", false);
        anim.SetBool("Idle5", false);
        anim.SetBool("Running", true);
        anim.SetBool("Walking", false);
    }

    [Command]
    public void IdleAnim() {
        IdleAnimEffect();
    }

    [ClientRpc]
    public void IdleAnimEffect() {
        enemyMovement.moveSpeed = 0f;
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

    [Command]
    public void NormalCastAnim() {
        NormalCastAnimEffect();
    }

    [ClientRpc]
    public void NormalCastAnimEffect() {

        enemyMovement.moveSpeed = 0f;
        anim.SetBool("Walking", false);
        anim.SetBool("Running", false);
        anim.SetBool("Idle1", false);
        anim.SetBool("Idle2", false);
        anim.SetBool("Idle3", false);
        anim.SetBool("Idle4", false);
        anim.SetBool("Idle5", false);
       anim.SetTrigger("NormalCast");
       
    }

    [Command]
    public void SuperCastAnim() {
        SuperCastAnimEffect();
    }

    [ClientRpc]
    public void SuperCastAnimEffect() {

        enemyMovement.moveSpeed = 0f;
        anim.SetBool("Walking", false);
        anim.SetBool("Running", false);
        anim.SetBool("Idle1", false);
        anim.SetBool("Idle2", false);
        anim.SetBool("Idle3", false);
        anim.SetBool("Idle4", false);
        anim.SetBool("Idle5", false);
        anim.SetTrigger("SuperCast");

    }

    [Command]
    public void ShootingAnim() {
        ShootingAnimEffect();
    }

    [ClientRpc]
    public void ShootingAnimEffect() {
        AudioManager.instance.Play("BowDraw1");
        enemyMovement.moveSpeed = 0f;
        anim.SetBool("Walking", false);
        anim.SetBool("Running", false);
        anim.SetBool("Idle1", false);
        anim.SetBool("Idle2", false);
        anim.SetBool("Idle3", false);
        anim.SetBool("Idle4", false);
        anim.SetBool("Idle5", false);
        anim.SetTrigger("Shoot");
    }


    [Command]
    public void HurtAnim() {

        HurtAnimEffect();

    }

    [ClientRpc]
    public void HurtAnimEffect() {
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

    [Command]
    public void Die() {
        DieEffect();
    }

    [ClientRpc]
    public void DieEffect() {

        anim.SetBool("Idle5", false);
        anim.SetBool("Idle1", false);
        anim.SetBool("Idle2", false);
        anim.SetBool("Idle3", false);
        anim.SetBool("Idle4", false);

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


        if (enemyMovement.canRun == true) {
            anim.SetBool("Running", false);
        }

        anim.SetBool("Walking", false);

        enemyMovement.enabled = false;
        enemyDistanceCombat.enabled = false;

        int deathRandomiser = new int();
        deathRandomiser = Random.Range(1, deathCount);

        if (deathRandomiser == 1) {
            anim.SetBool("Death1", true);

        }
        else

        if (deathRandomiser == 2) {
            anim.SetBool("Death2", true);

        }


        enemyHealthSystem.enabled = false;
        boxCollider.enabled = false;
        capsuleCollider.enabled = false;
      
        GetComponent<Collider2D>().enabled = false;
       

        GetComponent<Rigidbody2D>().gravityScale = 0;
        StartCoroutine(DeathWait());
    }
}
