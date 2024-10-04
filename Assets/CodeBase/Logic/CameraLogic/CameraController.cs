using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Logic.CameraLogic
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Image _shade;
        private float _size;

        private Transform _follow;

        private void Awake()
        {
            _size = _camera.orthographicSize;
        }

        public void Follow(Transform follow)
        {
            _follow = follow;
        }

        private void LateUpdate()
        {
            if (_follow != null)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, _follow.position, 0.5f);
            }
        }

        public void Shake(float duration, float strength, int vibrato, float randomness)
        {
            transform.parent.DOShakePosition(duration, strength*2, vibrato, randomness, false, false,
                ShakeRandomnessMode.Full).SetId(123123);
        }

        public bool CheckIfPointInView(Vector2 position)
        {
            return _camera.rect.Contains(position);
        }

        public void SetScale(float size, float time)
        {
            _camera.DOOrthoSize(size, time).SetId(446906);
        }

        public void SetScaleToDefault()
        {
            _camera.orthographicSize = _size;
        }

        public void Shade(float a, float time)
        {
            _shade.DOFade(a, time).SetId(999);
        }

        public void RemoveShade()
        {
            Shade(0f, 0f);
        }

        private void OnDestroy()
        {
            DOTween.Kill(123123);
            DOTween.Kill(999);
            DOTween.Kill(446906);
        }
    }
}