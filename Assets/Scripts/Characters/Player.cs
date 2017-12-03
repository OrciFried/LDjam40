using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    [SerializeField]
    int damage = 5;

    [SerializeField]
    string targetTag = "Enemy";

    [SerializeField]
    KeyCode attack, tumble;

    [SerializeField]
    Damager playerDamager;

    [SerializeField]
    bool inMenu = false;
    bool tumbleCDOff = true;

    [SerializeField]
    float alwaysAboveThisY = -6, maxSpeed = 7.5f;

    public override void Start()
    {
        base.Start();
        if (animControl == null)
            GetComponent<Animator>();
        playerDamager.TargetTag = targetTag;
        playerDamager.Damage = damage;
        if (!inMenu)
        {
            Managers.ins.UIM.HealthBar.maxValue = Health;
            Managers.ins.UIM.HealthBar.value = Health;
            Managers.ins.UIM.SubtractValueFromHP(0);
        }
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(attack))
            Attack();
        if (Input.GetKeyDown(tumble) && tumbleCDOff)
            Tumble();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (!stunned && Mathf.Abs(rb2d.velocity.x) < maxSpeed)
            rb2d.AddForce(Vector2.right * Input.GetAxis("Horizontal") * speed);

        animControl.SetFloat("speed", Input.GetAxis("Horizontal"));

        if (transform.position.y < alwaysAboveThisY)
            rb2d.AddForce(Vector2.up * (transform.position.y - alwaysAboveThisY));
    }

    public override void Die()
    {
        base.Die();
        SceneManager.LoadScene("EndScreen");
    }

    public override void Attack()
    {
        base.Attack();
    }

    public void Tumble()
    {
        animControl.SetTrigger("tumble");
        StartCoroutine(TumbleCoroutine());
    }

    IEnumerator TumbleCoroutine()
    {
        tumbleCDOff = false;
        yield return new WaitForSeconds(1f);
        tumbleCDOff = true;
    }

    public void TumbleStun()
    {
        PushInDirection(rb2d.velocity.x >= 0, .5f, 3f);
        Managers.ins.AM.Play("tumble");
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        Managers.ins.AM.Play("playerdamaged");
        Managers.ins.VFX.HitEffect();
        Managers.ins.UIM.SubtractValueFromHP(damage);
    }

    public void PlayFootstep()
    {
        Managers.ins.AM.SetPitch("footstep", Random.Range(0.9f, 1.1f));
        Managers.ins.AM.Play("footstep");
    }
}
