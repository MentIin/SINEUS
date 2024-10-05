using System;
using CodeBase.Infrastructure.Data.PlayerData;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Audio;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Logic.Sounds
{
    public class LevelAuidio : MonoBehaviour
    {
        public GameData.MagicStonesTypes Type;
        public AudioClip EvilClip;
        public AudioClip GoodClip;
        
        
        private AudioService audioService;
        private GameData gameData;


        private bool _good = false;

        private void Start()
        {
            audioService = AllServices.Container.Single<AudioService>();
            gameData = AllServices.Container.Single<PersistentProgressService>().Progress.GameData;


            audioService.SetAmbient(EvilClip);
            SetAudio();
            gameData.MagicStoneChanged += SetAudio;
        }

        private void SetAudio()
        {
            if (gameData.Recived.Contains(Type) && !_good)
            {
                _good = true;
                audioService.SetAmbient(GoodClip);
            }
            else if (_good)
            {
                audioService.SetAmbient(EvilClip);
            }
        }
    }
}