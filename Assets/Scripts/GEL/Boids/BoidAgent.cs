using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace GEL.Boids
{
    public class BoidAgent
    {
        public BoidsSystem boidsSystem;
        public Vector3 position;

        public Vector3 velocity;

        public Vector3 accelaration;

        public float speed = 0.01f;
        
        public float maxSpeed =0.01f;
        public float maxForce =0.01f;

        public List<BoidAgent> neighbors = new List<BoidAgent>();
        public BoidAgent(Vector3 pos, Vector3 vel)
        {
            this.position = pos;
            this.velocity = vel*speed;
            
        }

        public void ComputeDesiredVelocity()
        {
            //Separation
            Vector3 separation = Vector3.zero;
            if(neighbors.Count==0) return;
            
            foreach (var neighbor in neighbors)
            {
                Vector3 force = position - neighbor.position;
                
                separation += force.normalized;
            }

            accelaration += separation* boidsSystem.separationStrength;
            
            //Cohesion
            Vector3 neighborCenter = Vector3.zero;
            foreach (var neighbor in neighbors)
            {
                neighborCenter += neighbor.position;
            }

            neighborCenter /= neighbors.Count;
            Vector3 cohesion = (neighborCenter - position).normalized;
            accelaration += cohesion * boidsSystem.cohesionStrength;
            
            //Alignment
            Vector3 alignment = Vector3.zero;
            foreach (var neighbor in neighbors)
            {
                alignment += neighbor.velocity;
            }

            alignment /= neighbors.Count;
            accelaration += alignment * boidsSystem.alignmentStrength;
            
            //Vector3 desiredVelocity = (target - position);
            //Vector3.ClampMagnitude(desiredVelocity, maxSpeed);
            //Vector3 steer = desiredVelocity - velocity;
            //Vector3.ClampMagnitude(steer, maxForce);
            //accelaration += steer;
        }
        
        public void Update()
        {
            ComputeDesiredVelocity();
            Vector3.ClampMagnitude(accelaration, maxForce);
            this.velocity += accelaration;
            Vector3.ClampMagnitude(velocity, maxSpeed);
            this.position += velocity;
           
        }
    }

}
