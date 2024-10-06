using CodeBase.Infrastructure.Data.PlayerData;
using CodeBase.Infrastructure.Services.Audio;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services;
using UnityEngine;

public class ChangeAudioTrigger : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioService audioService;
    private GameData gameData;
    private void Start()
    {
        audioService = AllServices.Container.Single<AudioService>();
        gameData = AllServices.Container.Single<PersistentProgressService>().Progress.GameData;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetAudio(audioClip);
    }
    public void SetAudio(AudioClip clip)
    {
        audioService.SetAmbient(clip);
    }
}