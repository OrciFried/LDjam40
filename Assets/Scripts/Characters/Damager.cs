using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {
    
    public string TargetTag { get; set; }
    public int Damage { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TargetTag)
        {
            Character collidedCharacter = collision.GetComponent<Character>();
            collidedCharacter.TakeDamage(Damage);
            collidedCharacter.PushInDirection(transform.position.x < collision.transform.position.x, 0.5f);
        }
    }
}
