using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Jrpg.DataStorage;
using Zenject;

namespace Jrpg.Interfaces
{
    public interface ISpawner <TStorage, TStorageable, TSpawnable> where TStorage : DataStorageBase<TStorageable> where TStorageable : IStorageable where TSpawnable : ISpawnable
    {
        public void Init(TStorage dataStorage, DiContainer container);
        public UniTask<IEnumerable<TSpawnable>> Spawn(IEnumerable<int> requestedIds);
    }
}