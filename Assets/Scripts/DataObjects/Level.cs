using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data Object/Level")]
public class Level : ScriptableObject
{
    public int requiredXP = 10;
    public int number;
    public Upgrade[] upgrades = new Upgrade[3];
}
