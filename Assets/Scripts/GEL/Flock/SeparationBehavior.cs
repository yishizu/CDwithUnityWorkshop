using System.Collections;
using System.Collections.Generic;
using GEl.Flock;
using UnityEngine;
namespace GEL.Flock
{
    [CreateAssetMenu(menuName = "GEL/Flock/Behavior/Separation")]
    public class SeparationBehavior : FlockBehavior
    {
        private float agentSmoothTime = 0.5f;
        private Vector3 currentVelocity;
        public override Vector3 CalculateVelocity(FlockAgent agent, List<Transform> context, FlockSystem flockSystem)
        {
            if(context.Count==0) return Vector3.zero;
            
            Vector3 separationMove = Vector3.zero;
            int nSeparation = 0;
            foreach (var item in context)
            {
                if (Vector3.SqrMagnitude(item.position-agent.transform.position) < flockSystem.SquareAvoidanceRadius)
                    nSeparation++;
                    separationMove += agent.transform.position -item.position;
            }

            if (nSeparation > 0)
            {
                separationMove /= nSeparation;
            }

            return separationMove;
        }
    }
}
