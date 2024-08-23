using Jrpg.GameCore.Core.DataStorage;
using Jrpg.GameCore.Extendables.Storageables;
using UnityEngine;

namespace Jrpg.GameCore.Extendables.ConcreteStorages
{
    [CreateAssetMenu(fileName = "ModelDataStorage", menuName = "Config/Visuals/ModelDataStorage", order = 0)]
    public class ModelDataStorage : DataStorageBase<ModelStorageable>
    {
    }
}