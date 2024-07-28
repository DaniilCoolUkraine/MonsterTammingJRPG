using System;
using BehTree.Interfaces;
using BehTree.Spawnable;
using UnityEngine;

namespace BehTree.DataStorage.Storageables
{
    [Serializable]
    public class ModelStorageable : IStorageable
    {
        [field:SerializeField] public int ID { get; set; }
        [field:SerializeField] public SceneSpawnable[] Spawnables { get; private set; }
    }
}