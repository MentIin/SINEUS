using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements.Buttons
{
    public class CloseWindowButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _window;

        private void Awake()
        {
            _button.onClick.AddListener(Close);
        }

        private void Close()
        {
            Destroy(_window);
        }
    }
}