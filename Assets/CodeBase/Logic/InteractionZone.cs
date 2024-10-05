using System;
using CodeBase.Logic.Player;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Logic
{
    public class InteractionZone : MonoBehaviour
    {
        public Canvas InteractionLabel;
        public UnityEvent Event;

        private bool _used = false;
        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController controller;
            if (other.TryGetComponent(out controller))
            {
                InteractionLabel.gameObject.SetActive(true);
            }
        }


        private void Update()
        {
            if (_used) return;
            if (InteractionLabel.gameObject.active)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _used = true;
                    Event.Invoke();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            PlayerController controller;
            if (other.TryGetComponent(out controller))
            {
                _used = false;
                InteractionLabel.gameObject.SetActive(false);
            }
        }
    }
}