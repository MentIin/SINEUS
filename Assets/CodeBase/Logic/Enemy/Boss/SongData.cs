using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Logic.Enemy.Boss
{
    [Serializable]
    public class SongData
    {
        [Header("Duration in sec")]
        public float Duration = 130f;

        public List<float> Timings = new List<float>();
    }
}