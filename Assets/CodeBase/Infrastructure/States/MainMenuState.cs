using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.UI;
using CodeBase.UI.Services.UIFactory;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    class MainMenuState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PersistentProgressService _progressService;
        private readonly UIFactory _uiFactory;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly SceneLoader _sceneLoader;
        private const string MainMenuSceneName = "MainMenuScene";

        public MainMenuState(GameStateMachine stateMachine, PersistentProgressService progressService,
            UIFactory uiFactory, LoadingCurtain loadingCurtain, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _uiFactory = uiFactory;
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
        }
        public void Exit()
        {
            
        }

        public void Enter()
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(MainMenuSceneName, OnLoaded);

        }

        private void OnLoaded()
        {
            _loadingCurtain.UpdateLoading(100);

            //_uiFactory.CreateWindow(WindowType.MainMenu);
            _loadingCurtain.Hide();
            Debug.Log("MainMenuState");
        }
    }
}