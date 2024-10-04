using System;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StaticData.Dialogs;
using CodeBase.UI.Services.UIFactory;
using UnityEngine;

namespace CodeBase.UI.Elements.Dialogs
{
    public class DialogStarter : MonoBehaviour
    {
        public DialogNodeStaticData StaticData;
        private UIFactory _uiFactory;
        
        public Action<int> DialogCallback;

        private void Start()
        {
            _uiFactory = AllServices.Container.Single<UIFactory>();
            
            _uiFactory.CreateDialog(StaticData, Callback);
        }

        private void Callback(int id)
        {
            DialogCallback?.Invoke(id);
        }
    }
}