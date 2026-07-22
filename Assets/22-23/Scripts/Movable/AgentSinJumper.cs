using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace _22_23.Scripts.Movable
{
    public class AgentSinJumper
    {
        private readonly float _jumpSpeed;
        private readonly AnimationCurve _jumpCurve;
        
        private readonly NavMeshAgent _agent;
        
        private readonly MonoBehaviour _coroutineStarter;
        
        private Coroutine _coroutine;
        
        public AgentSinJumper(NavMeshAgent agent, float jumpSpeed, MonoBehaviour coroutineStarter, AnimationCurve jumpCurve)
        {
            _agent = agent;
            _jumpSpeed = jumpSpeed;
            _coroutineStarter = coroutineStarter;
            _jumpCurve = jumpCurve;
        }
        
        public bool IsJumping() => _coroutine != null;

        public void Jump(OffMeshLinkData offMeshLinkData)
        {
            if (IsJumping())
                return;
            
            _coroutine = _coroutineStarter.StartCoroutine(JumpProcess(offMeshLinkData));
        }

        private IEnumerator JumpProcess(OffMeshLinkData offMeshLinkData)
        {
            Vector3 startPosition = offMeshLinkData.startPos;
            Vector3 endPosotion = offMeshLinkData.endPos;
            
            float duration = Vector3.Distance(startPosition, endPosotion) / _jumpSpeed;
            
            float progress = 0f;

            while (progress < duration)
            {
                float yOffset = _jumpCurve.Evaluate(progress / duration);
                _agent.transform.position = Vector3.Lerp(startPosition, endPosotion, progress/duration) + Vector3.up * yOffset;
                progress += Time.deltaTime;
                yield return null;
            }

            _coroutine = null;
            _agent.CompleteOffMeshLink();
        }
    }
}