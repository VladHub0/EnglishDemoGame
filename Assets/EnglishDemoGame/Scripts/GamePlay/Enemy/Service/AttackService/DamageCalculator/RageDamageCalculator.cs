using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.DamageCalculator.Interface;
using UnityEngine;

public sealed class RageDamageCalculator : IDamageCalculator
{
    public float CalculateDamage(IEnemyAttackModel attackModel)
    {
        return Random.Range(
            attackModel.BaseDamage,
            attackModel.MaxDamage);
    }
}
