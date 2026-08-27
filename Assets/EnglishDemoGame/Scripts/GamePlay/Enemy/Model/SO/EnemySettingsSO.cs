using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "Enemy/Settings")]
public class EnemySettingsSO : ScriptableObject
{
    [Header("Base Stats")]
    public float maxHealth = 100f;
    public float damage = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 1f;
}