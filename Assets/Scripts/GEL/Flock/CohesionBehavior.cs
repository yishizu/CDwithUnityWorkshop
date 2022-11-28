using System.Collections;
using System.Collections.Generic;
using GEl.Flock;
using UnityEngine;

namespace GEL.Flock
{
    [CreateAssetMenu(menuName = "GEL/Flock/Behavior/Cohesion")]
    public class CohesionBehavior : FlockBehavior
    {
        
        public override Vector3 CalculateVelocity(FlockAgent agent, List<Transform> context, FlockSystem flockSystem)
        {
            if(context.Count==0) return Vector3.zero;
            
            Vector3 cohesionMove = Vector3.zero;
            foreach (var item in context)
            {
                cohesionMove += item.position;
            }

            cohesionMove /= context.Count;
            cohesionMove -= agent.transform.position;
           // cohesionMove = Vector3.SmoothDamp(agent.transform.forward, cohesionMove, ref currentVelocity, agentSmoothTime);
            return cohesionMove;
        }
    }
}

