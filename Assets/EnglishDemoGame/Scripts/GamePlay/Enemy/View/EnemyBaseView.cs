using EnglishDemoGame.Scripts.GamePlay.Enemy.Presenter.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.View.Interface;
using UnityEngine;
using Zenject;


namespace EnglishDemoGame.Scripts.GamePlay.Enemy.View
{
    public class EnemyBaseView : MonoBehaviour, IEnemyView
    {
        private IEnemyPresenter _presenter;

        [Inject]
        public void Construct(IEnemyPresenter enemyPresenter)
        {
            _presenter = enemyPresenter;
        }

        
        public Vector3 Position => transform.position;

        public void SetDirection(Vector3 direction)
        {
            if (direction.x != 0)
            {
                Vector3 newScale = transform.localScale;
                newScale.x = Mathf.Abs(newScale.x) * Mathf.Sign(direction.x);
                transform.localScale = newScale;
            }
        }

        public void SetPosition(Vector3 position)
        {

           transform.position = position;
           
        }

        private void Update()
        {
           
            _presenter.Tick();
        }
    }
}
