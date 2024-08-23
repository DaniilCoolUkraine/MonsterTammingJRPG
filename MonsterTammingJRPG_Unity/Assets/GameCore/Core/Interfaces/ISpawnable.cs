using Cysharp.Threading.Tasks;

namespace Jrpg.GameCore.Core.Interfaces
{
    public interface ISpawnable
    {
        public UniTask<bool> Spawn(int id);
    }
}