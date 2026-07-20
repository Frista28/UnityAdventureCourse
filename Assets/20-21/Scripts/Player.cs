using UnityEngine;

namespace _20_21.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _explodeRadius = 10f;
        [SerializeField] private float _explodeForce = 10f;
        
        [SerializeField] private ParticleSystem _explodeParticles;
        
        private bool leftMouseButtonDown;
        private bool rightMouseButtonDown;

        private DragHandler _dragHandler;
        private ExplosionCaster _explosionCaster;

        private void Awake()
        {
            _dragHandler = new DragHandler();
            _explosionCaster = new ExplosionCaster(_explodeParticles, _explodeRadius, _explodeForce);
        }

        private void Update()
        {
            leftMouseButtonDown = Input.GetMouseButtonDown(0);
            rightMouseButtonDown = Input.GetMouseButtonDown(1);
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (leftMouseButtonDown)
            {
                _dragHandler.Execute(ray);
                _dragHandler.Drop();
            }
            
            if (rightMouseButtonDown && _dragHandler.IsBlocked == false)
                _explosionCaster.Execute(ray);
                
            _dragHandler.Drag(Input.mousePosition, Input.mouseScrollDelta.y);
        }
    }
}