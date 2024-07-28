using BehTree.DataStorage;
using UnityEngine;
using Zenject;

namespace BehTree.Installers.ScriptableInstallers
{
    [CreateAssetMenu(fileName = "UnitsModelsInstaller", menuName = "Installers/ModelDataStorage", order = 0)]
    public class UnitsModelsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ModelDataStorage _unitsModelStorage;

        public override void InstallBindings()
        {
            Container.Bind<ModelDataStorage>().FromInstance(_unitsModelStorage).AsSingle();
        }
    }
}