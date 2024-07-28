using Cysharp.Threading.Tasks;

namespace BehTree.Interfaces
{
    public interface ISpawnable
    {
        public UniTask<bool> Spawn(int id);
    }
}