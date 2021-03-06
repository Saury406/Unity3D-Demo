using UnityEngine;
#if !(UNITY_5_3 || UNITY_5_4)
using UnityEngine.AI;
#endif

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityNavMeshAgent
{
    [TaskCategory("Basic/NavMeshAgent")]
    [TaskDescription("Stop movement of this agent along its current path. Returns Success.")]
    public class Stop : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;

        // cache the navmeshagent component
        private NavMeshAgent navMeshAgent;
        private GameObject prevGameObject;

        public override void OnStart()
        {
            var currentGameObject = GetDefaultGameObject(targetGameObject.Value);
            if (currentGameObject != prevGameObject) {
                navMeshAgent = currentGameObject.GetComponent<NavMeshAgent>();
                prevGameObject = currentGameObject;
            }
        }

        public override TaskStatus OnUpdate()
        {
            if (navMeshAgent == null) {
                Debug.LogWarning("NavMeshAgent is null");
                return TaskStatus.Failure;
            }

#if UNITY_5_3 || UNITY_5_4 || UNITY_5_5
            navMeshAgent.Stop();
#else
            navMeshAgent.isStopped = true;
#endif

            return TaskStatus.Success;
        }

        public override void OnReset()
        {
            targetGameObject = null;
        }
    }
}