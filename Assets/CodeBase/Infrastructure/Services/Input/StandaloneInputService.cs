using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
    public class StandaloneInputService : IInputService
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        private ICoroutineRunner _coroutineRunner;


        public StandaloneInputService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Initialize()
        {
            _coroutineRunner.StartCoroutine(Check());
        }

        public bool JumpStart()
        {
            return UnityEngine.Input.GetKeyDown(KeyCode.Space) || UnityEngine.Input.GetKeyDown(KeyCode.W);
        }
        public bool JumpEnd()
        {
            return UnityEngine.Input.GetKeyUp(KeyCode.Space) || UnityEngine.Input.GetKeyUp(KeyCode.W);
        }

        public bool Attack()
        {
            return UnityEngine.Input.GetMouseButtonDown(0);
        }

        public Vector2 GetAxis()
        {
            return new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical)).normalized;
        }



        public void ClearInput()
        {
            
        }

        private IEnumerator Check()
        {
            while (true)
            {
                
                yield return null;
            }
        }
    }
}