using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class HpBar : MonoBehaviour
    {
          public Bar _bar;
          private Health _health;
        

          public void Construct(Health health)
          {
              _health = health;
              Initialize();
          }

          private void Initialize()
          {
              _health.HealthChanged += UpdateBar;
              _bar.Initialize();
              UpdateBar();
          }

          private void SetValue(float current, float max)
          {
                
                _bar.SetValue(current, max);
          }

          private void UpdateBar()
          {
              SetValue(_health.Current, _health.Max);
          }
    }
}
