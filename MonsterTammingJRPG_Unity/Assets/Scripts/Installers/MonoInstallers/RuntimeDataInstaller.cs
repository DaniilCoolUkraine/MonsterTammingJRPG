using BehTree.Interfaces;
using BehTree.RuntimeData;
using UnityEngine;
using Zenject;

namespace BehTree.Installers.MonoInstallers
{
    public class RuntimeDataInstaller : MonoInstaller
    {
        [SerializeField] private RuntimeDataProvider _runtimeDataProvider;
        
        public override void InstallBindings()
        {
            Container.Bind<IRuntimeDataProvider>().To<RuntimeDataProvider>().FromInstance(_runtimeDataProvider).AsSingle();
        }
    }
}