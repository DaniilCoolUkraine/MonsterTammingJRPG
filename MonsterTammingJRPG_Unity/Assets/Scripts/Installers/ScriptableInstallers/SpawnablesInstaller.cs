using Jrpg.GameCore.Extendables.ConcreteStorages;
using UnityEngine;
using Zenject;

namespace Jrpg.Installers.ScriptableInstallers
{
    [CreateAssetMenu(fileName = "SpawnablesInstaller", menuName = "Installers/SpawnablesInstaller", order = 0)]
    public class SpawnablesInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private SpawnableDataStorage _spawnablesStorage;

        public override void InstallBindings()
        {
            Container.Bind<SpawnableDataStorage>().FromInstance(_spawnablesStorage).AsSingle();
        }
    }
}