using Jrpg.GameCore.Extendables.ConcreteStorages;

namespace Jrpg.GameCore.Core.Interfaces
{
    public interface IRuntimeDataProvider
    {
        public SpawnableDataStorage UnitStorage { get; }
        public ModelDataStorage UnitsModelStorage { get; }
    }
}