using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 GetAxis();
        void ClearInput();
        void Initialize();
        bool JumpStart();
        bool JumpEnd();
        bool Attack();
    }
}