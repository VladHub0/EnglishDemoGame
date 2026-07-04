using EnglishDemoGame.Scripts.GamePlay.Hero;
using EnglishDemoGame.Scripts.Platform.PC;
using UnityEngine;
using Zenject;

namespace EnglishDemoGame.Scripts.Core.Installers
{

    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputReaderPC>()
                 .FromComponentInHierarchy()
                 .AsSingle();
            
        }
    }
}