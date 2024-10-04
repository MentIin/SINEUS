using System;
using UnityEngine;

namespace CodeBase.UI.Services.Windows
{
    [Serializable]
    public class WindowConfig
    {
        public WindowType WindowType;
        public GameObject WindowPrefab;
    }
}