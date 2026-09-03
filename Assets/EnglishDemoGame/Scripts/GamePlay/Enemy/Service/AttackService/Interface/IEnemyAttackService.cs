using EnglishDemoGame.Scripts.GamePlay.CommonInterface;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Service.AttackService.Interface
{
    public interface IEnemyAttackService
    {
        void Attack(IDamageable target);
    }
}
