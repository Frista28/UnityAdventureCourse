using UnityEngine;

namespace _27_28.Scripts.Delegate
{
    public class Enemy : MonoBehaviour, IKillable
    {
        public bool IsDead { get; private set; }
        public float LifeTime { get; private set; }

        public void Kill()
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            LifeTime += Time.deltaTime;
        }
    }
}