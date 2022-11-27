using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GEL.Boids
{
    public class BoidsSystem
    {
        
        public int count;
        public List<BoidAgent> agents = new List<BoidAgent>();

        public Vector3 center = Vector3.zero;
        public float boundsSize = 30f;
        
        
        private Bounds _bounds = new Bounds();

        public BoidsSystem(int count)
        {
            this.count = count;
            _bounds = new Bounds(center, new Vector3(boundsSize, boundsSize,boundsSize));
            agents = new List<BoidAgent>();
            CreateAgents(count, _bounds);
        }

        void CreateAgents(int count, Bounds bounds)
        {
            for (int i = 0; i < count; i++)
            {
                BoidAgent boidAgent = new BoidAgent(Utilities.GetRandomPosition(bounds), Utilities.GetRandomVelocity());
                agents.Add(boidAgent);
            }
            
            
        }
        
        
    }
}

