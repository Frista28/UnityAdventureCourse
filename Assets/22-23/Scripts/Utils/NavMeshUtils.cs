using UnityEngine;
using UnityEngine.AI;

namespace _22_23.Scripts.Utils
{
    public static class NavMeshUtils
    {
        public static float GetPathLength(NavMeshPath path)
        {
            float pathLength = 0;

            if (path.corners.Length > 1)
            {
                for (int i = 1; i < path.corners.Length; i++)
                {
                    pathLength += Vector3.Distance(path.corners[i - 1], path.corners[i]);
                }
            }
            return pathLength;
        }
        
        public static bool TryGetPath(Vector3 sourcePosition, Vector3 targetPosition, NavMeshQueryFilter queryFilter, NavMeshPath pathToTarget)
        {
            if (NavMesh.CalculatePath(sourcePosition, targetPosition, queryFilter, pathToTarget) && pathToTarget.status != NavMeshPathStatus.PathInvalid)
                return true;

            return false;
        }
    }
}