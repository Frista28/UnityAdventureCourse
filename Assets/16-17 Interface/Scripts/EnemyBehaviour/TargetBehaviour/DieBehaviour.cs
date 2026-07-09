using System.Data;
using _16_17_Interface.Scripts.Interfaces;
using UnityEngine;

namespace _16_17_Interface.Scripts.EnemyBehaviour.TargetBehaviour
{
    public class DieBehaviour : IBehaviour
    {
        private EnemyController _selfController;

        public DieBehaviour(EnemyController self)
        {
            _selfController = self;
        }
        
        public void Execute()
        {
            Die();
        }

        private void Die()
        {
            _selfController.Destroy();
        }
    }
}