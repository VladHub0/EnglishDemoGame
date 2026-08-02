using EnglishDemoGame.Scripts.Platform.PC;
using EnglishDemoGame.Scripts.Platform.PC.SOInput;
using UnityEngine;
using Zenject;

namespace EnglishDemoGame.Scripts.Core.Installers.SOInstallers
{
    [CreateAssetMenu(fileName = "InputSOInstaller", menuName = "Installers/InputSOInstaller")]
    public class InputSOInstaller : ScriptableObjectInstaller<InputSOInstaller>
    {

        [SerializeField] private InputConfigSO _inputConfig;
        public override void InstallBindings()
        {

            Container.BindInstance(_inputConfig).AsSingle();


            Container.BindInterfacesAndSelfTo<InputReaderPC>().AsSingle().NonLazy();
        }
    }
}