using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Enum;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.EnemyState.State.Interface;


namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Service.FabricEnemy.Interface
{
    public interface IEnemyStateFactory
    {
        IEnemyState CreateState(EnemyStateType stateType);
    }
}