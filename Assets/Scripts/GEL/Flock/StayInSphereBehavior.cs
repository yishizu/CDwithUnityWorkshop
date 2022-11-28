using System.Collections;
using System.Collections.Generic;
using GEl.Flock;
using UnityEngine;
namespace GEL.Flock
{
    [CreateAssetMenu(menuName = "GEL/Flock/Behavior/StayInSphere")]
    public class StayInSphereBehavior : FlockBehavior
    {
        public Vector3 center;
        public float radius = 30f;
        public override Vector3 CalculateVelocity(FlockAgent agent, List<Transform> context, FlockSystem flockSystem)
        {
            
            Vector3 dir = center - agent.transform.position;
            float distance = dir.magnitude;
            float t = distance / radius;
            if (t < 0.9)
            {
                return Vector3.zero;
            }
            return dir * (t * t);
        }
    }
}