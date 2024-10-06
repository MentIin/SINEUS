using System;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.Audio;
using CodeBase.Infrastructure.Services.Pause;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Infrastructure.States;
using CodeBase.Infrastructure.StaticData.Dialogs;
using CodeBase.Logic;
using CodeBase.UI.Elements;
using CodeBase.UI.Elements.Buttons;
using CodeBase.UI.Elements.Dialogs;
using CodeBase.UI.Services.Windows;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.UI.Services.UIFactory
{
    public class UIFactory
    {
        private readonly StaticDataService _staticData;
        private readonly PersistentProgressService _persistentProgressService;
        private readonly GameStateMachine _stateMachine;
        private readonly AudioService _audioService;
        private Transform _uiRoot;
        private PauseService _pauseService;
        private readonly ISaveLoadService _saveLoadService;

        public UIFactory(StaticDataService staticData,
            PersistentProgressService persistentProgressService,
            GameStateMachine stateMachine, AudioService audioService,
            PauseService pauseService, ISaveLoadService saveLoadService)
        {
            _pauseService = pauseService;
            _saveLoadService = saveLoadService;
            _staticData = staticData;
            _persistentProgressService = persistentProgressService;
            _stateMachine = stateMachine;
            _audioService = audioService;
        }

        public void CreateWindow(WindowType type)
        {
            WindowConfig data = _staticData.ForWindow(type);
            var windowGameObject = Object.Instantiate(data.WindowPrefab);

            if (type == WindowType.MainMenu)
            {
                windowGameObject.GetComponentInChildren<ChangeStateButton>().Construct(_stateMachine);
            }
            
        }
        

        public delegate void MyCallback(int a);
        public void CreateDialog(DialogNodeStaticData staticData, MyCallback dialogCallback)
        {
            GameObject prefab = Resources.Load<GameObject>(AssetAddress.Dialog);
            GameObject dialogGameObject = Object.Instantiate(prefab);
            dialogCallback?.Invoke(1233333);
            dialogGameObject.GetComponent<DialogWindow>().Construct(staticData, dialogCallback);
            
        }
        public void Clear()
        {
            Object.DestroyImmediate(_uiRoot.gameObject);
        }

        public void CreateHUD(Health hp)
        {
            GameObject prefab = Resources.Load<GameObject>(AssetAddress.HUD);
            GameObject go = Object.Instantiate(prefab);
            go.GetComponentInChildren<HpBar>().Construct(hp);
            
            go.GetComponentInChildren<OpenWindowButton>().Construct(this);
        }
    }
}