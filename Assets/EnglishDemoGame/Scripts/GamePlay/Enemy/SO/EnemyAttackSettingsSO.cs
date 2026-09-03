using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "Enemy/EnemyAttackSettings")]
public class EnemyAttackSettingsSO : ScriptableObject
{
    [Header("Base Stats")]
    public float maxDamage = 50f;
    public float baseDamage = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 1f;
}