using Jrpg.GameCore.Core.Interfaces;
using Jrpg.GameCore.Extendables.ConcreteStorages;
using UnityEngine;

namespace Jrpg.RuntimeData
{
    public class RuntimeDataProvider : MonoBehaviour, IRuntimeDataProvider
    {
        [SerializeField] private SpawnableDataStorage _unitStorage;
        [SerializeField] private ModelDataStorage _unitsModelsStorage;

        public SpawnableDataStorage UnitStorage => _unitStorage;
        public ModelDataStorage UnitsModelStorage => _unitsModelsStorage;
    }
}