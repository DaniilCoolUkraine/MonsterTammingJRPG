﻿using Jrpg.Interfaces;
using Jrpg.RuntimeData;
using UnityEngine;
using Zenject;

namespace Jrpg.Installers.MonoInstallers
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