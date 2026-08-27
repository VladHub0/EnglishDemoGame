using EnglishDemoGame.Scripts.GamePlay.Enemy.Model;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.MovementModel;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.MovementModel.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Presenter;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Presenter.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.View;
using EnglishDemoGame.Scripts.GamePlay.Enemy.View.Interface;
using UnityEngine;
using Zenject;

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
         
        }

        public void EnemyModelBindings()
        {

            Container.BindInstance(enemyMovementSO)
                .AsSingle();

            Container.Bind<IEnemyMovementModel>()
                .To<EnemyMovementModel>()
                .AsSingle();  
        }

        public void EnemyServiceBindings()
        {
            Container.Bind<IEnemyMovementService>()
                .To<EnemyMovementService>()
                .AsSingle();
        }
        public void EnemyPresenterBindings()
        {
            Container.Bind<IEnemyPresenter>()
                .To<EnemyBasePresenter>()
                .AsSingle();
        }

        public void EnemyViewBindings()
        {
            Container.Bind<IEnemyView>()
                .To<EnemyBaseView>()
                .FromComponentOnRoot()
                .AsSingle();
        }
    }
}