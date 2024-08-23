using Jrpg.GameCore.Core.Interfaces;
using Jrpg.GameCore.Extendables.ConcreteStorages;
using UnityEngine;
using Zenject;

namespace Jrpg.RuntimeData
{
    public class RuntimeDataProvider : MonoBehaviour, IRuntimeDataProvider
    {
        [Inject] private SpawnableDataStorage _unitStorage;
        [Inject] private ModelDataStorage _unitsModelsStorage;

        public SpawnableDataStorage UnitStorage => _unitStorage;
        public ModelDataStorage UnitsModelStorage => _unitsModelsStorage;
    }
}