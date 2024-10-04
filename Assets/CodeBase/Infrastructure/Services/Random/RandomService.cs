using CodeBase.Infrastructure.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Random
{
    public class RandomService : IRandomService
    {
        private System.Random _random;

        public RandomService(int seed)
        {
            _random = new System.Random(seed);
        }

        public void SetSeed(int seed)
        {
            _random = new System.Random(seed);
        }

        public T Choose<T>(T[] array)
        {
            return array[Next(0, array.Length)];
        }

        public Direction GetDirection()
        {
            int id = Next(0, 4);
            if (id == 0) return Direction.Down;
            else if (id == 1) return Direction.Right;
            else if (id == 2) return Direction.Left;
            return Direction.Up;
        }

        public bool Roulette(float chance)
        {
            int accuracity = 10000;
            if ((float)Next(0, accuracity) / (float)accuracity < chance) return true;
            return false;
        }


        public int Next(int min, int max)
        {
            return _random.Next(min, max);
        }

        public int ChooseElementFromProbabilityArray(int[] array, int probabilitySum)
        {
            int a = Next(0, probabilitySum);

            int totalProbability = 0;
            for (int id=0; id < array.Length; id++)
            {
                totalProbability += array[id];
                if (totalProbability > a)
                {
                    return id;
                }
            }

            Debug.LogWarning("ERROR IN RANDOM");
            return -1;
        }
    }
}