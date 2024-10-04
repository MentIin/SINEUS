using CodeBase.UI.Services;
using CodeBase.UI.Services.UIFactory;
using CodeBase.UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements.Buttons
{
    public class OpenWindowButton : MonoBehaviour
    {
        [SerializeField] private WindowType _type;
        [SerializeField] private Button _button;
        private UIFactory _uiFactory;

        public void Construct(UIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        private void Awake()
        {
            _button.onClick.AddListener(Open);
        }

        private void Open()
        {
            _uiFactory.CreateWindow(_type);
        }
    }
}