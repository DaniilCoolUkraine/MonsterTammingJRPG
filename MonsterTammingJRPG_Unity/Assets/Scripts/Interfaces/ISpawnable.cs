using Cysharp.Threading.Tasks;

namespace Jrpg.Interfaces
{
    public interface ISpawnable
    {
        public UniTask<bool> Spawn(int id);
    }
}