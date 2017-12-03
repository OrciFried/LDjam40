using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetector : MonoBehaviour {

    public Enemy parent;
    public string TargetTag { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TargetTag)
            parent.InRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == TargetTag)
            parent.InRange = false;
    }
}
