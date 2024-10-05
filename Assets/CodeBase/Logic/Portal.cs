using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameStateMachine gameStateMachine;
    void Start()
    {
        gameStateMachine=AllServices.Container.Single<GameStateMachine>();
    }

    public void LoadNewLevel(int id)
    {
        gameStateMachine.Enter<LoadLevelState, int>(id);
    }
}
