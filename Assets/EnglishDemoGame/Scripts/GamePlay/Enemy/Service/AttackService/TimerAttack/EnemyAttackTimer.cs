using EnglishDemoGame.Scripts.GamePlay.CommonInterface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Interface;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Service.AttackService.TimerAttack { 

    public sealed class EnemyAttackTimer : Timer
    {
        public EnemyAttackTimer(IEnemyAttackModel attackModel)
            : base(attackModel.AttackCooldown)
        {
        }
    }
}