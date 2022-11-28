using System.Collections;
using System.Collections.Generic;
using GEl.Flock;
using UnityEngine;
namespace GEL.Flock
{
    [CreateAssetMenu(menuName = "GEL/Flock/Behavior/Align")]
    public class AlignBehavior : FlockBehavior
    {
        public override Vector3 CalculateVelocity(FlockAgent agent, List<Transform> context, FlockSystem flockSystem)
        {
            if(context.Count==0) return Vector3.forward;
            
            Vector3 alignmentMove = Vector3.zero;
            foreach (var item in context)
            {
                alignmentMove += item.forward;
            }

            alignmentMove /= context.Count;
            return alignmentMove;
        }
    }
}