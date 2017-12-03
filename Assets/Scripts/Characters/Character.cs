using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour {

    [SerializeField]
	int health;
    public float speed, pushForce;

    [SerializeField]
    protected Animator animControl;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health <= 0)
                Die();
        }
    }

    protected Rigidbody2D rb2d;
    protected bool stunned = false;
    protected SpriteRenderer charSprite;

    public virtual void Awake()
    {
        if (charSprite == null)
            charSprite = transform.GetComponentInChildren<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public virtual void FixedUpdate()
    {

    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void TakeDamage (int damage)
    {
        Health -= damage;
        Managers.ins.AM.Play("hurt");
        StartCoroutine(HitEffect());
    }

    public virtual void Die()
    {
        Debug.Log("A " + this + " died.");
    }

    public virtual void Attack()
    {
        animControl.SetTrigger("attack");
        StartCoroutine(StunForTime(.3f));
    }

    public virtual void PushInDirection(bool right, float stunTime, float pushForceMultiplier = 1)
    {
        StartCoroutine(PushInDirectionCoroutine(right, stunTime, pushForceMultiplier));
    }

    public virtual IEnumerator PushInDirectionCoroutine(bool right, float stunTime, float pushForceMultiplier = 1)
    {
        if (right)
            rb2d.AddForce(Vector2.right * pushForce * pushForceMultiplier + Vector2.up * 1f, ForceMode2D.Impulse);
        else
            rb2d.AddForce(Vector2.left * pushForce * pushForceMultiplier + Vector2.up * 1f, ForceMode2D.Impulse);
        stunned = true;
        yield return new WaitForSeconds(stunTime);
        stunned = false;
    }

    public virtual IEnumerator StunForTime(float time)
    {
        yield return new WaitForSeconds(0.1f);
        stunned = true;
        rb2d.velocity = Vector2.zero;
        yield return new WaitForSeconds(time);
        stunned = false;
    }

    public virtual IEnumerator HitEffect()
    {
        charSprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        charSprite.color = Color.white;
    }

    
}
