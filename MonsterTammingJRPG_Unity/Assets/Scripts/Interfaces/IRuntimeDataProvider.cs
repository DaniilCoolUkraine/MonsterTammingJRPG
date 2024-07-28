using BehTree.DataStorage;

namespace BehTree.Interfaces
{
    public interface IRuntimeDataProvider
    {
        public SpawnableDataStorage UnitStorage { get; }
        public ModelDataStorage UnitsModelStorage { get; }
    }
}