using Cysharp.Threading.Tasks;

namespace Jrpg.Spawnable.Units
{
    public class ModelSpawnable : SceneSpawnable
    {
        public override UniTask<bool> Spawn(int id)
        {
            return new UniTask<bool>(true);
        }
    }
}