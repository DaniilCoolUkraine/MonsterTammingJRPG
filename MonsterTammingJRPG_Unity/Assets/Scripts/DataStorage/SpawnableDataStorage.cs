using Jrpg.DataStorage.Storageables;
using UnityEngine;

namespace Jrpg.DataStorage
{
    [CreateAssetMenu(fileName = "SpawnableDataStorage", menuName = "Config/SpawnableDataStorage", order = 0)]
    public class SpawnableDataStorage : DataStorageBase<SpawnableStorageable>
    {
    }
}