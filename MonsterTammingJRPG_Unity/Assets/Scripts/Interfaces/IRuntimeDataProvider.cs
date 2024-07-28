using Jrpg.DataStorage;

namespace Jrpg.Interfaces
{
    public interface IRuntimeDataProvider
    {
        public SpawnableDataStorage UnitStorage { get; }
        public ModelDataStorage UnitsModelStorage { get; }
    }
}