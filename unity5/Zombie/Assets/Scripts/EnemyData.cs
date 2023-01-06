using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable/EnemyData")] 
public class EnemyData : ScriptableObject
{
    public float damage = 20f;
    public float health = 100f;
    public float speed = 1f;
    public Color color = Color.white;

}
