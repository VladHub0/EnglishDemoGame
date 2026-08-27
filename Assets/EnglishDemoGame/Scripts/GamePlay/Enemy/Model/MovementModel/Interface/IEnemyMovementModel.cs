using UnityEngine;


namespace EnglishDemoGame.Scripts.GamePlay.Enemy.Model.MovementModel.Interface
{
    public interface IEnemyMovementModel
    {
        float Speed { get; }
        float StoppingDistance { get; }
       
    }
}
