using CodeBase.Infrastructure.States;
using CodeBase.Logic.CameraLogic;
using CodeBase.UI;
using UnityEngine;
using UnityEngine.Audio;


namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain _loadingCurtain;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private CameraController _cameraController;
        [Space(10)]
        [SerializeField] private AudioMixerGroup soundsMixerGroup;
        [SerializeField] private AudioMixerGroup musicMixerGroup;

        private Game _game;

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(_cameraController.transform.parent.gameObject);
            DontDestroyOnLoad(_loadingCurtain.gameObject);


            _game = new Game(this, _loadingCurtain, _audioSource, _cameraController, soundsMixerGroup, musicMixerGroup);
            _game.StateMachine.Enter<BootstrapState>();
        }
    }
}