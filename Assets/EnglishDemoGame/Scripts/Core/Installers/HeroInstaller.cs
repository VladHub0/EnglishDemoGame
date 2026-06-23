using EnglishDemoGame.Scripts.Core.Utils.InputUtils;
using EnglishDemoGame.Scripts.GamePlay.Hero;
using EnglishDemoGame.Scripts.Platform.PC;
using UnityEngine;
using Zenject;

namespace EnglishDemoGame.Scripts.Core.Installers
{
    public class HeroInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputReaderPC>()
                  .FromComponentInHierarchy()   
                  .AsSingle();

           
            Container.Bind<HeroController>()
                     .FromComponentInHierarchy()
                     .AsSingle();
        }
    }
}