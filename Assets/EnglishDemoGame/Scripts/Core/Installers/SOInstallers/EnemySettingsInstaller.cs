using EnglishDemoGame.Scripts.GamePlay.Enemy.Model;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.EnemyState;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.FabricEnemy;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.FabricEnemy.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService.Interface;

using UnityEngine;
using Zenject;

namespace EnglishDemoGame.Scripts.Core.Installers.SOInstallers
{
    [CreateAssetMenu(menuName = "Installers/Enemy Settings Installer", fileName = "EnemySettingsInstaller")]
    public class EnemySettingsInstaller : ScriptableObjectInstaller<EnemySettingsInstaller>
    {
        [SerializeField] private EnemySettingsSO enemySettingsSO;
        public override void InstallBindings()
        {
            Container.BindInstance(enemySettingsSO).AsSingle();

            Container.Bind<IEnemyStateFactory>().To<EnemyStateFactory>().AsSingle();
            Container.Bind<EnemyStateController>().FromComponentOnRoot().AsTransient();
            Container.Bind<IEnemyModel>().To<EnemyModel>().AsTransient();

            Container.Bind<IEnemyMovementService>()
                .To<EnemyMovementService>()
                .AsSingle();

            Container.Bind<Transform>()
                .FromResolveGetter<EnemyStateController>(c => c.GetTransform)
                .AsSingle()
                .WhenInjectedInto<EnemyMovementService>();
        }
    }
}