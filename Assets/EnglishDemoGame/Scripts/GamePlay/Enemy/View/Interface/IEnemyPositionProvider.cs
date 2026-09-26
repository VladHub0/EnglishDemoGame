using UnityEngine;


namespace EnglishDemoGame.Scripts.GamePlay.Enemy.View.Interface
{
    public interface IEnemyPositionProvider
    {
        Vector3 Position { get; }
    }
}
