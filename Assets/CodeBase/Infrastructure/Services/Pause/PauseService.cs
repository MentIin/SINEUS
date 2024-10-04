using CodeBase.Infrastructure.Services.Audio;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pause
{
    public class PauseService : IService
    {
        private readonly AudioService _audioService;

        public PauseService(AudioService audioService)
        {
            _audioService = audioService;
        }

        public void Pause()
        {
            _audioService.PauseSounds();
            Time.timeScale = 0f;
            
        }

        public void Resume()
        {
            
            _audioService.ResumeSounds();
            Time.timeScale = 1f;
        }
    }
}