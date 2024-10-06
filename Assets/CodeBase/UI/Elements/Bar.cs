using UnityEngine;

namespace CodeBase.UI.Elements
{
    public abstract class Bar : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void SetValue(float current, float max);
    }
}