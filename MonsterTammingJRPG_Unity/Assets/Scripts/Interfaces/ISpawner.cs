using System.Collections.Generic;
using BehTree.DataStorage;
using Cysharp.Threading.Tasks;
using Zenject;

namespace BehTree.Interfaces
{
    public interface ISpawner <T, K> where T : DataStorageBase<K> where K : IStorageable
    {
        public void Init(T dataStorage, DiContainer container);
        public UniTask<IEnumerable<K>> Spawn(IEnumerable<int> requestedIds);
    }
}