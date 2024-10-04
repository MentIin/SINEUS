using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Audio;
using CodeBase.Sounds;
using UnityEngine;

namespace Assets.CodeBase.Sounds
{
    public class PlaySound : MonoBehaviour
    {
        public AudioClip sound;

        public bool IgnorePause = false;
        
        public bool IgnorePosition = false;
        
        private AudioService _audioService;
        private LoopingSound _loopingSound;

        [Range(0f, 1f)][SerializeField] private float _volume = 1f;
        public float Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                if (_loopingSound != null)
                {
                    _loopingSound.volume = _volume * value;
                }
            }
        }

        private void Awake()
        {
            _audioService = AllServices.Container.Single<AudioService>();
            Volume = _volume;
        }

        private void Update()
        {
            if (_loopingSound != null)
            {
                _loopingSound.SetPosition(transform.position);
            }
        }

        public void PlayOneShot()
        {
            
            _audioService.PlaySound(sound, transform.position,
                true, Volume, IgnorePause, IgnorePosition);
        }

        public void StartPlaying()
        {
            
            if (_loopingSound == null) _loopingSound = _audioService.CreateLoopingSound(sound, IgnorePosition);
            _loopingSound.Play();
            Volume = Volume;
        }
        public void StopPlaying()
        {
            _loopingSound?.Stop();
        }

        private void OnDestroy()
        {
            if (_loopingSound != null)
            {
                StopPlaying();
            }
        }
    }
}