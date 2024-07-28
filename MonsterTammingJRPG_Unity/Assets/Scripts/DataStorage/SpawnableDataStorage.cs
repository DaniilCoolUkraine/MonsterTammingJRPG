using BehTree.DataStorage.Storageables;
using UnityEngine;

namespace BehTree.DataStorage
{
    [CreateAssetMenu(fileName = "SpawnableDataStorage", menuName = "Config/SpawnableDataStorage", order = 0)]
    public class SpawnableDataStorage : DataStorageBase<SpawnableStorageable>
    {
    }
}