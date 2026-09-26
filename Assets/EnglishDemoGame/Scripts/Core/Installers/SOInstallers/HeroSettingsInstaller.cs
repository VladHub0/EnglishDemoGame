using EnglishDemoGame.Scripts.GamePlay.CommonInterface;
using EnglishDemoGame.Scripts.GamePlay.Hero;
using EnglishDemoGame.Scripts.GamePlay.Hero.Interface;
using EnglishDemoGame.Scripts.GamePlay.Hero.Service;
using EnglishDemoGame.Scripts.GamePlay.Hero.SO;
using UnityEngine;
using Zenject;

namespace EnglishDemoGame.Scripts.Core.Installers.SOInstallers
{
    [CreateAssetMenu(menuName = "Installers/Hero Settings Installer", fileName = "HeroSettingsInstaller")]
    public class HeroSettingsInstaller : ScriptableObjectInstaller<HeroSettingsInstaller>
    {
        [SerializeField] private HeroSettings HeroSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(HeroSettings).AsSingle();
            
            Container.BindInterfacesAndSelfTo<HeroController>()
                    .FromComponentOnRoot()
                    .AsSingle();

            Container.Bind<Rigidbody2D>()
                     .FromComponentOnRoot()
                     .AsSingle();

           
            Container.Bind<float>().WithId("MoveSpeed")
                     .FromInstance(HeroSettings.MoveSpeed);

            Container.Bind<float>().WithId("Offset")
                     .FromInstance(HeroSettings.Offset);

            Container.Bind<IHeroMover>()
                     .To<HeroMoverImpl>()
                     .AsSingle();
        }
    }
}