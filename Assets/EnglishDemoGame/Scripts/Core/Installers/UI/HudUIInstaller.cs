using EnglishDemoGame.Scripts.UI.Interface;
using EnglishDemoGame.Scripts.UI.ServiceImpl;

using Zenject;


namespace EnglishDemoGame.Scripts.Core.Installers.UI
{
    public class HudUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPreviewTextProvider>().To<PreviewTextProviderImpl>().AsSingle();
        }
    }
}