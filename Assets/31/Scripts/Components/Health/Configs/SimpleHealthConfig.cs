using UnityEngine;

namespace _31.Scripts.Components.Health.Configs
{
    [CreateAssetMenu(fileName = "SimpleHealthConfig", menuName = "Components/Health/SimpleHealthConfig")]
    public class SimpleHealthConfig : HealthConfig
    {
        [field: SerializeField] public float MaxHealth { get; private set; }
        
        [field: SerializeField] public float StartHealth { get; private set; }

        private void OnValidate()
        {
            MaxHealth = Mathf.Max(0.01f, MaxHealth);
            StartHealth = Mathf.Max(0.01f, StartHealth);

            if (StartHealth > MaxHealth)
                MaxHealth = StartHealth;
        }
    }
}