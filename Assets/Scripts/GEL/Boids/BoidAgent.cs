using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace GEL.Boids
{
    public class BoidAgent
    {
        public Vector3 position;

        public Vector3 velocity;

        public Vector3 accelaration;

        public float maxSpeed;
        public float maxForce;

        public BoidAgent(Vector3 pos, Vector3 vel)
        {
            this.position = pos;
            this.velocity = vel;
        }

        public void ComputeDesiredVelocity(Vector3 target)
        {
            Vector3 desiredVelocity = (target - position);
            Vector3.ClampMagnitude(desiredVelocity, maxSpeed);
            Vector3 steer = desiredVelocity - velocity;
            Vector3.ClampMagnitude(steer, maxForce);
            accelaration += steer;
        }
        
        public void Update()
        {
            this.velocity += accelaration;
            Vector3.ClampMagnitude(velocity, maxSpeed);
            this.position += velocity;
            this.velocity += accelaration;
        }
    }

}
