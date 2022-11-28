using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using GEl.Flock;
using UnityEngine;
using UnityEngine.Rendering;

namespace GEL.Flock
{
    [CreateAssetMenu(menuName = "GEL/Flock/Behavior/Composite")]
    public class CompositeBehavior : FlockBehavior
    {
        public FlockBehavior[] behaviors;
        public float[] weights;
       
        public override Vector3 CalculateVelocity(FlockAgent agent, List<Transform> context, FlockSystem flockSystem)
        {
            if (behaviors.Length != weights.Length)
            {
                return Vector3.zero;
            }
            
            
            Vector3 move = Vector3.zero;
            int i = 0;
            foreach (var behavior in behaviors)
            {
                Vector3 partialMove = behavior.CalculateVelocity(agent, context, flockSystem)*weights[i];
                if (partialMove != Vector3.zero)
                {
                    
                    if (partialMove.sqrMagnitude > weights[i] * weights[i])
                    {
                        partialMove.Normalize();
                        partialMove *= weights[i];
                    }
                    move += partialMove;
                }
                
                i++;
            }
            
            return move;
        }
    }
}

