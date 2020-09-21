using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class EnemyData : ScriptableObject
{
    public GameObject prefab;

    public float maxHealth;
    public float maxShields;
    public float power;
    public float critChance;
    public string name;

    public EnemyBehaviorType enemyBehavior;
    public EnemyWeaponType enemyWeaponType;
    public EnemyDMGType enemyDMGType;
}