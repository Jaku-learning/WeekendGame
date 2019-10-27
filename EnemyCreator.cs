using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy")]
public class EnemyCreator : ScriptableObject
{
    public string enemyName;
    public int enemyHealth;
    public int enemyChaseSpeed;
    public int minDamage;
    public int maxDamage;
}
