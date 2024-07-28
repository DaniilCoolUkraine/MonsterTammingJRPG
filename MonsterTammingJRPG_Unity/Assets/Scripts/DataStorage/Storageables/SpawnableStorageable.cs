using System;
using BehTree.Interfaces;
using BehTree.Spawnable;
using UnityEngine;

namespace BehTree.DataStorage.Storageables
{
    [Serializable]
    public class SpawnableStorageable : IStorageable
    {
        [field:SerializeField] public int ID { get; set; }
        [field:SerializeField] public SceneSpawnable Spawnable { get; private set; }
    }
}