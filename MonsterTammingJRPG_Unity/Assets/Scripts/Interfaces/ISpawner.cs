using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Jrpg.DataStorage;
using Zenject;

namespace Jrpg.Interfaces
{
    public interface ISpawner <T, K> where T : DataStorageBase<K> where K : IStorageable
    {
        public void Init(T dataStorage, DiContainer container);
        public UniTask<IEnumerable<K>> Spawn(IEnumerable<int> requestedIds);
    }
}