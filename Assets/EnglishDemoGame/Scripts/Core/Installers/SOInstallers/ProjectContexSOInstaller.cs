using UnityEngine;
using Zenject;


namespace EnglishDemoGame.Scripts.Core.Installers.SOInstallers
{

    [CreateAssetMenu(fileName = "ProjectContextSOInstaller", menuName = "Installers/ProjectContextSOInstaller")]
    public class ProjectContextSOInstaller : ScriptableObjectInstaller<ProjectContextSOInstaller>
    {
        public override void InstallBindings()
        {

            SignalBusInstaller.Install(Container);

        }
    }
}