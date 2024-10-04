using UnityEngine;

namespace CodeBase.Logic.Animations
{
    public class GetDamageSimpleAnimation
    {
        private SpriteRenderer _renderer;
        private readonly SpriteRenderer[] _additionals;

        private float _current = 0f;

        public GetDamageSimpleAnimation(SpriteRenderer renderer)
        {
            _renderer = renderer;
            _additionals = new SpriteRenderer[0];
        }

        public GetDamageSimpleAnimation(SpriteRenderer renderer, SpriteRenderer[] additionals)
        {
            _renderer = renderer;
            _additionals = additionals;
        }

        public void Activate()
        {
            _current += 1f;
            if (_current > 1) _current = 1f;
        }

        public void Update()
        {
            _current -= Time.deltaTime;
            if (_current < 0) _current = 0;
            
            
            
            Color rendererColor = _renderer.color;
            rendererColor.b = 1 - _current * 0.8f;
            rendererColor.g = 1 - _current * 0.8f;
            _renderer.color = rendererColor;
            
            foreach (var i in _additionals)
            {
                rendererColor = i.color;
                rendererColor = _renderer.color;
                rendererColor.b = 1 - _current * 0.8f;
                rendererColor.g = 1 - _current * 0.8f;
                i.color = rendererColor;
            }
        }
    }
}