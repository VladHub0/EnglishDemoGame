using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "Enemy/MovementSettings")]
public class EnemyMovementSO : ScriptableObject
{
    [Header("Movement Stats")]
    public float speed = 5.0f;
    public float StoppingDistance = 0.01f;
}
