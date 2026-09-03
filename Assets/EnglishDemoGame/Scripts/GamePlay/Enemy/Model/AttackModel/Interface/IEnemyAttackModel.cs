
namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Interface
{
    public interface IEnemyAttackModel
    {
      
        float MaxDamage { get; }
        float BaseDamage { get; set; }
        float AttackRange { get; }
        float AttackCooldown { get; }
    }
}