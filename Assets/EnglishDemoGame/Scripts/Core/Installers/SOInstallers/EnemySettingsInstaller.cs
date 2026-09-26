using EnglishDemoGame.Scripts.GamePlay.CommonInterface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Enum;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.MovementModel;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.MovementModel.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Presenter;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Presenter.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.AttackService;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.AttackService.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.AttackService.TimerAttack;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.DamageCalculator.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.EnemyFactory;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyFactory;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyFactory.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.View;
using EnglishDemoGame.Scripts.GamePlay.Enemy.View.Interface;
using UnityEngine;
using Zenject;

namespace EnglishDemoGame.Scripts.Core.Installers.SOInstallers
{
    [CreateAssetMenu(menuName = "Installers/Enemy Settings Installer", fileName = "EnemySettingsInstaller")]
    public class EnemySettingsInstaller : ScriptableObjectInstaller<EnemySettingsInstaller>
    {
        [SerializeField] private EnemyAttackSettingsSO enemySettingsSO;
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
            Container.Bind<EnemyStateMachineBuilder>().AsSingle();
            
            Container.BindFactoryCustomInterface<EnemyStateType, IEnemyState, EnemyStateFactory, IEnemyStateFactory>()
                .FromFactory<EnemyStateFactory>();
            Container.Bind<EnemyStateMachine>()
                .AsSingle();
        }

        private void EnemyModelBindings()
        {

            Container.BindInstance(enemyMovementSO)
                .AsSingle();

            Container.BindInstance(enemySettingsSO)
                .AsSingle();

            Container.Bind<IEnemyMovementModel>()
                .To<EnemyMovementModel>()
                .AsSingle(); 
            Container.Bind<IEnemyAttackModel>()
                .To<EnemyAttackModel>()
                .AsSingle();

        }

        private void EnemyServiceBindings()
        {
            Container.Bind<IEnemyMovementService>()
                .To<EnemyMovementService>()
                .AsSingle();

            Container.Bind<IEnemyAttackService>()
               .To<EnemyAttackService>()
               .AsSingle();

            Container.Bind<Timer>()
                .To<EnemyAttackTimer>()
                .AsSingle();
            Container.Bind<IDamageCalculator>()
                .To<RageDamageCalculator>()
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
            Container.BindInterfacesTo<EnemyBaseView>()
                .FromComponentOnRoot()
                .AsSingle();

        }
    }
}