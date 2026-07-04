using UnityEngine;
using Zenject;
using EnglishDemoGame.Scripts.GamePlay.Hero;
using EnglishDemoGame.Scripts.GamePlay.Hero.Interface;
using EnglishDemoGame.Scripts.GamePlay.Hero.Service;

namespace EnglishDemoGame.Scripts.Core.Installers
{
    public class HeroInstaller : MonoInstaller
    {
        [SerializeField] private float moveSpeed = 5.0f;
        [SerializeField] private HeroController heroController;   
        [SerializeField] private Rigidbody2D heroRigidbody;      

        public override void InstallBindings()
        {
           
            Container.Bind<HeroController>()
                     .FromInstance(heroController)
                     .AsSingle();

           
            Container.Bind<Rigidbody2D>()
                     .FromInstance(heroRigidbody)
                     .AsSingle();

           
            Container.Bind<float>()
                     .FromInstance(moveSpeed)
                     .AsSingle();

           
            Container.Bind<IHeroMover>()
                     .To<HeroMoverImpl>()
                     .AsSingle();
        }
    }
}