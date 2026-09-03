using EnglishDemoGame.Scripts.GamePlay.CommonInterface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.AttackService.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.DamageCalculator.Interface;



namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Service.AttackService
{
    public class EnemyAttackService : IEnemyAttackService
    {
        private readonly IEnemyAttackModel _enemyAttackModel;
        private readonly IDamageCalculator _damageCalculator;
        public EnemyAttackService(IEnemyAttackModel enemyAttackModel, IDamageCalculator damageCalculator ) 
        {
            _enemyAttackModel = enemyAttackModel;
            _damageCalculator = damageCalculator;
        }


        public void Attack(IDamageable target)
        {
            if(target == null || !target.IsAlive)
            {
                return;
            }

            var damage = _damageCalculator.CalculateDamage(
           _enemyAttackModel);

            target.ApplyDamage(damage);
        }
    }
}
