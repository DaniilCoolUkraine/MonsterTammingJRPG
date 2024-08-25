using UnityEngine;
using Random = System.Random;

namespace Jrpg.GameCore.Extendables.General
{
    public static class RandomExtensions
    {
        public static Vector3 NextVector3(this Random random, Vector3 lowerBounds, Vector3 upperBounds)
        {
            float randomX = random.NextFloat(lowerBounds.x, upperBounds.x);
            float randomY = random.NextFloat(lowerBounds.y, upperBounds.y);
            float randomZ = random.NextFloat(lowerBounds.z, upperBounds.z);

            return new Vector3(randomX, randomY, randomZ);
        }

        public static float NextFloat(this Random random, float min, float max)
        {
            return min + (float)random.NextDouble() * (max - min);
        }
    }
}