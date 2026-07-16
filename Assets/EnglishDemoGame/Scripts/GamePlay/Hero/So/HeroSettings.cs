using UnityEngine;

[CreateAssetMenu(fileName = "HeroSettings", menuName = "Settings/Hero")]
public class HeroSettings : ScriptableObject
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _offset = 0.5f;

    public float MoveSpeed => _moveSpeed;
    public float Offset => _offset;
}