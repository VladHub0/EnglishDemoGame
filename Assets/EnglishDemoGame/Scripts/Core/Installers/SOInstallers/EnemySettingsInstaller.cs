using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Enum;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.MovementModel;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.MovementModel.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Presenter;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Presenter.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.View;
using EnglishDemoGame.Scripts.GamePlay.Enemy.View.Interface;
using UnityEngine;
using Zenject;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.EnemyFactory;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyFactory.Interface;

namespace EnglishDemoGame.Scripts.Core.Installers.SOInstallers
{
    [CreateAssetMenu(menuName = "Installers/Enemy Settings Installer", fileName = "EnemySettingsInstaller")]
    public class EnemySettingsInstaller : ScriptableObjectInstaller<EnemySettingsInstaller>
    {
        [SerializeField] private EnemySettingsSO enemySettingsSO;
        [SerializeField] private EnemyMovementSO enemyMovementSO;
        public override void InstallBindings()
        {
            EnemyModelBindings();
            EnemyServiceBindings();
            EnemyPresenterBindings();
            EnemyViewBindings();

            EnemyStateMachine();
        }

        private void EnemyStateMachine()
        {
            Container.Bind<EnemyStateType>()
                .AsSingle();
            Container.BindFactoryCustomInterface<EnemyStateType, IEnemyState, EnemyStateFactory, IEnemyStateFactory>()
                .FromFactory<EnemyStateFactory>();
            Container.Bind<EnemyStateMachine>()
                .AsSingle();
        }

        private void EnemyModelBindings()
        {

            Container.BindInstance(enemyMovementSO)
                .AsSingle();

            Container.Bind<IEnemyMovementModel>()
                .To<EnemyMovementModel>()
                .AsSingle();  
        }

        private void EnemyServiceBindings()
        {
            Container.Bind<IEnemyMovementService>()
                .To<EnemyMovementService>()
                .AsSingle();
        }
        private void EnemyPresenterBindings()
        {
            Container.Bind<IEnemyPresenter>()
                .To<EnemyBasePresenter>()
                .AsSingle();
        }

        private void EnemyViewBindings()
        {
            Container.Bind<IEnemyView>()
                .To<EnemyBaseView>()
                .FromComponentOnRoot()
                .AsSingle();
        }
    }
}