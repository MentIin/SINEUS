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

        public List<Timing> Timings = new List<Timing>();
    }

    [Serializable]
    public class Timing
    {
        public float AppearTime;
        public float PlevTime;
    }
}