using UnityEngine;

namespace _31.Scripts.Infrastructure.Utils
{
    public static class GameObjectUtils
    {
        public static T GetRequiredComponentInSelfOrParent<T>(GameObject gameObject)
        {
            T component = gameObject.GetComponent<T>();
            
            if (component == null)
            {
                component = gameObject.GetComponentInParent<T>();
            }

            if (component == null)
            {
                throw new System.InvalidOperationException(
                    $"Component {typeof(T).Name} is missing on {gameObject.name} or its parents.");
            }

            return component;
        }

        public static bool TryGetComponentInSelfOrParent<T>(GameObject gameObject, out T component)
        {
            component = gameObject.GetComponent<T>();

            if (component != null)
                return true;

            component = gameObject.GetComponentInParent<T>();

            return component != null;
        }
    }
}