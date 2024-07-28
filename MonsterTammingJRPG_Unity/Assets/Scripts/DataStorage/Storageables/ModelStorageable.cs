using System;
using Jrpg.Interfaces;
using Jrpg.Spawnable;
using UnityEngine;

namespace Jrpg.DataStorage.Storageables
{
    [Serializable]
    public class ModelStorageable : IStorageable
    {
        [field:SerializeField] public int ID { get; set; }
        [field:SerializeField] public SceneSpawnable[] Spawnables { get; private set; }
    }
}