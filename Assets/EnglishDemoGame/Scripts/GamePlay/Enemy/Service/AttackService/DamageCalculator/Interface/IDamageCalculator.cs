using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Interface;


namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Service.DamageCalculator.Interface
{
    public interface IDamageCalculator
    {
        float CalculateDamage(IEnemyAttackModel attackModel);
    }
}
