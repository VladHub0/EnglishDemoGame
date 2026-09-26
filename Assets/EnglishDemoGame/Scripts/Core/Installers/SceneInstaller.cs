using EnglishDemoGame.Scripts.GamePlay.CommonInterface;
using EnglishDemoGame.Scripts.GamePlay.Hero;
using EnglishDemoGame.Scripts.GamePlay.Hero.SpawnHero;
using EnglishDemoGame.Scripts.GamePlay.TargetProvider;
using EnglishDemoGame.Scripts.GamePlay.TargetProvider.Interface;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace EnglishDemoGame.Scripts.Core.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject heroPrefab;
        [SerializeField] private Vector2 HeroSpawnPosition;
        public override void InstallBindings()
        {
            Container.BindInstance(HeroSpawnPosition).WithId("HeroSpawnPoint");

            Container.Bind<ITargetProvider>().To<PlayerTargetProvider>().AsSingle();

           
            Container.Bind<HeroController>()
                .FromSubContainerResolve()
                .ByNewContextPrefab(heroPrefab)
                .AsSingle();

            
            Container.Bind<IDamageable>()
                .FromMethod(ctx => ctx.Container.Resolve<HeroController>())
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<HeroSpawnManager>()
                     .AsSingle().NonLazy();
        }
    }
}