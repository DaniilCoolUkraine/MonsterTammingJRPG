using Jrpg.GameCore.Core.DataStorage;
using Jrpg.GameCore.Extendables.Storageables;
using UnityEngine;

namespace Jrpg.GameCore.Extendables.ConcreteStorages
{
    [CreateAssetMenu(fileName = "SpawnableDataStorage", menuName = "Config/SpawnableDataStorage", order = 0)]
    public class SpawnableDataStorage : DataStorageBase<SpawnableStorageable>
    {
    }
}