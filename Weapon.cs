using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon")]
public class Weapons : ScriptableObject
{
    public string weaponName;
    public int weaponDamage;
    public bool isRange;
}
