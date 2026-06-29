using _16_17_Interface.Scripts.Interfaces;
using UnityEngine;

namespace _16_17_Interface.Scripts.PlayerBehaviour
{
    public class PlayerController : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _rotateSpeed = 500f;
        
        private IMovable _movable;
        private IRotatable _rotator;

        private void Awake()
        {
            _movable = new MoverLinear(transform);
            _rotator = new RotatorInDirection(transform);
        }

        private void Update()
        {
            Vector3 direction = GetMoveDirection();
            
            _movable.Move(direction, _moveSpeed * Time.deltaTime);
            
            _rotator.Rotate(direction, _rotateSpeed * Time.deltaTime);
        }
        
        private Vector3 GetMoveDirection() => new Vector3(Input.GetAxisRaw(Horizontal), 0f, Input.GetAxisRaw(Vertical));
    }
}
