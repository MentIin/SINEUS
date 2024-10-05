using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic.CameraLogic;
using System;
using UnityEngine;

namespace CodeBase.Logic.Stones
{
    class GravityStone : BaseStone
    {
        public CharacterController2D CharacterController;

        public CameraController camera;
        private float defSize;
        [SerializeField] private float newSize=10;
        [SerializeField] private float changeTime = 0.3f;

        private bool _antigravity = false;
        protected override void Initialize()
        {
            //camera = AllServices.Container.Single<CameraController>();
            defSize = camera._size;
        }

        protected override void Deactivate()
        {
            DefaultGravity();
        }

        private void Update()
        {
            if (Active)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (!_antigravity)
                    {
                        if (GameData.UsagesLeftSlots(Type) == 0)
                        {
                            return;
                        }
                        
                        Antigravity();
                        _antigravity = true;
                        GameData.Spend(Type);
                    }
                    else
                    {
                        DefaultGravity();
                        _antigravity = false;
                    }
                }
            }
        }

        protected override void Activate()
        {
            
        }

        private void DefaultGravity()
        {
            CharacterController.SetGravityScale(1f);
            CharacterController.transform.eulerAngles = new Vector3(0f, CharacterController.transform.eulerAngles.y,
                0f);
            camera.SetScale(defSize, changeTime);

        }

        private void Antigravity()
        {
            CharacterController.SetGravityScale(-1f);
            CharacterController.transform.eulerAngles = new Vector3(0f, CharacterController.transform.eulerAngles.y,
                180f);
            camera.SetScale(newSize, changeTime);
        }
    }
}