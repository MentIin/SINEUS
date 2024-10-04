using System;
using CodeBase.Infrastructure.Data;
using UnityEngine;

namespace CodeBase.Logic
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 10;
        [SerializeField] private int _currentHealth = 10;

        public Team Team = Team.Neutral;
        private bool _immortal = false;

        public event Action<int> DamageTaken;
        public event Action HealthChanged;
        public int Current => _currentHealth;
        public int Max => _maxHealth;

        public void TakeDamage(int damage)
        {
            if (_immortal) return;
            _currentHealth -= damage;
            DamageTaken?.Invoke(damage);
            HealthChanged?.Invoke();
        }

        public void SetStartHealth(int health)
        {
            _currentHealth = health;
            _maxHealth = health;
            HealthChanged?.Invoke();
        }

        public void AdjustMaxHealth(int health)
        {
            _currentHealth = _currentHealth + health;
            _maxHealth = _maxHealth + health;
            HealthChanged?.Invoke();
        }

        public void Heal(int amount)
        {
            _currentHealth += amount;
            if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
            HealthChanged?.Invoke();
        }

        public void BecomeImmortal()
        {
            _immortal = true;
        }
    }
}