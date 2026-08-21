using System;
using _31.Scripts.Components.Health.Configs;

namespace _31.Scripts.Components.Health
{
    public class HealthFactory
    {
        public Health Create(HealthConfig healthConfig)
        {
            Health health;

            switch (healthConfig)
            {
                case SimpleHealthConfig config:
                    health = new Health(config.MaxHealth, config.StartHealth);
                    break;
                
                default:
                    throw new ArgumentException($"Unsupported health config: {healthConfig.GetType().Name}");
            }
            
            return health;
        }
    }
}