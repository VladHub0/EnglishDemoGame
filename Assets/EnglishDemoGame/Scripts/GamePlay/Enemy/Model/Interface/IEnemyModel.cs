
namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Interface
{
    public interface IEnemyModel
    {
        float Health { get; set; }
        float MaxHealth { get; }
        float Damage { get; set; }
        float Speed { get; set; }
        float AttackRange { get; }
        float AttackCooldown { get; }
        bool IsAlive { get; }
    }
}