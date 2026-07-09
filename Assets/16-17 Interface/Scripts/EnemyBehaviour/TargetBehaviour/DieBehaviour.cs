using System.Data;
using _16_17_Interface.Scripts.Interfaces;
using UnityEngine;

namespace _16_17_Interface.Scripts.EnemyBehaviour.TargetBehaviour
{
    public class DieBehaviour : IBehaviour
    {
        private IKillable _taget;

        public DieBehaviour(IKillable target)
        {
            _taget = target;
        }
        
        public void Execute()
        {
            Die();
        }

        private void Die()
        {
            _taget.Die();
        }
    }
}