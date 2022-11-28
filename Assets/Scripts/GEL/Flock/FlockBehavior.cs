using System.Collections;
using System.Collections.Generic;
using GEl.Flock;
using UnityEngine;

namespace GEL.Flock
{
    public abstract class FlockBehavior : ScriptableObject
    {
        public abstract Vector3 CalculateVelocity(FlockAgent agent, List<Transform> context, FlockSystem flockSystem);
    }
}

