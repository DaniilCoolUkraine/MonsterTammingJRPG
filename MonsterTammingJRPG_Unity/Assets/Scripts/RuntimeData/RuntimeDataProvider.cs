using BehTree.DataStorage;
using BehTree.Interfaces;
using UnityEngine;
using Zenject;

namespace BehTree.RuntimeData
{
    public class RuntimeDataProvider : MonoBehaviour, IRuntimeDataProvider
    {
        [Inject] private SpawnableDataStorage _unitStorage;
        [Inject] private ModelDataStorage _unitsModelsStorage;

        public SpawnableDataStorage UnitStorage => _unitStorage;
        public ModelDataStorage UnitsModelStorage => _unitsModelsStorage;
    }
}