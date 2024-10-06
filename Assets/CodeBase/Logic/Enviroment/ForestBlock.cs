using CodeBase.Infrastructure.Data.PlayerData;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services;
using UnityEngine;

public class ForestBlock : MonoBehaviour
{
    private GameData _progressGameData;

    protected bool Active = false;
    protected GameData GameData => AllServices.Container.Single<PersistentProgressService>().Progress.GameData;
    [SerializeField] private int needStonesCount;
    [SerializeField] private GameObject blockObj;
    private void Start()
    {
        _progressGameData = AllServices.Container.Single<PersistentProgressService>().Progress.GameData;
        blockObj.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_progressGameData.Looted.Count>=needStonesCount) blockObj.SetActive(false);
        else blockObj.SetActive(true);
    }
}
