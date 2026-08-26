using UnityEngine;

namespace _31.Scripts.Hits.Data
{
    public class HitData
    {
        public GameObject Source { get; private set; }

        public GameObject Target { get; }

        public Vector3 Point { get; }
        
        public Vector3 Normal { get; }
        
        public HitData(
            GameObject target,
            Vector3 point,
            Vector3 normal)
        {
            Target = target;
            Point = point;
            Normal = normal;
        }
        
        public void WithSource(GameObject source) => Source = source;
    }
}