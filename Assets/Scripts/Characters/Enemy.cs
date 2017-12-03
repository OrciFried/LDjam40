using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    int damage = 5;

    [SerializeField]
    float cooldown = 1f;

    [SerializeField]
    string targetTag = "Player";

    [SerializeField]
    Damager damager;

    [SerializeField]
    RangeDetector rangeDetector;

    protected Transform target;

    bool cdOff = true;
    bool inRange = false;
    public bool InRange { get { return inRange; } set { inRange = value; } }

    public override void Start()
    {
        GetComponent<Animator>();
        target = FindObjectOfType<Player>().transform;
        damager.TargetTag = targetTag;
        damager.Damage = damage;
        rangeDetector.TargetTag = targetTag;
        rangeDetector.parent = this;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (!stunned && !inRange)
        {
            if (target.position.x > transform.position.x)
                rb2d.velocity = Vector2.right * speed;
            else if (target.position.x < transform.position.x)
                rb2d.velocity = Vector2.left * speed;
        }
        else if (inRange && cdOff)
            Attack();
        if(!inRange)
        animControl.SetFloat("speed", target.position.x > transform.position.x ? 1 : -1);
        else
            animControl.SetFloat("speed", 0);
    }

    public override void Die()
    {
        base.Die();
        Managers.ins.GPM.XP++;
        Managers.ins.GPM.Points++;
        Managers.ins.UIM.AddXPUI();
        Destroy(gameObject);
    }

    public override void Attack()
    {
        base.Attack();
        StartCoroutine(CoolDown());
    }

    public virtual IEnumerator CoolDown()
    {
        cdOff = false;
        yield return new WaitForSeconds(cooldown);
        cdOff = true;
    }
}
