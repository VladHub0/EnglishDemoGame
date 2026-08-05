using EnglishDemoGame.Scripts.GamePlay.Hero;
using EnglishDemoGame.Scripts.GamePlay.Hero.SpawnHero;
using UnityEngine;
using Zenject;

namespace EnglishDemoGame.Scripts.Core.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject heroPrefab;
        [SerializeField] private Vector2 HeroSpawnPosition;
        public override void InstallBindings()
        {
            Container.BindInstance(HeroSpawnPosition).WithId("HeroSpawnPoint");

            Container.Bind<HeroController>()
                     .FromSubContainerResolve()
                     .ByNewContextPrefab(heroPrefab)
                     .AsSingle();


            Container.BindInterfacesAndSelfTo<HeroSpawnManager>()
                     .AsSingle().NonLazy();
        }
    }
}