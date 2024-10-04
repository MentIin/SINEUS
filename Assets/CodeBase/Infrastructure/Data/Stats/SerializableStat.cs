using System;
using UnityEngine;

namespace CodeBase.Infrastructure.Data.Stats
{
    [Serializable]
    public class SerializableStat
    {
        [HideInInspector]public string name;
        public StatType Type;
        public int Value;
        public void Validate()
        {
            name = Type.ToString();
        }
    }

    public enum StatType
    {
        None=0, Damage=1, Health=2, ReloadSpeed=3,
    }
}