using System;
using Jrpg.GameCore.Core.Interfaces;
using Jrpg.Spawnable;
using UnityEngine;

namespace Jrpg.GameCore.Extendables.Storageables
{
    [Serializable]
    public class SpawnableStorageable : IStorageable
    {
        [field:SerializeField] public int ID { get; set; }
        [field:SerializeField] public SceneSpawnable Spawnable { get; private set; }
    }
}