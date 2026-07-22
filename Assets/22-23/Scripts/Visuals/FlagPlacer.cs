using _22_23.Scripts.Items.Marks;
using UnityEngine;

namespace _22_23.Scripts.Visuals
{
    public class FlagPlacer : MonoBehaviour
    {
        [SerializeField] private Flag _flagPrefab;
        
        private Flag _flag;
        
        private void Start()
        {
            _flag = Instantiate(_flagPrefab, Vector3.zero, Quaternion.identity);
            _flag.Disable();
        }
        
        public void PlaceFlag(Vector3 position) => _flag.ChangePosition(position);

        public void RemoveFlag() => _flag.Disable();
    }
}