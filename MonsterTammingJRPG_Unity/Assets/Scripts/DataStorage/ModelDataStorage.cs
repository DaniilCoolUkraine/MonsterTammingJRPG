using Jrpg.DataStorage.Storageables;
using UnityEngine;

namespace Jrpg.DataStorage
{
    [CreateAssetMenu(fileName = "ModelDataStorage", menuName = "Config/Visuals/ModelDataStorage", order = 0)]
    public class ModelDataStorage : DataStorageBase<ModelStorageable>
    {
    }
}