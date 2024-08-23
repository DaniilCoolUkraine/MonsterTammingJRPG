using System;
using Jrpg.GameCore.Core.Interfaces;
using Jrpg.Spawnable;
using UnityEngine;

namespace Jrpg.GameCore.Extendables.Storageables
{
    [Serializable]
    public class ModelStorageable : IStorageable
    {
        [field:SerializeField] public int ID { get; set; }
        [field:SerializeField] public SceneSpawnable[] Spawnables { get; private set; }
    }
}