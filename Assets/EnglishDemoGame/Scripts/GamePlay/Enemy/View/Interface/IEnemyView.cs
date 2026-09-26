
using UnityEngine;

namespace EnglishDemoGame.Scripts.GamePlay.Enemy.View.Interface
{
    public interface IEnemyView
    {
        Vector3 Position { get; }
        void SetPosition(Vector3 position);
        void SetDirection(Vector3 direction);
    }
}
