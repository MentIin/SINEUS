using System;
using UnityEngine;

namespace CodeBase.Logic
{
    [RequireComponent(typeof(Collider2D))]
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider2D> TriggerEnter;
        public event Action<Collider2D> TriggerExit;
        public int CollidersInside { get; private set; }

        private void OnTriggerEnter2D(Collider2D col)
        {

            TriggerEnter?.Invoke(col);
            CollidersInside += 1;
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            TriggerExit?.Invoke(col);
            CollidersInside -= 1;
        }
    }
}