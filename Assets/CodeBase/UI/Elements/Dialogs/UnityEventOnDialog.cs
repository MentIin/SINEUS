using System;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.UI.Elements.Dialogs
{
    public class UnityEventOnDialog : MonoBehaviour
    {
        public UnityEvent UnityEvent;
        public int EventId;
        public DialogStarter DialogStarter;

        private void Start()
        {
            DialogStarter.DialogCallback += DialogCallback;
        }

        private void DialogCallback(int obj)
        {
            print("id -" + obj);
            if (obj == EventId)
            {
                UnityEvent?.Invoke();
            }
        }
    }
}