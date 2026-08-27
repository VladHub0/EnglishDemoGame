using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Enum;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.EnemyState.State;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.EnemyState.State.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.FabricEnemy.Interface;
using System;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Service.FabricEnemy
{
    public class EnemyStateFactory : IEnemyStateFactory
    {
        public IEnemyState CreateState(EnemyStateType stateType)
        {
            return stateType switch
            {
                EnemyStateType.Start => new EnemyStateStart(),
                EnemyStateType.Enraged => new EnemyStateEnraged(),
                EnemyStateType.Attack => new EnemyStateAttack(),
                EnemyStateType.LowHealth => new EnemyStateLowHealth(),
                EnemyStateType.Dead => new EnemyStateDead(),
                _ => throw new ArgumentOutOfRangeException(nameof(stateType), stateType, null)
            };
        }
    }
}